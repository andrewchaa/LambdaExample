using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal result1 = SquareIt(2);
            WriteIt(result1);

            decimal result2 = Calculator(11m, x => x*32/12 + 1000 - 20);
            WriteIt(result2);

            Yell(new MonkeyBoy(), x => x.Scream());
            Yell(new MonkeyBoy(), x => x.Cheer());

            Console.ReadLine();
        }

        private static Func<decimal, decimal> SquareIt = x => x*x;
        private static Action<object> WriteIt = x => Console.WriteLine(x);

        private static decimal Calculator(decimal theNumber, Func<decimal, decimal> function )
        {
            return function.Invoke(theNumber);
        }

        private static void Yell(MonkeyBoy item, Action<MonkeyBoy> action)
        {
            action.Invoke(item);
        }
        
    }

    public class MonkeyBoy
    {
        public void Scream()
        {
            Console.WriteLine("Developers Developers Developers!");
        }

        public void Cheer()
        {
            Console.WriteLine("Go Windows Seven!!!!");
        }
    }
}
