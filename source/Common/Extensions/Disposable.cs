using System;
using System.Threading.Tasks;

namespace KadGen.Common
{
    public static class Disposable
    {
        public static TResult Using<TWith, TResult>(
                Func<TWith> factory,
                Func<TWith, TResult> operate)
            where TWith : IDisposable
        {
            using (var with = factory())
            {
                return operate(with);
            }
        }

        public async static Task<TResult> UsingAsync<TWith, TResult>(
                Func<TWith> factory,
                Func<TWith, Task<TResult>> operate)
            where TWith : IDisposable
        {
            using (var with = factory())
            {
                return await operate(with);
            }
        }
    }
}
