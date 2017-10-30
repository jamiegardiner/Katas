namespace Farkle.Domain
{
    public class Die : IDie
    {
        public IRollResult Roll()
        {
            return new RollResult();
        }
    }

    public class RollResult : IRollResult
    {
        public int Result { get; }
    }
}