using Farkle.Domain;
using Moq;
using NUnit.Framework;

namespace Farkle.Tests
{
    public class DieTests
    {
        [Test]
        public void Should_Return_RollResult()
        {
            var die = new Die();
            var result = die.Roll();

            Assert.That(result, Is.InstanceOf<IRollResult>());
        }
    }
}