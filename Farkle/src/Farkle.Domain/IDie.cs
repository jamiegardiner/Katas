namespace Farkle.Domain
{
    public interface IDie
    {
        bool HasBeenRolled { get; }
        int? CurrentResult { get; }
        IRollResult Roll();
    }
}