using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KadGen.Functional.Common
{
    public static class FunctionExtensions
    {
        public static TResult Map<TInput, TResult>(this TInput input, Func<TInput, TResult> mapFunc)
            => mapFunc(input);

        public static void Map<TInput, TAlter>(this TInput input, Action<TInput, TAlter> mapFunc, TAlter itemToAlter)
            => mapFunc(input, itemToAlter);

        public static IEnumerable<TResult> Map<TInput, TResult>(this IEnumerable<TInput> input, Func<TInput, TResult> mapFunc)
            => input.Select(mapFunc);


        public static IEnumerable<TData> ToIEnumerable<TData>(this IQueryable<TData> queryable)
        {
            return queryable.ToList();
        }

    }

    public static class ExpressionExptensions
    {
        public static string MemberName<TObject, TValue>(
            this Expression<Func<TObject, TValue>> getPKey)
        {
            var member = getPKey.Body as MemberExpression;
            // if null, the expression is too complex
            return member.Member.Name;
        }

        public static Expression<Func<TObject, bool>> EqualsWhereFromMemberLambdaExpression
            <TObject, TValue>(
                this Expression<Func<TObject, TValue>> getPKey,
                TValue key)
        {
            var parameterExpression = Expression.Parameter(typeof(TObject));
            var memberInfo = (getPKey.Body as MemberExpression).Member;
            var memberExpression = Expression.MakeMemberAccess(
                                        parameterExpression, memberInfo);
            var constantExpression = Expression.Constant(key);
            var binaryExpression = Expression.MakeBinary(
                                        ExpressionType.Equal,
                                        memberExpression,
                                        constantExpression);
            var lambdaExpression = Expression.Lambda<Func<TObject, bool>>(
                                        binaryExpression,
                                        parameterExpression);
            return lambdaExpression;
        }
    }

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

    public static class Handling
    {
        public static TResult Try<TResult>(
            Func<TResult> operate,
            Func<Exception, TResult> catchOperate)
        {
            try
            {
                return operate();
            }
            catch (Exception ex)
            {
                return catchOperate(ex);
            }
        }

        public async static Task<TResult> TryAsync<TResult>(
             Func<Task<TResult>> operate,
             Func<Exception, TResult> catchOperate)
        {
            try
            {
                return await operate();
            }
            catch (Exception ex)
            {
                return catchOperate(ex);
            }
        }

        public static TResult WithDemoHandling<TResult>(Func<TResult> operation)
                where TResult : struct // for demo
             => Try(operation,
                 ex => default(TResult));

        public static TResult WithCommonHandling<TResult>(Func<TResult> operation)
                where TResult : BaseResult
             => Try(operation,
                 ex => BaseResult.GetErrorResult<TResult>(new ExceptionFail(ex)));

        public static async Task<TResult> WithCommonHandlingAsync<TResult>(
                    Func<Task<TResult>> operation)
                where TResult : BaseResult
            => await TryAsync(operation,
                 ex => BaseResult.GetErrorResult<TResult>(new ExceptionFail(ex)));

    }
}
