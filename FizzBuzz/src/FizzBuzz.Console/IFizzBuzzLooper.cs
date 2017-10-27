using System;
using FizzBuzz.Console.Filters;

namespace FizzBuzz.Console
{
    public interface IFizzBuzzLooper
    {
        void Output(Action<string> actionToPerformOnResultFromEachIteration);
        IFizzBuzzLooper AddFilter(INumberFilter filter);
    }
}