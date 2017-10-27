using FizzBuzz.Console;
using FizzBuzz.Console.Filters;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class BuzzTests
    {
        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(65)]
        [TestCase(85)]
        public void Condition_Should_Return_True_When_Number_Is_A_Multiple_Of_5(int number)
        {
            var classUnderTest = new Buzz();
            Assert.True(classUnderTest.Condition(number));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(32)]
        [TestCase(86)]
        public void Condition_Should_Return_False_When_Number_Is_Not_A_Multiple_Of_5(int number)
        {
            var classUnderTest = new Buzz();
            Assert.False(classUnderTest.Condition(number));
        }

        [Test]
        public void FilteredResult_Should_Return_Buzz()
        {
            var classUnderTest = new Buzz();
            Assert.That(classUnderTest.FilteredOutput, Is.EqualTo("Buzz"));
        }
    }
}