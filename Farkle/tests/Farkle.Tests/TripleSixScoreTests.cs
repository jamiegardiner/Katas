using System;
using Farkle.Domain;
using NUnit.Framework;

namespace Farkle.Tests
{
    [TestFixture]
    public class TripleSixScoreTests
    {
        [Test]
        public void Should_Return_Score_Of_600_When_Combination_Contains_Triple_6()
        {
            Assert.That(new TrebleSixScore().Calculate(new[] { 1, 2, 3, 6, 6, 6 }).Total, Is.EqualTo(600));
        }

        [Test]
        public void Should_Return_Score_Of_Zero_When_Combination_Does_Not_Contain_Triple_6()
        {
            Assert.That(new TrebleSixScore().Calculate(new[] { 1, 2, 3, 4, 5, 6 }).Total, Is.EqualTo(0));
        }

        [Test]
        public void Should_Return_Remaining_Dice_As_Three_When_Scoring()
        {
            Assert.That(new TrebleSixScore().Calculate(new[] { 1, 2, 3, 6, 6, 6 }).Remainder, Is.EqualTo(3));
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(10)]
        public void Should_Return_Correct_Remainder_When_Scoring(int numberOfAdditionalDice)
        {
            var dice = new int[numberOfAdditionalDice + 3];
            dice[0] = 6;
            dice[1] = 6;
            dice[2] = 6;

            for (int i = 3; i <= numberOfAdditionalDice; i++)
            {
                dice[i] = new Random(Guid.NewGuid().GetHashCode()).Next(1, 5);
            }

            Assert.That(new TrebleSixScore().Calculate(dice).Remainder, Is.EqualTo(numberOfAdditionalDice));
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(10)]
        public void Should_Return_Correct_Remainder_When_Not_Scoring(int numberOfDice)
        {
            var dice = new int[numberOfDice];
            for (int i = 0; i < numberOfDice; i++)
            {
                dice[i] = new Random(Guid.NewGuid().GetHashCode()).Next(1, 5);
            }

            Assert.That(new TrebleSixScore().Calculate(dice).Remainder, Is.EqualTo(numberOfDice));
        }
    }
}
