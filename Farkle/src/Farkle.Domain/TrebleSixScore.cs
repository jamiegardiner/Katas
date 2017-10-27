using System.Collections.Generic;
using System.Linq;

namespace Farkle.Domain
{
    public class TrebleSixScore
    {
        private int _requiredTreble;
        private int _giveScore;

        public CombinationResult Calculate(IEnumerable<int> ints)
        {
            var results = ints as int[] ?? ints.ToArray();
            _requiredTreble = 6;
            _giveScore = 600;
            return results.Count(x => x == _requiredTreble) == 3 
                ? new CombinationResult(_giveScore, results.Length - 3) 
                : new CombinationResult(0, results.Length);
        }
    }
}