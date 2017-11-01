namespace Bowling.Domain
{
    public class Game
    {
        public Game()
        {
            _currentRoll = 0;
        }

        private readonly int[] _rolls = new int[21];
        private int _currentRoll;
        private int _score;

        public void Bowled(int pins)
        {
            _rolls[_currentRoll] = pins;
            _currentRoll++;
        }

        public int Score()
        {
            _score = 0;
            var rollIndex = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    _score += 10;
                    AddStrikeBonus(rollIndex);
                    rollIndex = MoveToNextFrame(rollIndex);
                    continue;
                }

                if (IsSpare(rollIndex))
                {
                    _score += 10;
                    AddSpareBonus(rollIndex);
                    rollIndex = MoveToNextFrame(rollIndex);
                    continue;
                }

                _score += CalculateFrameScore(rollIndex);
                rollIndex = MoveToNextFrame(rollIndex);
            }

            return _score;
        }

        private int MoveToNextFrame(int rollIndex)
        {
            if (IsStrike(rollIndex))
            {
                return rollIndex + 1;
            }
            else
            {
                return rollIndex + 2;
            }
        }

        private int CalculateFrameScore(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex + 1];
        }

        private void AddSpareBonus(int rollIndex)
        {
            _score += _rolls[rollIndex + 2];
        }

        private void AddStrikeBonus(int rollIndex)
        {
            _score += _rolls[rollIndex + 1];
            _score += _rolls[rollIndex + 2];
        }

        private bool IsSpare(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex + 1] == 10;
        }

        private bool IsStrike(int rollIndex)
        {
            return _rolls[rollIndex] == 10;
        }
    }
}