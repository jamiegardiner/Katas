using System;

namespace FizzBuzz.Console.Filters
{
    public class Fizz : INumberFilter
    {
        public Predicate<int> Condition => (number) => number % 3 == 0;
        public string FilteredOutput => "Fizz";
    }
}