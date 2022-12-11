using System;
using System.Windows.Forms;
using Labs.Lab2_BattleShip.Domain;

namespace Labs.Lab2_BattleShip.Views
{
    public partial class MainForm : Form
    {
        private Game game;

        public MainForm()
        {
            InitializeComponent();
            game = new Game();
            game.StageChanged += Game_OnStageChanged;

            ShowStartScreen();
        }

        private void Game_OnStageChanged(GameStage stage)
        {
            switch (stage)
            {
                case GameStage.DifficultySelection:
                    ShowDifficultySelection();
                    break;
                case GameStage.ArrangingShips:
                    ShowArrangingShipsScreen();
                    break;
                case GameStage.Battle:
                    ShowBattleScreen();
                    break;
                case GameStage.Finished:
                    ShowFinishedScreen();
                    break;
                case GameStage.NotStarted:
                default:
                    ShowStartScreen();
                    break;
            }
        }

        private void ShowStartScreen()
        {
            HideScreens();
            startControl.Configure(game);
            startControl.Show();
        }
        private void ShowDifficultySelection()
        {
            HideScreens();
            difficultySelection.Configure(game);
            difficultySelection.Show();
        }

        private void ShowArrangingShipsScreen()
        {
            HideScreens();
            arrangingControl.Configure(game);
            arrangingControl.Show();
        }

        private void ShowBattleScreen()
        {
            HideScreens();
            battleControl.Configure(game);
            battleControl.Show();
        }

        private void ShowFinishedScreen()
        {
            string filename = "game_log_" + DateTime.Now.ToShortDateString() + "T" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".txt";
            System.IO.File.WriteAllText(filename, game.battleLog);
            HideScreens();
            finishedControl.Configure(game);
            finishedControl.Show();
        }

        private void HideScreens()
        {
            startControl.Hide();
            difficultySelection.Hide();
            arrangingControl.Hide();
            battleControl.Hide();
            finishedControl.Hide();
        }
    }
}
