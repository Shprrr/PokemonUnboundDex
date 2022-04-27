using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using PokemonUnboundDex.Resources;

namespace PokemonUnboundDex.Factories
{
    public class SpeciesFactory
    {
        private static readonly Dictionary<string, int> speciesByName = new();

        static SpeciesFactory()
        {
            LoadSpecies();
        }

        private static void LoadSpecies()
        {
            speciesByName.Clear();
            var speciesPerLine = ResourceReader.ReadResourcePerLine("PokemonUnboundDex.Resources.species.h");

            Regex speciesRegex = new(@"#define (?<species>SPECIES_\w+) 0x(?<id>\w+)");
            for (int i = 0; i < speciesPerLine.Length; i++)
            {
                var speciesMatch = speciesRegex.Match(speciesPerLine[i].Trim());
                if (!speciesMatch.Success) continue;
                speciesByName.Add(speciesMatch.Groups["species"].Value, int.Parse(speciesMatch.Groups["id"].Value, NumberStyles.HexNumber));
            }
        }

        public string[] GetAllSpecies() => speciesByName.Keys.ToArray();

        public bool IsSpecies(string name) => speciesByName.ContainsKey(name);

        public int GetPokemonIdByConstantName(string name) => speciesByName[name];
    }
}
