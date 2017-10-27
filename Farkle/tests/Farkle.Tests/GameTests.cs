using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Farkle.Tests
{
    [TestFixture]
    public class GameTests
    {
        private int[] _diceRolled;
        private Game _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new Game();
        }

        [Test]
        public void Should_Return_Result_After_Roll()
        {
            var classUnderTest = new Game();
            Assert.That(classUnderTest.Roll(new[] { 1, 2, 3, 4, 5, 6 }), Is.InstanceOf<IResult>());
        }

        [Test]
        public void Should_Pass_Dice_To_Each_Scoring_Rule_On_Roll()
        {
            _classUnderTest = new Game();

            var rule1 = new Mock<IScoringRule>();
            var rule2 = new Mock<IScoringRule>();
            _diceRolled = new[] { 1, 2, 3, 4, 5, 6 };

            _classUnderTest.AddScoringRule(rule1.Object);
            _classUnderTest.AddScoringRule(rule2.Object);

            _classUnderTest.Roll(_diceRolled);

            rule1.Verify(x => x.Calculate(_diceRolled));
            rule2.Verify(x => x.Calculate(_diceRolled));
        }
    }

    public class Result : IResult
    {
    }

    public interface IScoringRule
    {
        IResult Calculate(IEnumerable<int> diceRolled);
    }

    public interface IResult
    {
    }

    public class Game
    {
        private readonly List<IScoringRule> _scoringRules;

        public Game()
        {
            _scoringRules = new List<IScoringRule>();
        }

        public IResult Roll(int[] diceRolled)
        {
            foreach (var scoringRule in _scoringRules)
            {
                scoringRule.Calculate(diceRolled);
            }
            return new CombinedResult();
        }

        public void AddScoringRule(IScoringRule rule)
        {
            _scoringRules.Add(rule);
        }
    }

    public class CombinedResult : IResult
    {
    }
}