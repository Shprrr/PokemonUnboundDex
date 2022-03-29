namespace PokemonUnboundDex.Models
{
    public class Learnset
    {
        private const int LearnByEvolutionLevel = 0;

        public int PokemonId { get; set; }
        public int Level { get; set; }
        public bool ByEvolution => Level == LearnByEvolutionLevel;
        public int MoveId { get; set; }
    }
}
