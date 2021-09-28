using System;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Jibble.InfraStructure
{
    public static class Helper
    {
        public static Expression<Func<T, bool>> GetExpression<T>(string stringExpression)
        {
            var exp = DynamicExpressionParser
                .ParseLambda<T, bool>(new ParsingConfig(), false, stringExpression);

            return exp;
        }
    }
}