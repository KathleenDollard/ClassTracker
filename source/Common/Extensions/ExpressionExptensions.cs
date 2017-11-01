using System;
using System.Linq.Expressions;

namespace KadGen.Common
{
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
}
