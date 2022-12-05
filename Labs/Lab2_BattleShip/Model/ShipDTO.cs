using Labs.Lab2_BattleShip.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2_BattleShip.Model
{
    class ShipDTO
    {
        public ShipDTO()
        {
        }

        public int Size { get; set;  }

        public Direction Direction { get; set; }

        public PointDTO Position { get; set; } 
    }
}
