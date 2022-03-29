using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using PokemonUnboundDex.Models;

namespace PokemonUnboundDex.Factories
{
    public class LearnsetsFactory
    {
        public SpeciesFactory SpeciesFactory { get; set; }
        public MovesFactory MovesFactory { get; set; }

        public LearnsetsFactory(SpeciesFactory speciesFactory, MovesFactory movesFactory)
        {
            SpeciesFactory = speciesFactory;
            MovesFactory = movesFactory;
        }

        public Learnset[] GetLearnsets()
        {
            using var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PokemonUnboundDex.Resources.Learnsets.c");
            using StreamReader learnsetsStream = new(resourceStream);

            List<string> learnsetsPerLine = new();

            while (!learnsetsStream.EndOfStream)
            {
                learnsetsPerLine.Add(learnsetsStream.ReadLine());
            }

            List<Learnset> learnsets = new();
            var indexStartLevelUpLearnsets = learnsetsPerLine.IndexOf("const struct LevelUpMove* const gLevelUpLearnsets[NUM_SPECIES] =");
            Regex learnsetRegex = new(@"\[(?<species>\w+)\] = (?<learnset>\w+)");
            Regex speciesLearnsetRegex = new(@"LEVEL_UP_MOVE\(\s*(?<level>\d+), (?<move>\w+)\)");
            for (int i = indexStartLevelUpLearnsets + 2; i < learnsetsPerLine.Count && learnsetsPerLine[i].Trim() != "};"; i++)
            {
                var learnsetGroups = learnsetRegex.Match(learnsetsPerLine[i].Trim()).Groups;
                var speciesConstant = learnsetGroups["species"];
                var learnsetConstant = learnsetGroups["learnset"];
                if (!SpeciesFactory.IsSpecies(speciesConstant.Value)) continue;

                var pokemonId = SpeciesFactory.GetPokemonIdByConstantName(speciesConstant.Value);
                var indexLearnset = learnsetsPerLine.IndexOf($"static const struct LevelUpMove {learnsetConstant.Value}[] = {{");

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
