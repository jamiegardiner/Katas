using System;

namespace FizzBuzz.Console.Filters
{
    public class Buzz : INumberFilter
    {
        public Predicate<int> Condition => (number) => number % 5 == 0;
        public string FilteredOutput => "Buzz";
    }
}