using System;
using System.Collections.Generic;
using FizzBuzz.Console;
using FizzBuzz.Console.Filters;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzLooperTests
    {
        [Test]
        public void Should_Call_Passed_Delegate_With_Result_On_Output()
        {
            var assertionList = new List<string>();

            var classUnderTest = new FizzBuzzLooper(5);
            classUnderTest.Output(result => assertionList.Add(result));

            Assert.That(assertionList.Count, Is.EqualTo(5));
        }

        [Test]
        public void Should_Call_Filter_On_Match_When_Outputting_Results()
        {
            var assertionList = new List<string>();

            var classUnderTest = new FizzBuzzLooper(5);
            classUnderTest.AddFilter(new TestNumberFilter());
            classUnderTest.Output(result => assertionList.Add(result));

            Assert.That(assertionList[4], Is.EqualTo("TestFilter"));
        }

        [Test]
        public void Should_Return_Current_Number_When_No_Filter_Is_Matched()
        {
            var assertionList = new List<string>();

            var classUnderTest = new FizzBuzzLooper(5);
            classUnderTest.AddFilter(new TestNumberFilter());
            classUnderTest.Output(result => assertionList.Add(result));

            Assert.That(assertionList[0], Is.EqualTo("1"));
            Assert.That(assertionList[1], Is.EqualTo("2"));
            Assert.That(assertionList[2], Is.EqualTo("3"));
            Assert.That(assertionList[3], Is.EqualTo("4"));
        }

        [Test]
        public void Should_Return_FizzBuzzLooper_After_Adding_Filter()
        {
            var classUnderTest = new FizzBuzzLooper(5);
            var looper = classUnderTest.AddFilter(new TestNumberFilter());

            Assert.That(looper, Is.SameAs(classUnderTest));
        }
    }

    public class TestNumberFilter : INumberFilter
    {
        public Predicate<int> Condition => number => number == 5;
        public string FilteredOutput => "TestFilter";
    }
}