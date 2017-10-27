using NUnit.Framework;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(60)]
        public void Condition_Should_Return_True_When_Number_Is_A_Multiple_Of_3_And_5(int number)
        {
            var classUnderTest = new Console.Filters.FizzBuzz();
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
            var classUnderTest = new Console.Filters.FizzBuzz();
            Assert.False(classUnderTest.Condition(number));
        }

        [Test]
        public void FilteredResult_Should_Return_Buzz()
        {
            var classUnderTest = new Console.Filters.FizzBuzz();
            Assert.That(classUnderTest.FilteredOutput, Is.EqualTo("FizzBuzz"));
        }
    }
}