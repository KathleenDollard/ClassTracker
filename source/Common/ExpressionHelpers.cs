using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common
{
    public static class ExpressionHelpers
    {
        public static string GetPropNameFromSimpleExpression<TEntity, TPKey>(
                this Expression<Func<TEntity, TPKey>> expr)
        {
            switch (expr.Body)
            {
                case MemberExpression memberExpression:
                    return memberExpression.Member.Name;
                default:
                    throw new InvalidOperationException("Only simple member access allowed");
            }
        }

        public static Expression<Func<TEntity, bool>> WhereClauseForProperty<TEntity, TPKey>(
                   this Expression<Func<TEntity, TPKey>> expr, TPKey selectValue)
        {
            // o => o.Id == {selectValue}
            var parameter = Expression.Parameter(expr.Parameters.First().Type, "x");
            var propertyName = GetPropNameFromSimpleExpression(expr);
            var propertyExpr = Expression.Property(parameter, propertyName);
            var constExpr = Expression.Constant(selectValue, typeof(TPKey));
            var equalsExpr = Expression.Equal(propertyExpr, constExpr);
            var lambdaExpr = Expression.Lambda(equalsExpr, parameter);
            return (Expression<Func<TEntity, bool>>)lambdaExpr;
        }
    }
}
