using Labs.Lab2_BattleShip.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2_BattleShip.Model
{
    class PlayerDTO
    {
        public PlayerDTO(Player player)
        {
            Name = player.Name;
            Field = new FieldDTO(player.Field);
        }

        public PlayerDTO()
        {
        }

        public string Name { get; set; }
        public FieldDTO Field { get; set; }

        public Player GetPlayer()
        {
            return new Player(Name, Field.GetField());
        } 
    }
}
