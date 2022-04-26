﻿using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using PokemonUnboundDex.Models;

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
            using var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PokemonUnboundDex.Resources.Base_Stats.c");
            using StreamReader baseStatsStream = new(resourceStream);

            List<string> baseStatsPerLine = new();

            while (!baseStatsStream.EndOfStream)
            {
                baseStatsPerLine.Add(baseStatsStream.ReadLine());
            }

            List<Pokemon> pokemons = new();
            Regex speciesRegex = new(@"\[(?<species>\w+)\] =$");
            Regex abilityRegex = new(@"\.(?<abilityNumber>ability[12]|hiddenAbility) = (?<abilityConstant>\w+),");
            Pokemon readingPokemon = null;
            for (int i = 0; i < baseStatsPerLine.Count; i++)
            {
                var speciesMatch = speciesRegex.Match(baseStatsPerLine[i].Trim());
                if ((!speciesMatch.Success || !SpeciesFactory.IsSpecies(speciesMatch.Groups["species"].Value)) && readingPokemon == null) continue;

                if (readingPokemon == null)
                {
                    readingPokemon = new();
                    readingPokemon.PokemonId = SpeciesFactory.GetPokemonIdByConstantName(speciesMatch.Groups["species"].Value);
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