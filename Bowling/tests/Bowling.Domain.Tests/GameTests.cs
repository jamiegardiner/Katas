using NUnit.Framework;

namespace Bowling.Domain.Tests
{
    public class GameTests
    {
        private Game _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new Game();
        }

        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public void Should_Calculate_Single_Roll_Score(int pins)
        {
            _classUnderTest.Bowled(pins);

            Assert.That(_classUnderTest.Score(), Is.EqualTo(pins));
        }

        [TestCase(4, 3)]
        [TestCase(6, 2)]
        [TestCase(9, 7)]
        public void Should_Calculate_Score_From_Multiple_Rolls(int pins, int numberOfRolls)
        {
            for (var i = 0; i < numberOfRolls; i++)
                _classUnderTest.Bowled(pins);

            Assert.That(_classUnderTest.Score(), Is.EqualTo(pins * numberOfRolls));
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(8)]
        public void Should_Calculate_Spare_Score(int pinsAfterSpare)
        {
            _classUnderTest.Bowled(5);
            _classUnderTest.Bowled(5);
            _classUnderTest.Bowled(pinsAfterSpare);

            var score = 10 + pinsAfterSpare + pinsAfterSpare;
            Assert.That(_classUnderTest.Score(), Is.EqualTo(score));
        }

        [Test]
        [TestCase(3, 6)]
        [TestCase(4, 2)]
        [TestCase(8, 1)]
        public void Should_Calculate_Strike_Score(int turn1, int turn2)
        {
            _classUnderTest.Bowled(10);
            _classUnderTest.Bowled(turn1);
            _classUnderTest.Bowled(turn2);

            var score = (10 + turn1 + turn2) + turn1 + turn2;
            Assert.That(_classUnderTest.Score(), Is.EqualTo(score));
        }

        [Test]
        public void Should_Calculate_Perfect_Score_Game()
        {
            for (int i = 0; i < 12; i++)
            {
                _classUnderTest.Bowled(10);
            }

            Assert.That(_classUnderTest.Score(), Is.EqualTo(300));
        }
    }
}