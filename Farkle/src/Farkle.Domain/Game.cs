namespace Farkle.Domain
{
    public class Game
    {
        private readonly IScoringCalculator _scoringCalculator;

        public Game(IScoringCalculator scoringCalculator)
        {
            _scoringCalculator = scoringCalculator;
        }

        public IResult Roll(IDie[] dice)
        {
            foreach (var die in dice)
            {
                die.Roll();
            }

            _scoringCalculator.Calculate(dice);
            return new CombinedResult();
        }
    }
}