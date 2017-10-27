using FizzBuzz.Console.Filters;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class PopTests
    {
        [Test]
        [TestCase(2)]
        [TestCase(12)]
        [TestCase(22)]
        [TestCase(23)]
        [TestCase(62)]
        public void Condition_Should_Return_True_When_Number_Contains_A_2(int number)
        {
            var classUnderTest = new Pop();
            Assert.True(classUnderTest.Condition(number));
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(31)]
        [TestCase(87)]
        public void Condition_Should_Return_False_When_Number_Does_Not_Contain_A_2(int number)
        {
            var classUnderTest = new Pop();
            Assert.False(classUnderTest.Condition(number));
        }

        [Test]
        public void FilteredResult_Should_Return_Buzz()
        {
            var classUnderTest = new Pop();
            Assert.That(classUnderTest.FilteredOutput, Is.EqualTo("Pop"));
        }
    }
}