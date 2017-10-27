using System;
using System.Collections.Generic;
using System.Linq;
using FizzBuzz.Console.Filters;

namespace FizzBuzz.Console
{
    public class FizzBuzzLooper : IFizzBuzzLooper
    {
        private readonly int _numberOfIterations;
        private readonly IList<INumberFilter> _filters;

        public FizzBuzzLooper(int numberOfIterations)
        {
            _numberOfIterations = numberOfIterations;
            _filters = new List<INumberFilter>();
        }

        public void Output(Action<string> actionToPerformOnResultFromEachIteration)
        {
            for (var i = 1; i <= _numberOfIterations; i++)
            {
                var result = _filters.FirstOrDefault(x => x.Condition(i))?.FilteredOutput ?? i.ToString();
                actionToPerformOnResultFromEachIteration?.Invoke(result);
            }
        }

        public IFizzBuzzLooper AddFilter(INumberFilter filter)
        {
            _filters.Add(filter);
            return this;
        }
    }
}