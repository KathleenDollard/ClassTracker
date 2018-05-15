using System;
using System.Collections.Generic;
using System.Text;

namespace Playspace
{
    class NullReference
    {
        public void Foo(string z)
        {
            string x = "";
            string y = null;
            z = null;
            Console.WriteLine(x.Length);
            Console.WriteLine(z.Length);
        }
    }
}
