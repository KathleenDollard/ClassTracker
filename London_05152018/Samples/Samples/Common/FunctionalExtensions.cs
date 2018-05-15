using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace KadGen.Functional.Common
{
    public static class FunctionExtensions
    {
        public static TRichData Select<TInput, TRichData>(this TInput input, Func<TInput, TRichData> mapFunc)
        => mapFunc(input);

        public static void Select<TInput, TAlter>(this TInput input, Action<TInput, TAlter> mapFunc, TAlter itemToAlter)
        => mapFunc(input, itemToAlter);

        public static IEnumerable<TRichData> Select<TInput, TRichData>(this IEnumerable<TInput> input, Func<TInput, TRichData> mapFunc)
        => input.Select(mapFunc);


        public static IEnumerable<TData> ToIEnumerable<TData>(this IQueryable<TData> queryable)
        => queryable.ToList();

    }

    public static class ExpressionExptensions
    {
        public static string MemberName<TObject, TValue>(
            this Expression<Func<TObject, TValue>> getPKey)
        // if null, the expression is too complex and we'll throw as it is a programmer mess-up
        => (getPKey.Body as MemberExpression).Member.Name;

        public static Expression<Func<TObject, bool>> EqualsWhereFromMemberLambdaExpression
            <TObject, TValue>(
                this Expression<Func<TObject, TValue>> getPKey,
                TValue key)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TObject));
            return parameterExpression
                    .MakeMemberAccess((getPKey.Body as MemberExpression).Member)
                    .MakeBinaryEqual(Expression.Constant(key))
                    .MakeLambda<TObject>(parameterExpression);
        }


        public static Expression<Func<TObject, bool>> EqualsWhereFromMemberLambdaExpression2
            <TObject, TValue>(
                this Expression<Func<TObject, TValue>> getPKey,
                TValue key)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TObject));
            MemberInfo memberInfo = (getPKey.Body as MemberExpression).Member;
            MemberExpression memberExpression = Expression.MakeMemberAccess(
                                        parameterExpression, memberInfo);
            ConstantExpression constantExpression = Expression.Constant(key);
            BinaryExpression binaryExpression = Expression.MakeBinary(
                                        ExpressionType.Equal,
                                        memberExpression,
                                        constantExpression);
            var lambdaExpression = Expression.Lambda<Func<TObject, bool>>(
                                        binaryExpression,
                                        parameterExpression);
            return lambdaExpression;
        }
    }

    public static class ReflectionExt
    {
        public static MemberExpression MakeMemberAccess(
                this ParameterExpression parameterExpression,
                MemberInfo memberInfo)
        => Expression.MakeMemberAccess(parameterExpression, memberInfo);

        public static BinaryExpression MakeBinaryEqual(
                this MemberExpression memberExpression,
                ConstantExpression constantExpression)
        => Expression.MakeBinary(ExpressionType.Equal,
                                memberExpression,
                                constantExpression);
        public static Expression<Func<TObject, bool>> MakeLambda<TObject>(
                this BinaryExpression binaryExpression,
                ParameterExpression parameterExpression)
        => Expression.Lambda<Func<TObject, bool>>(
                                binaryExpression,
                                parameterExpression);
    }


    public static class Disposable
    {
        public static TRichData Using<TWith, TRichData>(
                Func<TWith> factory,
                Func<TWith, TRichData> operate)
            where TWith : IDisposable
        {
            using (TWith with = factory())
            {
                return operate(with);
            }
        }

        // The async stuff is all very experimental right now. Dragons. Definitely dragons.
        public async static Task<TRichData> UsingAsync<TWith, TRichData>(
                Func<TWith> factory,
                Func<TWith, Task<TRichData>> operate)
            where TWith : IDisposable
        {
            using (TWith with = factory())
            {
                return await operate(with);
            }
        }
    }

    public static class Handling
    {
        public static TRichData Try<TRichData>(
            Func<TRichData> operate,
            Func<Exception, TRichData> catchOperate)
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

        // The async stuff is all very experimental right now. Dragons. Definitely dragons.
        public async static Task<TRichData> TryAsync<TRichData>(
             Func<Task<TRichData>> operate,
             Func<Exception, TRichData> catchOperate)
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

        public static TRichData WithDemoHandling<TRichData>(Func<TRichData> operation)
                where TRichData : struct // for demo
             => Try(operation, ex => default);

        public static TRichData WithCommonHandling<TRichData>(Func<TRichData> operation)
                where TRichData : BaseRichData
             => Try(operation,
                 ex => BaseRichData.GetErrorRichData<TRichData>(new ExceptionFail(ex)));

        // The async stuff is all very experimental right now. Dragons. Definitely dragons.
        public static async Task<TRichData> WithCommonHandlingAsync<TRichData>(
                    Func<Task<TRichData>> operation)
                where TRichData : BaseRichData
            => await TryAsync(operation,
                 ex => BaseRichData.GetErrorRichData<TRichData>(new ExceptionFail(ex)));

    }
}
