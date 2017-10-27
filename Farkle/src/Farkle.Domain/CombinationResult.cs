namespace Farkle.Domain
{
    public class CombinationResult
    {
        public CombinationResult(int total, int remainder)
        {
            Total = total;
            Remainder = remainder;
        }

        public int Total { get; }
        public int Remainder { get; }
    }
}