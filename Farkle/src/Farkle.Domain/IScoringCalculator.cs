namespace Farkle.Domain
{
    public interface IScoringCalculator
    {
        void Calculate(IDie[] dice);
    }

    public class DefaultRulesScoringCalculator : IScoringCalculator
    {
        public void Calculate(IDie[] dice)
        {
            foreach (var die in dice)
            {
                
            }
        }
    }
}