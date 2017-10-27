using System;

namespace FizzBuzz.Console.Filters
{
    public class FizzBuzz : INumberFilter
    {
        public Predicate<int> Condition => (number) => number % 3 == 0 && number % 5 == 0;
        public string FilteredOutput => "FizzBuzz";
    }
}