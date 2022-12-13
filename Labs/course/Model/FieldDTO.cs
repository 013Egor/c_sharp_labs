using Labs.Lab2_BattleShip.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2_BattleShip.Model
{
    class FieldDTO
    {
        public List<ShipDTO> savedShips;
        public List<PointDTO> savedShots;
        public int Width { get; set; }
        public int Height { get; set; }
        public FieldDTO()
        {
        }

        public FieldDTO(Field field)
        {
            savedShips = new List<ShipDTO>();
            savedShots = new List<PointDTO>();
            foreach(Ship ship in field.savedShips)
            {
                ShipDTO temp = new ShipDTO();
                temp.Direction = ship.Direction;
                temp.Position = new PointDTO(ship.Position);
                temp.Size = ship.Size;
                savedShips.Add(temp);
            }

            foreach (Point point in field.savedShots)
            {
                PointDTO temp = new PointDTO(point);
                savedShots.Add(temp);
            }

            Width = field.Width;
            Height = field.Height;
        }

        public Field GetField()
        {
            List<Ship> ships = new List<Ship>();
            List<Point> shots = new List<Point>();
            foreach (ShipDTO ship in savedShips)
            {
                Ship temp = new Ship(ship.Size);
                temp.Direction = ship.Direction;
                temp.Position = new Point(ship.Position.X, ship.Position.Y);
                ships.Add(temp);
            }
            foreach (PointDTO point in savedShots)
            {
                Point temp = new Point(point.X, point.Y);
                shots.Add(temp);
            }
            return new Field(Width, Height, ships, shots);
        }

        public LinkedList<Ship> getSavedShips()
        {
            LinkedList<Ship> ships = new LinkedList<Ship>();
            foreach (ShipDTO ship in savedShips)
            {
                Ship temp = new Ship(ship.Size);
                temp.Direction = ship.Direction;
                temp.Position = new Point(ship.Position.X, ship.Position.Y);
                ships.AddLast(temp);
            }
            return ships;
        }

        public LinkedList<Point> getSavedShots()
        {
            LinkedList<Point> shots = new LinkedList<Point>();
            
            foreach (PointDTO point in savedShots)
            {
                Point temp = new Point(point.X, point.Y);
                shots.AddLast(temp);
            }

            return shots;
        }
    }
}
