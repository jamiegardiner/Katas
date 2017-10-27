using System;

namespace FizzBuzz.Console.Filters
{
    public class Pop : INumberFilter
    {
        public Predicate<int> Condition => (number) => number.ToString().Contains("2");
        public string FilteredOutput => "Pop";
    }
}