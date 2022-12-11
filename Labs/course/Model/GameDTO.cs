using Labs.Lab2_BattleShip.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2_BattleShip.Model
{
    class GameDTO
    {
        public GameStage stage { get; set; }
        public PlayerDTO firstPlayer { get; set; }
        public PlayerDTO secondPlayer { get; set; }
        public bool isFirstPlayerCurrent { get; set; }
        public GameOptions options { get; set; }
        public bool level { get; set; }
        public GameDTO(Game game)
        {
            this.stage = game.stage;
            this.firstPlayer = new PlayerDTO(game.firstPlayer);
            this.secondPlayer = new PlayerDTO(game.secondPlayer);
            this.isFirstPlayerCurrent = game.isFirstPlayerCurrent;
            this.options = game.options;
            this.level = game.level;
        }

        public GameDTO() { }

        public Game GetGame()
        {
            return new Game(stage, firstPlayer.GetPlayer(), secondPlayer.GetPlayer(), isFirstPlayerCurrent, options, level);
        }
    }
}
