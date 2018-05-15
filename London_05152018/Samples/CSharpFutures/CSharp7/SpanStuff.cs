using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp7
{
    public class SpanStuff
    {
        public static void Foo()
        {
            int[] array = Enumerable.Range(0, 10).ToArray();
            Span<int> span = array.AsSpan();
            Span<int> slice = span.Slice(3, 3);
            slice[2] = slice[2] * 10;
            for (int i = 0; i < span.Length; i++)
            {
                Console.WriteLine($"{span[i]}, {array[i]}");
            }
            Console.WriteLine("***");
            foreach (int i in slice) Console.WriteLine(i);

        }
    }
}
