using System.Collections.Generic;

namespace Farkle.Domain
{
    public interface IScoringRule
    {
        IResult Calculate(IEnumerable<int> diceRolled);
    }
}