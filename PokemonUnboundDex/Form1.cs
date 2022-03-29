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
        private readonly Dictionary<int, Learnset[]> learnsets;

        public SpeciesFactory SpeciesFactory { get; } = new SpeciesFactory();
        public MovesFactory MovesFactory { get; } = new MovesFactory();

        public Form1()
        {
            InitializeComponent();
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
            ListView listView = new();
            listView.Dock = DockStyle.Fill;
            listView.Columns.Add("Level", 40, HorizontalAlignment.Right);
            listView.Columns.Add("Move", 200);
            listView.View = View.Details;

            var pokemonId = SpeciesFactory.GetPokemonIdByConstantName((string)cboSearch.SelectedItem);
            if (learnsets.TryGetValue(pokemonId, out var dataSource))
                listView.Items.AddRange(dataSource.Select(ToListViewItem).ToArray());
            panSearch.Controls.Add(listView);
        }

        private ListViewItem ToListViewItem(Learnset learnset)
        {
            ListViewItem listViewItem = new(new[] { learnset.Level.ToString(), MovesFactory.GetMoveById(learnset.MoveId).MoveName });

            return listViewItem;
        }
    }
}
