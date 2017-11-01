using System;
using System.Collections.Generic;
using System.Linq;

namespace KadGen.Common
{
    public static class FunctionExtensions
    {
        public static TResult Map<TInput, TResult>(this TInput input, Func<TInput, TResult> mapFunc)
            => mapFunc(input);

        public static void Map<TInput, TAlter>(this TInput input, Action<TInput, TAlter> mapFunc, TAlter itemToAlter )
            => mapFunc(input, itemToAlter);

        public static IEnumerable<TResult> Map<TInput, TResult>(this IEnumerable<TInput> input, Func<TInput, TResult> mapFunc)
            => input.Select(mapFunc);


        public static IEnumerable<TData> ToIEnumerable<TData>(this IQueryable<TData> queryable)
        {
            return queryable.ToList();
        }

    }
}
