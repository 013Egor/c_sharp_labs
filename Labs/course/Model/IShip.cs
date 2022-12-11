using System.Collections.Generic;

namespace Labs.Lab2_BattleShip.Domain
{
    public interface IShip
    {
        Direction Direction { get; }
        Point? Position { get; }
        int Size { get; }

        IReadOnlyList<Point> GetPositionPoints();
    }
}