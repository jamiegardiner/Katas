using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Bowling.Domain.Tests
{
    public class StandardFrameTests
    {

        [TestCase(5)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(10)]
        public void Should_Return_Correct_Pins_Remaining(int pinsKnockedDown)
        {
            var classUnderTest = new StandardFrame(1);
            classUnderTest.TakeTurn(pinsKnockedDown);

            Assert.That(classUnderTest.PinsRemaining, Is.EqualTo(10 - pinsKnockedDown));
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-3)]
        public void Should_Throw_Exception_When_Knocking_Down_Negative_Number_Of_Pins(int numberOfPins)
        {
            var classUnderTest = new StandardFrame(1);

            Assert.That(()=>classUnderTest.TakeTurn(numberOfPins), Throws.ArgumentException);
        }

        [TestCase(6)]
        [TestCase(7)]
        [TestCase(11)]
        public void Should_Throw_Exception_When_Knocking_Down_Too_Many_Of_Pins(int numberOfPins)
        {
            var classUnderTest = new StandardFrame(1);
            classUnderTest.TakeTurn(5);
            Assert.That(() => classUnderTest.TakeTurn(numberOfPins), Throws.ArgumentException);
        }

        [Test]
        public void Should_Determine_If_Strike_Has_Been_Achieved()
        {
            var classUnderTest = new StandardFrame(1);
            classUnderTest.TakeTurn(10);
            Assert.True(classUnderTest.HasStrike);
        }

        [Test]
        public void Should_Determine_If_Strike_Has_Not_Been_Achieved()
        {
            var classUnderTest = new StandardFrame(1);
            classUnderTest.TakeTurn(9);
            Assert.False(classUnderTest.HasStrike);
        }

        [Test]
        public void Should_Determine_If_Spare_Has_Been_Achieved()
        {
            var classUnderTest = new StandardFrame(1);
            classUnderTest.TakeTurn(1);
            classUnderTest.TakeTurn(9);
            Assert.True(classUnderTest.HasSpare);
        }

        [Test]
        public void Should_Determine_If_Spare_Has_Not_Been_Achieved()
        {
            var classUnderTest = new StandardFrame(1);
            classUnderTest.TakeTurn(1);
            classUnderTest.TakeTurn(6);
            Assert.False(classUnderTest.HasSpare);
        }
    }

    public class StandardFrame
    {
        private const int StartNumberOfPins = 10;

        private IList<int> Turns { get; }
        public int FrameNumber { get; }
        public int PinsRemaining => StartNumberOfPins - Turns.Sum();

        public bool HasStrike => Turns.Count == 1 && PinsRemaining == 0;
        public bool HasSpare => Turns.Count > 1 && PinsRemaining == 0;

        public StandardFrame(int frameNumber)
        {
            FrameNumber = frameNumber;
            Turns = new List<int>();
        }

        public void TakeTurn(int pinsKnockedDown)
        {
            if(pinsKnockedDown < 0) throw new ArgumentException("Cannot knock down a negative number of pins");
            if(PinsRemaining < pinsKnockedDown) throw  new ArgumentException("Too many pins knocked down");

            Turns.Add(pinsKnockedDown);
        }
    }
}
