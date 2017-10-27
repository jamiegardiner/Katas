using System;

namespace FizzBuzz.Console.Filters
{
    public interface INumberFilter
    {
        Predicate<int> Condition { get; }
        string FilteredOutput { get; }
    }
}