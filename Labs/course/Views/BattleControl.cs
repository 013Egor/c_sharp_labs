using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Labs.Lab2_BattleShip.AI;
using Labs.Lab2_BattleShip.Domain;
using Labs.Lab2_BattleShip.Model;
using Newtonsoft.Json;

namespace Labs.Lab2_BattleShip.Views
{
    public partial class BattleControl : UserControl
    {
        private Game game;

        public BattleControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            panel1.Height = 54;
            if (this.game != null)
                return;
            this.game = game;

            humanFieldControl.Configure(game.FirstPlayer.Field, false);
            aiFieldControl.Configure(game.SecondPlayer.Field, true);

            aiFieldControl.ClickOnPoint += HumanFieldControl_ClickOnPoint;

            game.ReadyToShoot += Game_ReadyToShoot;
        }

        private void HumanFieldControl_ClickOnPoint(Point point, MouseEventArgs args)
        {
            try
            {
                if (args.Button == MouseButtons.Left)
                {
                    if (game.CurrentPlayer.Equals(game.FirstPlayer))
                        game.ShootTo(point);
                }
            } catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private void Game_ReadyToShoot()
        {
            var humanPlayer = game.FirstPlayer;
            var aiPlayer = game.SecondPlayer;
            if (game.Stage == GameStage.Battle && game.CurrentPlayer.Equals(aiPlayer))
            {
                Point shot;
                if (game.level)
                {
                    shot = humanPlayer.Field.GenerateShot();
                }
                else
                {
                    shot = humanPlayer.Field.GenerateRandomShot();
                }

                game.ShootTo(shot);
            }
        }

        
        private string getFilename()
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return null;

            return saveFileDialog1.FileName.Replace(".txt", "");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            game.firstPlayer.clearField();
            game.secondPlayer.clearField();

            game.goStartScreen();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game.firstPlayer.Field.GetShipsList();
            game.firstPlayer.Field.GetShotsList();
            game.secondPlayer.Field.GetShotsList();
            game.secondPlayer.Field.GetShipsList();
            string jsonString = JsonConvert.SerializeObject(new GameDTO(game));
            string filename = "game_log_" + DateTime.Now.ToShortDateString() + "T" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".txt";

            string temp = textBox1.Text;
            try
            {
                System.IO.File.WriteAllText(temp + "_savedGame_" + filename, jsonString);
                System.IO.File.WriteAllText(filename, game.battleLog);
                MessageBox.Show("Файл сохранен");
            } catch (Exception exc)
            {
                MessageBox.Show("Файл не сохранен");
            }
            finally
            {
                panel1.Height = 54;
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            panel1.Height = 155;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Height = 54;
        }
    }
}
