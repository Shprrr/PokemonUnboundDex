﻿using System.Data;
using System.Linq;
using System.Windows.Forms;
using PokemonUnboundDex.Factories;
using PokemonUnboundDex.Models;

namespace PokemonUnboundDex
{
    public partial class PokemonSummary : UserControl
    {
        public PokemonSummary(Form1 parent, Pokemon pokemon, Learnset[] learnsets)
        {
            InitializeComponent();
            Pokemon = pokemon;
            Learnsets = learnsets;
            MovesFactory = parent.MovesFactory;

            lblAbility1.Text = Pokemon.Ability1;
            lblAbility2.Text = Pokemon.Ability2;
            lblHiddenAbility.Text = Pokemon.HiddenAbility;
            listView.Items.AddRange(Learnsets.Select(ToListViewItem).ToArray());
        }

        public Pokemon Pokemon { get; }
        public Learnset[] Learnsets { get; }
        public MovesFactory MovesFactory { get; }

        private ListViewItem ToListViewItem(Learnset learnset)
        {
            ListViewItem listViewItem = new(new[] { learnset.Level.ToString(), MovesFactory.GetMoveById(learnset.MoveId).MoveName });

            return listViewItem;
        }
    }
}