using System.Windows.Forms;
using Labs.Lab2_BattleShip.Domain;
using System.Drawing;

namespace Labs.Lab2_BattleShip.Views
{
    public partial class FinishedControl : UserControl
    {
        private Game game;

        public FinishedControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;

            humanFieldControl.Configure(game.FirstPlayer.Field, false);
            aiFieldControl.Configure(game.SecondPlayer.Field, false);

            if (game.FirstPlayer.Field.HasAliveShips())
            {
                winnerLabel.BackColor = Color.Green;
                winnerLabel.Text = "Победил человек";
            }
            else
            {
                winnerLabel.BackColor = Color.Red;
                winnerLabel.Text = "Победил Компуктер!!!";
            }
        }
    }
}
