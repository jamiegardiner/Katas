namespace Bowling.Domain
{
    public class RollCounter
    {
        private readonly int _numerOfBowlsPerFrame;

        public RollCounter(int numerOfBowlsPerFrame, int currentIndex)
        {
            _numerOfBowlsPerFrame = numerOfBowlsPerFrame;
            Index = currentIndex;
        }

        public int Index { get; }

        public RollCounter IncreaseRollIndex(bool strike)
        {
            var increaseBy = strike ? 1 : _numerOfBowlsPerFrame;
            return new RollCounter(_numerOfBowlsPerFrame, Index + increaseBy);
        }
    }
}