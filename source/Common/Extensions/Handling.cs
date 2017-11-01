using System;
using System.Threading.Tasks;

namespace KadGen.Common
{
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
                where TResult : Result
             => Try(operation,
                 ex => Result.CreateErrorResult<TResult>(new Error(ErrorCode.ExceptionThrown, ex, null)));

        public static async Task<TResult> WithCommonHandlingAsync<TResult>(
                    Func<Task<TResult>> operation)
                where TResult : Result
            => await TryAsync(operation,
                 ex => Result.CreateErrorResult<TResult>(new Error(ErrorCode.ExceptionThrown, ex, null)));

    }
}
