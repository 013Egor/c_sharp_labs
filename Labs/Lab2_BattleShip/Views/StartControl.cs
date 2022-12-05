using System;
using System.Windows.Forms;
using Labs.Lab2_BattleShip.Domain;
using Labs.Lab2_BattleShip.Model;
using Newtonsoft.Json;

namespace Labs.Lab2_BattleShip.Views
{
    public partial class StartControl : UserControl
    {
        private Game game;

        public StartControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;
            comboBox2.Text = "Легко";
            startButton.Click += StartButton_Click;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            game.level = comboBox2.Text == "Сложно";
            game.Start("Human", "AI");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            GameDTO gameDto = JsonConvert.DeserializeObject<GameDTO>(fileText);
            game.Continue(gameDto.GetGame());
        }
    }
}
