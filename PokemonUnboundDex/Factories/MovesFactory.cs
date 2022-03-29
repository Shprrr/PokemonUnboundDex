using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using PokemonUnboundDex.Models;

namespace PokemonUnboundDex.Factories
{
    public class MovesFactory
    {
        private static readonly Dictionary<string, int> movesByName = new();
        private static readonly List<Move> moves = new();

        static MovesFactory()
        {
            LoadDefineMoves();
            LoadMoves();
        }

        private static void LoadDefineMoves()
        {
            movesByName.Clear();
            using var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PokemonUnboundDex.Resources.moves.h");
            using StreamReader movesStream = new(resourceStream);

            List<string> movesPerLine = new();

            while (!movesStream.EndOfStream)
            {
                movesPerLine.Add(movesStream.ReadLine());
            }

            Regex moveRegex = new(@"#define (?<move>MOVE_\w+) 0x(?<id>\w+)");
            for (int i = 0; i < movesPerLine.Count; i++)
            {
                Match moveMatch = moveRegex.Match(movesPerLine[i].Trim());
                if (!moveMatch.Success) continue;
                movesByName.Add(moveMatch.Groups["move"].Value, int.Parse(moveMatch.Groups["id"].Value, NumberStyles.HexNumber));
            }
        }

        private static void LoadMoves()
        {
            moves.Clear();
            using var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PokemonUnboundDex.Resources.attack_name_table.string");
            using StreamReader movesStream = new(resourceStream);

            List<string> movesPerLine = new();

            while (!movesStream.EndOfStream)
            {
                movesPerLine.Add(movesStream.ReadLine());
            }

            Regex moveRegex = new(@"#org @NAME_\w+");
            for (int i = 0; i < movesPerLine.Count; i++)
            {
                Match moveMatch = moveRegex.Match(movesPerLine[i].Trim());
                if (!moveMatch.Success) continue;
                moves.Add(new Move { MoveId = moves.Count, MoveName = movesPerLine[i + 1].Trim() });
                i++;
            }
        }

        public bool IsMove(string name) => movesByName.ContainsKey(name);

        public int GetMoveIdByConstantName(string name) => movesByName[name];

        public Move GetMoveById(int id) => moves[id];
    }
}
