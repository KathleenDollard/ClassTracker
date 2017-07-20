using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadGen.ClassTracker.Repository.Specs
{
    class PureOrImpure
    {
        public int Sample1()
        {
            return 42;
        }

        public int Sample2(int x, int y)
        {
            var z = x + y;
            return z;
        }

        public int Sample3(int x, int y)
        {
            var z = x + y;
            Console.WriteLine(z);
            return z;
        }

        public void Sample4(int x, int y)
        {
            var z = x + y;
            Console.WriteLine(z);
        }

        public int Sample5()
        {
            return DateTime.Now.Second;
        }

        public int Sample6()
        {
            return Foo();
        }

        private int Foo()
        {
            return 42;
        }
    }
}
