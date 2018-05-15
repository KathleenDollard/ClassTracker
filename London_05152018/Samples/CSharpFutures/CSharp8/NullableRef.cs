using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8
{
    public class NullableRef
    {
        public void Foo(string s)
        {

        }
    }

    class NullReference
    {
        public void Foo(string z)
        {
            string? x = "";
            string? y = null;
            z = null;
            Console.WriteLine(x.Length);
            Console.WriteLine(z.Length);
        }
    }
}
