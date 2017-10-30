using Farkle.Domain;
using Moq;
using NUnit.Framework;

namespace Farkle.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game _classUnderTest;
        private Mock<IScoringCalculator> _mockScoringCalculator;

        [SetUp]
        public void SetUp()
        {
            _mockScoringCalculator = new Mock<IScoringCalculator>();
            _classUnderTest = new Game(_mockScoringCalculator.Object);
        }

        [Test]
        public void Should_Roll_Correct_Number_Of_Dice()
        {
            var die1 = new Mock<IDie>();
            var die2 = new Mock<IDie>();

            _classUnderTest.Roll(new[] { die1.Object, die2.Object });

            die1.Verify(x => x.Roll());
            die1.Verify(x => x.Roll());
        }

        [Test]
        public void Should_Passed_Dice_To_Score_Calculator()
        {
            var die1 = new Mock<IDie>();
            var die2 = new Mock<IDie>();

            _classUnderTest.Roll(new[] { die1.Object, die2.Object });

            _mockScoringCalculator.Verify(x => x.Calculate(new[] { die1.Object, die2.Object }));
        }
    }
}