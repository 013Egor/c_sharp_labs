namespace Labs.Lab2_BattleShip.Domain
{
    public interface IPlayer
    {
        string Name { get; }
        IField Field { get; }
    }
}
