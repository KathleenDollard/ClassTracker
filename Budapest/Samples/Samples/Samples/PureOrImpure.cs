using System;

namespace KadGen.Functional.Samples
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

        // What about Exceptions??

        public int Sample7(int x, int y)
        {
            try
            {
                return x / y;
                throw new Exception();
            }
            catch  // Ick,swallowing error
            {
                return 0; 
            }
        }

        public int Sample8(int x, int y)
        {
            return x / y;
        }
    }
}
