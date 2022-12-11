using System;
using System.Collections.Generic;
using System.Linq;

namespace Labs.Lab2_BattleShip.Domain
{
    public class Field : IField
    {
        private readonly HashSet<Ship> ships = new HashSet<Ship>();
        private readonly HashSet<Point> shots = new HashSet<Point>();

        public List<Ship> savedShips = new List<Ship>();
        public List<Point> savedShots = new List<Point>();

        public Ship currentShip = null;

        public void clearField()
        {
            foreach (Ship ship in ships)
            {
                ship.Direction = Direction.Horizontal;
                ship.Position = null;
            }
            this.shots.Clear();
            this.savedShips.Clear();
            this.savedShots.Clear();
            this.currentShip = null;
        }
        public Field(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Field(int width, int height, List<Ship> ships, List<Point> shots)
        {
            this.ships = ships.ToHashSet();
            this.shots = shots.ToHashSet();
            Width = width;
            Height = height;
        }

        public Field() { }

        public event Action Updated;

        public int Width { get; }
        public int Height { get; }

        public void AddShip(Ship ship)
        {
            ships.Add(ship);
            Updated?.Invoke();
        }

        public IReadOnlyList<IShip> GetShips()
        {
            return ships.ToList();
        }

        public IShip GetShipToPutOrNull()
        {
            IEnumerable<Ship> t = ships.Where(ship => !ship.Position.HasValue);
            return t.OrderByDescending(ship => ship.Size)
                .FirstOrDefault();
        }

        public bool PutShip(IShip ship, Point point)
        {
            if (!ships.Contains(ship))
                throw new InvalidOperationException();
            var actualShip = ship as Ship;

            var dx = 1;
            var dy = 1;
            if (ship.Direction == Direction.Horizontal)
                dx = actualShip.Size;
            else
                dy = actualShip.Size;

            if (0 <= point.X && point.X + dx <= Width
                && 0 <= point.Y && point.Y + dy <= Height)
            {
                actualShip.Position = point;
                Updated?.Invoke();
                return true;
            }
            actualShip.Position = null;
            Updated?.Invoke();
            return false;
        }

        public IReadOnlyList<IShip> GetShipsAt(Point point)
        {
            var result = ships
                .Where(ship => ship.GetPositionPoints().Contains(point))
                .OrderBy(ship => ship.Size)
                .ToList();
            return result;
        }

        public bool ChangeShipDirection(IShip ship)
        {
            if (!ships.Contains(ship))
                throw new InvalidOperationException();
            var actualShip = ship as Ship;

            if (!actualShip.Position.HasValue)
                return false;

            var position = actualShip.Position.Value;
            if (actualShip.Direction == Direction.Horizontal)
            {
                var overflow = position.Y + ship.Size - Height;
                if (overflow > 0)
                {
                    var newPosition = new Point(position.X, position.Y - overflow);
                    if (newPosition.Y < 0)
                    {
                        actualShip.Position = null;
                        Updated?.Invoke();
                        return false;
                    }

                    actualShip.Position = newPosition;
                }
                actualShip.Direction = Direction.Vertical;
            }
            else
            {
                var overflow = position.X + ship.Size - Width;
                if (overflow > 0)
                {
                    var newPosition = new Point(position.X - overflow, position.Y);
                    if (newPosition.X < 0)
                    {
                        actualShip.Position = null;
                        Updated?.Invoke();
                        return false;
                    }

                    actualShip.Position = newPosition;
                }
                actualShip.Direction = Direction.Horizontal;
            }
            Updated?.Invoke();
            return true;
        }

        public ISet<Point> GetConflictingPoints()
        {
            var shipToRoundMap = ships.ToDictionary(ship => ship, GetShipRoundPoints);

            var result = new HashSet<Point>();
            foreach (var ship in ships)
            {
                var positionPoints = ship.GetPositionPoints();
                foreach (var point in positionPoints)
                {
                    var isPointInOtherShipRound = shipToRoundMap
                        .Any(pair => !pair.Key.Equals(ship) && pair.Value.Contains(point));
                    if (isPointInOtherShipRound)
                        result.Add(point);
                }
            }
            return result;
        }

        public ShotResult ShootTo(Point point)
        {
            if (shots.Contains(point))
                return ShotResult.Cancel;

            shots.Add(point);

            currentShip = (Ship) GetShipsAt(point).FirstOrDefault();
            if (currentShip == null)
            {
                Updated?.Invoke();
                return ShotResult.Miss;
            }
            
            var willBlow = currentShip.GetPositionPoints()
                .All(p => shots.Contains(p));

            if (willBlow)
                shots.UnionWith(GetShipRoundPoints(currentShip));

            Updated?.Invoke();
            return ShotResult.Hit;
        }

        private HashSet<Point> GetShipRoundPoints(IShip ship)
        {
            var result = ship.GetPositionPoints()
                .SelectMany(p => p.GetRoundPoints())
                .Where(p => 0 <= p.X && p.X < Width && 0 <= p.Y && p.Y < Height)
                .ToHashSet();
            return result;
        }

        public ISet<Point> GetShots()
        {
            return shots.ToHashSet();
        }

        public bool IsAlive(IShip ship)
        {
            if (!ships.Contains(ship))
                throw new InvalidOperationException();

            return ship.GetPositionPoints().Any(p => !shots.Contains(p));
        }

        public bool HasAliveShips()
        {
            return ships.Any(ship => IsAlive(ship));
        }

        public List<Point> GetShotsList()
        {
            this.savedShots = new List<Point>();
            foreach (Point shot in this.shots)
            {
                this.savedShots.Add(shot);
            }

            return this.savedShots;
        }

        public List<Ship> GetShipsList()
        {
            this.savedShips = new List<Ship>();
            foreach (Ship ship in this.ships)
            {
                this.savedShips.Add(ship);
            }

            return this.savedShips;
        }

        public Ship getCurrentShip()
        {
            return currentShip;
        }

        public List<Point> getAvailableShots(Ship ship)
        {
            return (List<Point>) ship.GetPositionPoints();
        }
    }
}
