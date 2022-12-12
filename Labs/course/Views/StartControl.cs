using System;
using System.Windows.Forms;
using Labs.Lab2_BattleShip.Domain;
using Labs.Lab2_BattleShip.Model;
using Newtonsoft.Json;
using Labs.Lab_4;
using System.Text.RegularExpressions;

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
            MatchCollection matchCollection = Class1.FindFile(filename);
            if (matchCollection.Count != 1)
            {
                MessageBox.Show("Файл сохраненной игры был поврежден.");
                return;
            }
            string logFileName = filename.Remove(0, matchCollection[0].Index + 12);
            
            if (!System.IO.File.Exists(logFileName))
            {
                MessageBox.Show("Не могу найти лог-файл. Пожалуйста, создайте новую игру.");
                return;
            }

            string fileText = System.IO.File.ReadAllText(filename);
            string logFileText = System.IO.File.ReadAllText(logFileName);
            try
            {
                if (fileText.Contains("\n") || fileText.Contains(" "))
                {
                    throw new Exception();
                }
                GameDTO gameDto = JsonConvert.DeserializeObject<GameDTO>(fileText);
                game.Continue(gameDto.GetGame(), logFileText);
            } catch (Exception exc)
            {
                MessageBox.Show("Файл был поврежден. Загрузка созраненной игры из данного файла невозможна.");
            }
           
        }
    }
}
