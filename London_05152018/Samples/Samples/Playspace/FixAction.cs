using System;

namespace KadGen.Functional.Samples
{
    public static class FixAction
    {
        public static Func<TParam, VoidType> ToFunc<TParam>(Action<TParam> action) => x =>
            {
                action(x);
                return default;
            };

        public class VoidType
        {
        }

        // Implementation
        //public class VoidType
        //{ }

        //public static class ActionExt
        //{
        //    public static Func<Unit> ToFunc(this Action action)
        //        => () => { action(); return VoidType(); };

        //    public static Func<T, Unit> ToFunc<T>(this Action<T> action)
        //        => x => { action(x); return VoidType(); };

        //    public static Func<T1, T2, Unit> ToFunc<T1, T2>(this Action<T1, T2> action)
        //        => (T1 x, T2 y) => { action(x, y); return VoidType(); };
        //}
    }
}

   