using System.Collections.Generic;
using System;
using System.Linq;

namespace Labs.Lab2_BattleShip.Domain
{
    public class Game
    {
        public string battleLog = "";
        public GameStage stage = GameStage.NotStarted;
        public Player firstPlayer = null;
        public Player secondPlayer = null;
        public bool isFirstPlayerCurrent = false;
        public GameOptions options = new GameOptions();
        public bool level { set; get; }
        public Game(Action<GameOptions> configureOptions = null)
        {
            configureOptions?.Invoke(options);
        }

        public Game(GameStage stage, Player firstPlayer, Player secondPlayer, bool isFirstPlayerCurrent, GameOptions options, bool level)
        {
            this.level = level;
            this.stage = stage;
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            this.isFirstPlayerCurrent = isFirstPlayerCurrent;
            this.options = options;
        }

        public GameStage Stage => stage;
        public event Action<GameStage> StageChanged;

        public IPlayer FirstPlayer => firstPlayer;
        public IPlayer SecondPlayer => secondPlayer;
        public IPlayer CurrentPlayer => isFirstPlayerCurrent ? firstPlayer : secondPlayer;
        public event Action<IPlayer> CurrentPlayerChanged;

        public event Action ReadyToShoot;

        public void chooseDifficult()
        {
            ChangeStage(GameStage.DifficultySelection);
        }

        public void goStartScreen()
        {
            ChangeStage(GameStage.NotStarted);
        }
        public void goDifficultSelection()
        {
            ChangeStage(GameStage.DifficultySelection);
        }
        public void Start(string firstPlayerName, string secondPlayerName)
        {
            if (firstPlayer != null && secondPlayer != null)
            {
                ChangeStage(GameStage.ArrangingShips);
                return;
            }
            firstPlayer = CreatePlayer(firstPlayerName);
            secondPlayer = CreatePlayer(secondPlayerName);
            isFirstPlayerCurrent = true;
            CurrentPlayerChanged?.Invoke(CurrentPlayer);
            ChangeStage(GameStage.ArrangingShips);
        }

        public void Continue(Game game, string log)
        {
            firstPlayer = game.firstPlayer;
            secondPlayer = game.secondPlayer;
            isFirstPlayerCurrent = game.isFirstPlayerCurrent;
            battleLog = log;
            isFirstPlayerCurrent = true;
            CurrentPlayerChanged?.Invoke(CurrentPlayer);
            ChangeStage(GameStage.Battle);
        }

        public bool CanEndArrangingCurrentPlayerShips =>
            Stage == GameStage.ArrangingShips && IsReadyForBattle(CurrentPlayer);

        public void EndArrangingCurrentPlayerShips()
        {
            if (!CanEndArrangingCurrentPlayerShips)
                return;

            if (!CanBeginBattle)
            {
                MoveToNextPlayer();
                return;
            }

            MoveToNextPlayer();
            ChangeStage(GameStage.Battle);
        }

        public bool CanBeginBattle =>
            Stage == GameStage.ArrangingShips
            && IsReadyForBattle(FirstPlayer) && IsReadyForBattle(SecondPlayer);

        public void ShootTo(Point point)
        {
            if (Stage != GameStage.Battle)
                throw new InvalidOperationException();

            var shotResult = GetNextPlayer().Field.ShootTo(point);
            battleLog += CurrentPlayer.Name + " shoots to " + point.X + " " + point.Y;
            switch (shotResult)
            {
                case ShotResult.Hit:
                    battleLog += " result: Hit\n";
                    if (IsCurrentPlayerWin())
                        ChangeStage(GameStage.Finished);
                    else
                        ReadyToShoot?.Invoke();
                    return;
                case ShotResult.Miss:
                    battleLog += " result: Miss\n";
                    MoveToNextPlayer();
                    ReadyToShoot?.Invoke();
                    return;
                case ShotResult.Cancel:
                    return;
                default:
                    throw new InvalidOperationException();
            }
        }

        private Player CreatePlayer(string name)
        {
            var field = options.CreateField();
            foreach (var ship in options.CreateFleet())
                field.AddShip(ship);
            return new Player(name, field);
        }

        private void ChangeStage(GameStage stage)
        {
            this.stage = stage;
            StageChanged?.Invoke(stage);
        }

        public Player GetNextPlayer() => isFirstPlayerCurrent ? secondPlayer : firstPlayer;

        private void MoveToNextPlayer()
        {
            isFirstPlayerCurrent = !isFirstPlayerCurrent;
            CurrentPlayerChanged?.Invoke(CurrentPlayer);
        }

        private static bool IsReadyForBattle(IPlayer player)
        {
            IShip tempShip = player.Field.GetShipToPutOrNull();
            ISet<Point>temp = player.Field.GetConflictingPoints();
            return tempShip == null && !temp.Any();
        }

        private bool IsCurrentPlayerWin()
        {
            var nextPlayer = GetNextPlayer();
            return nextPlayer != null
                ? !nextPlayer.Field.HasAliveShips()
                : false;
        }
    }
}
