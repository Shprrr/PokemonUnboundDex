using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using PokemonUnboundDex.Models;
using PokemonUnboundDex.Resources;

namespace PokemonUnboundDex.Factories
{
    public class AbilitiesFactory
    {
        private static readonly Dictionary<string, int> abilitiesByName = new();
        private static readonly List<Ability> abilities = new();

        static AbilitiesFactory()
        {
            LoadDefineAbilities();
            LoadAbilities();
        }

        private static void LoadDefineAbilities()
        {
            abilitiesByName.Clear();
            var abilitiesPerLine = ResourceReader.ReadResourcePerLine("PokemonUnboundDex.Resources.abilities.h");

            Regex abilityRegex = new(@"#define (?<ability>ABILITY_\w+) 0x(?<id>\w+)");
            for (int i = 0; i < abilitiesPerLine.Length; i++)
            {
                var abilityMatch = abilityRegex.Match(abilitiesPerLine[i].Trim());
                if (!abilityMatch.Success) continue;
                abilitiesByName.Add(abilityMatch.Groups["ability"].Value, int.Parse(abilityMatch.Groups["id"].Value, NumberStyles.HexNumber));
            }
        }

        private static void LoadAbilities()
        {
            abilities.Clear();
            var abilitiesPerLine = ResourceReader.ReadResourcePerLine("PokemonUnboundDex.Resources.ability_name_table.string");

            Regex abilityRegex = new(@"#org @NAME_\w+");
            for (int i = 0; i < abilitiesPerLine.Length; i++)
            {
                var abilityMatch = abilityRegex.Match(abilitiesPerLine[i].Trim());
                if (!abilityMatch.Success) continue;
                abilities.Add(new Ability { AbilityId = abilities.Count, AbilityName = abilitiesPerLine[i + 1].Trim() });
                i++;
            }
        }

        public bool IsAbility(string name) => !string.IsNullOrEmpty(name) && abilitiesByName.ContainsKey(name);

        public int GetAbilityIdByConstantName(string name) => abilitiesByName[name];

        public Ability GetAbilityById(int id) => abilities[id];
    }
}
