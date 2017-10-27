using FizzBuzz.Console.Filters;

namespace FizzBuzz.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            new FizzBuzzLooper(100)
                .AddFilter(new Filters.FizzBuzz())
                .AddFilter(new Fizz())
                .AddFilter(new Buzz())
                .Output(System.Console.WriteLine);

            new FizzBuzzLooper(50)
                .AddFilter(new Fizz())
                .AddFilter(new Pop())
                .Output(System.Console.WriteLine);

            System.Console.ReadLine();
        }
    }
}
