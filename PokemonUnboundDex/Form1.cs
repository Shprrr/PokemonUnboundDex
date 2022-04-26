using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PokemonUnboundDex.Factories;
using PokemonUnboundDex.Models;

namespace PokemonUnboundDex
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<int, Pokemon> pokemons;
        private readonly Dictionary<int, Learnset[]> learnsets;

        public SpeciesFactory SpeciesFactory { get; } = new SpeciesFactory();
        public MovesFactory MovesFactory { get; } = new MovesFactory();

        public Form1()
        {
            InitializeComponent();
            pokemons = new PokemonsFactory(SpeciesFactory).GetPokemons().ToDictionary(l => l.PokemonId, l => l);
            learnsets = new LearnsetsFactory(SpeciesFactory, MovesFactory).GetLearnsets().GroupBy(l => l.PokemonId).ToDictionary(l => l.Key, l => l.ToArray());
        }

        private void rbSearchPokemon_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSearchType();
        }

        private void ChangeSearchType()
        {
            if (rbSearchPokemon.Checked)
            {
                cboSearch.DataSource = SpeciesFactory.GetAllSpecies();
            }
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            panSearch.Controls.Clear();

            var pokemonId = SpeciesFactory.GetPokemonIdByConstantName((string)cboSearch.SelectedItem);
            if (!pokemons.ContainsKey(pokemonId)) return;

            var control = new PokemonSummary(this, pokemons[pokemonId], learnsets[pokemonId])
            {
                Dock = DockStyle.Fill
            };
            panSearch.Controls.Add(control);
        }
    }
}
