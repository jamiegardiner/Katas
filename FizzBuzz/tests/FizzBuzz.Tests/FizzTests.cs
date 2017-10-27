using FizzBuzz.Console;
using FizzBuzz.Console.Filters;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzTests
    {
        [Test]
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(12)]
        [TestCase(15)]
        [TestCase(99)]
        public void Condition_Should_Return_True_When_Number_Is_A_Multiple_Of_3(int number)
        {
            var classUnderTest = new Fizz();
            Assert.True(classUnderTest.Condition(number));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(32)]
        [TestCase(65)]
        public void Condition_Should_Return_False_When_Number_Is_Not_A_Multiple_Of_3(int number)
        {
            var classUnderTest = new Fizz();
            Assert.False(classUnderTest.Condition(number));
        }

        [Test]
        public void FilteredResult_Should_Return_Fizz()
        {
            var classUnderTest = new Fizz();
            Assert.That(classUnderTest.FilteredOutput, Is.EqualTo("Fizz"));
        }
    }
}