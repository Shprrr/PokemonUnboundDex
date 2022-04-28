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
                cboSearch.DisplayMember = "Display";
                cboSearch.ValueMember = "Value";
                cboSearch.DataSource = SpeciesFactory.GetAllSpecies()
                    .Join(pokemons, s => SpeciesFactory.GetPokemonIdByConstantName(s), p => p.Key, (s, p) => new { Display = p.Value.Name, Value = p.Key }).ToList();
            }
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            panSearch.Controls.Clear();

            var pokemonId = (int)cboSearch.SelectedValue;
            pokemons.TryGetValue(pokemonId, out var pokemon);
            learnsets.TryGetValue(pokemonId, out var learnset);

            var control = new PokemonSummary(this, pokemon, learnset)
            {
                Dock = DockStyle.Fill
            };
            panSearch.Controls.Add(control);
        }
    }
}
