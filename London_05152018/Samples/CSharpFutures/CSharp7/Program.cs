using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            SpanStuff.Foo();
            int[] values = { 0b01, 0b010, 0b0100, 0b01000 };
            //var sum = await SumOfSquaresAsync(values);
            Color z = Foo<Color, Func<int, int>>(x => x, "Red", "Blue");
            var t = (z, Math.PI);
            Console.WriteLine(t.PI);
            Console.Read();
        }

        internal static async Task<int> SumOfSquaresAsync(IEnumerable<int> values, CancellationToken cancellationToken)
        {
            return await Task.Run(Compute, cancellationToken);// 7.3 ignores invalid overload
            int Compute() => values.Select(x => x * x).Sum();
        }

        [Flags]
        public enum Color
        {
            Red = 1,
            Blue,
            Green
        }

        public static TEnum Foo<TEnum, TDelegate>(TDelegate del, string value1, string value2)
            where TEnum : Enum
            where TDelegate : Delegate
        {
            var x = (TEnum)Enum.Parse(typeof(TEnum), value1);
            var y = (TEnum)Enum.Parse(typeof(TEnum), value2);
            //var z = x || y;

            Console.WriteLine(x.ToString());
            return x;
        }
    }
}
