using System;
using System.Windows.Forms;
using Labs.Lab2_BattleShip.Domain;
using Labs.Lab2_BattleShip.Model;
using Newtonsoft.Json;
using Labs.Lab_4;

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
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            game.chooseDifficult();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openFileDialog1.FileName;
            if (Class1.FindFile(filename).Count != 1)
            {
                MessageBox.Show("Wrong input file");
                return;
            }
            string logFileName = filename.Replace("savedGame_", "");
            if (!System.IO.File.Exists(logFileName))
            {
                MessageBox.Show("Cannot find log file. Please, create new game");
                return;
            }

            string fileText = System.IO.File.ReadAllText(filename);
            string logFileText = System.IO.File.ReadAllText(logFileName);
            GameDTO gameDto = JsonConvert.DeserializeObject<GameDTO>(fileText);
            game.Continue(gameDto.GetGame(), logFileText);
        }
    }
}
