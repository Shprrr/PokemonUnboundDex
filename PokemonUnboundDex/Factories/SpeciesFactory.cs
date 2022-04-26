using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

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
            using var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PokemonUnboundDex.Resources.species.h");
            using StreamReader speciesStream = new(resourceStream);

            List<string> speciesPerLine = new();

            while (!speciesStream.EndOfStream)
            {
                speciesPerLine.Add(speciesStream.ReadLine());
            }

            Regex speciesRegex = new(@"#define (?<species>SPECIES_\w+) 0x(?<id>\w+)");
            for (int i = 0; i < speciesPerLine.Count; i++)
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
