using System.Collections.Generic;
using System.Text.RegularExpressions;
using PokemonUnboundDex.Models;
using PokemonUnboundDex.Resources;

namespace PokemonUnboundDex.Factories
{
    public class PokemonsFactory
    {
        public PokemonsFactory(SpeciesFactory speciesFactory)
        {
            SpeciesFactory = speciesFactory;
        }

        public SpeciesFactory SpeciesFactory { get; private set; }

        public Pokemon[] GetPokemons()
        {
            var baseStatsPerLine = ResourceReader.ReadResourcePerLine("PokemonUnboundDex.Resources.Base_Stats.c");
            var namesPerLine = ResourceReader.ReadResourcePerLine("PokemonUnboundDex.Resources.Pokemon_Name_Table.string");

            List<string> names = new();
            Regex nameRegex = new(@"#org @\w+");
            bool first = true, isName = false;
            foreach (var line in namesPerLine)
            {
                if (nameRegex.IsMatch(line.Trim()))
                {
                    if (first)
                        first = false;
                    else
                        isName = true;
                }
                else if (isName)
                {
                    names.Add(line.Trim());
                    isName = false;
                }
            }

            List<Pokemon> pokemons = new();
            Regex speciesRegex = new(@"\[(?<species>\w+)\] =$");
            Regex abilityRegex = new(@"\.(?<abilityNumber>ability[12]|hiddenAbility) = (?<abilityConstant>\w+),");
            Pokemon readingPokemon = null;
            for (int i = 0; i < baseStatsPerLine.Length; i++)
            {
                var speciesMatch = speciesRegex.Match(baseStatsPerLine[i].Trim());
                if ((!speciesMatch.Success || !SpeciesFactory.IsSpecies(speciesMatch.Groups["species"].Value)) && readingPokemon == null) continue;

                if (readingPokemon == null)
                {
                    readingPokemon = new();
                    readingPokemon.PokemonId = SpeciesFactory.GetPokemonIdByConstantName(speciesMatch.Groups["species"].Value);
                    readingPokemon.Name = names[readingPokemon.PokemonId];
                }
                else if (baseStatsPerLine[i].Trim() == "},")
                {
                    pokemons.Add(readingPokemon);
                    readingPokemon = null;
                    continue;
                }

                var abilityMatch = abilityRegex.Match(baseStatsPerLine[i].Trim());
                if (abilityMatch.Success)
                    switch (abilityMatch.Groups["abilityNumber"].Value)
                    {
                        case "ability1":
                            readingPokemon.Ability1 = abilityMatch.Groups["abilityConstant"].Value;
                            break;

                        case "ability2":
                            readingPokemon.Ability2 = abilityMatch.Groups["abilityConstant"].Value;
                            break;

                        case "hiddenAbility":
                            readingPokemon.HiddenAbility = abilityMatch.Groups["abilityConstant"].Value;
                            break;
                    }
            }

            return pokemons.ToArray();
        }
    }
}
