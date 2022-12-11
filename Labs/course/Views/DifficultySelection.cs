using System;
using System.Windows.Forms;
using Labs.Lab2_BattleShip.Domain;
using Labs.Lab2_BattleShip.Model;
using Newtonsoft.Json;

namespace Labs.Lab2_BattleShip.Views
{
    public partial class DifficultySelection : UserControl
    {
        private Game game;

        public DifficultySelection()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;
            this.game = game;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.level = false;
            game.Start("Human", "AI");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.level = true;
            game.Start("Human", "AI");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            game.goStartScreen();
        }
    }
}
