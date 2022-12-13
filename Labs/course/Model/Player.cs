using System.Collections.Generic;

namespace Labs.Lab2_BattleShip.Domain
{
    public class Player : IPlayer
    {
        public Player(string name, Field field)
        {
            Name = name;
            Field = field;
        }

        public string Name { get; }
        public Field Field { get; }

        IField IPlayer.Field => Field;

        public void clearField()
        {
             this.Field.clearField();
        }

        public void setField(LinkedList<Ship> newShips, LinkedList<Point> newShots)
        {
            this.Field.setField(newShips, newShots);
        }
        public override string ToString() => $"Player {Name}";
    }
}
