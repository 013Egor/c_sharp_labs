using Labs.Lab2_BattleShip.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2_BattleShip.Model
{
    class PointDTO
    {
        public PointDTO()
        {
        }

        public PointDTO(Point? point)
        {
            X = point.Value.X;
            Y = point.Value.Y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
