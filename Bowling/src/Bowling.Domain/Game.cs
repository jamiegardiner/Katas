using System.Collections.Generic;
using System.Linq;

namespace Bowling.Domain
{
    public class Game
    {
        public Game()
        {
            _currentRoll = 0;
        }

        private readonly int[] _rolls = new int[21];
        private IList<Frame> _frames = new List<Frame>();
        private int _currentRoll;
        private const int NumberOfPins = 10;
        private const int NumberOfFrames = 10;

        public void Bowled(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            _frames = CalculateFrames();
            return _frames.Sum(x => x.FrameScore());
        }

        private List<Frame> CalculateFrames()
        {
            var frames = new List<Frame>();
            var rollCounter = new RollCounter(2, 0);
            for (int i = 0; i < NumberOfFrames; i++)
            {
                if (IsStrike(rollCounter))
                    frames.Add(new Strike(rollCounter.Index, _rolls));
                else if (IsSpare(rollCounter))
                    frames.Add(new Spare(rollCounter.Index, _rolls));
                else
                {
                    frames.Add(new Frame(rollCounter.Index, _rolls));
                }

                rollCounter = rollCounter.IncreaseRollIndex(IsStrike(rollCounter));
            }
            return frames;
        }

        private bool IsSpare(RollCounter rollIndex)
        {
            return _rolls[rollIndex.Index] + _rolls[rollIndex.Index + 1] == NumberOfPins;
        }

        private bool IsStrike(RollCounter rollCounter)
        {
            return _rolls[rollCounter.Index] == NumberOfPins;
        }
    }
}