using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PokemonUnboundDex.Models;
using PokemonUnboundDex.Resources;

namespace PokemonUnboundDex.Factories
{
    public class LearnsetsFactory
    {
        public LearnsetsFactory(SpeciesFactory speciesFactory, MovesFactory movesFactory)
        {
            SpeciesFactory = speciesFactory;
            MovesFactory = movesFactory;
        }

        public SpeciesFactory SpeciesFactory { get; private set; }
        public MovesFactory MovesFactory { get; private set; }

        public Learnset[] GetLearnsets()
        {
            var learnsetsPerLine = ResourceReader.ReadResourcePerLine("PokemonUnboundDex.Resources.Learnsets.c");

            List<Learnset> learnsets = new();
            var indexStartLevelUpLearnsets = Array.IndexOf(learnsetsPerLine, "const struct LevelUpMove* const gLevelUpLearnsets[NUM_SPECIES] =");
            Regex learnsetRegex = new(@"\[(?<species>\w+)\] = (?<learnset>\w+)");
            Regex speciesLearnsetRegex = new(@"LEVEL_UP_MOVE\(\s*(?<level>\d+), (?<move>\w+)\)");
            for (int i = indexStartLevelUpLearnsets + 2; i < learnsetsPerLine.Length && learnsetsPerLine[i].Trim() != "};"; i++)
            {
                var learnsetGroups = learnsetRegex.Match(learnsetsPerLine[i].Trim()).Groups;
                var speciesConstant = learnsetGroups["species"];
                var learnsetConstant = learnsetGroups["learnset"];
                if (!SpeciesFactory.IsSpecies(speciesConstant.Value)) continue;

                var pokemonId = SpeciesFactory.GetPokemonIdByConstantName(speciesConstant.Value);
                var indexLearnset = Array.IndexOf(learnsetsPerLine, $"static const struct LevelUpMove {learnsetConstant.Value}[] = {{");

                for (int j = indexLearnset + 1; j < indexStartLevelUpLearnsets && learnsetsPerLine[j].Trim() != "};"; j++)
                {
                    var speciesLearnsetMatch = speciesLearnsetRegex.Match(learnsetsPerLine[j].Trim());
                    if (!speciesLearnsetMatch.Success) continue;

                    learnsets.Add(new Learnset
                    {
                        PokemonId = pokemonId,
                        Level = int.Parse(speciesLearnsetMatch.Groups["level"].Value),
                        MoveId = MovesFactory.GetMoveIdByConstantName(speciesLearnsetMatch.Groups["move"].Value)
                    });
                }
            }

            return learnsets.ToArray();
        }
    }
}
