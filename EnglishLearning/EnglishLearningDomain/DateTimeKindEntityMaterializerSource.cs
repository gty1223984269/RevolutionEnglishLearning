using System;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace EnglishLearningDomain
{
    public class DateTimeKindEntityMaterializerSource : EntityMaterializerSource
    {
        private static readonly MethodInfo _normalizeMethod =
            typeof(DateTimeKindMapper).GetTypeInfo().GetMethod(nameof(DateTimeKindMapper.Normalize));

        private static readonly MethodInfo _normalizeNullableMethod =
            typeof(DateTimeKindMapper).GetTypeInfo().GetMethod(nameof(DateTimeKindMapper.NormalizeNullable));

        private static readonly MethodInfo _normalizeObjectMethod =
            typeof(DateTimeKindMapper).GetTypeInfo().GetMethod(nameof(DateTimeKindMapper.NormalizeObject));

       

        public override Expression CreateReadValueCallExpression(Expression valueBuffer, int index)
        {
            var readValueCallExpression = base.CreateReadValueCallExpression(valueBuffer, index);
            if (readValueCallExpression.Type == typeof(DateTime))
            {
                return Expression.Call(
                    _normalizeMethod,
                    readValueCallExpression);
            }

            if (readValueCallExpression.Type == typeof(DateTime?))
            {
                return Expression.Call(
                    _normalizeNullableMethod,
                    readValueCallExpression);
            }

            if (readValueCallExpression.Type == typeof(object))
            {
                return Expression.Call(
                    _normalizeObjectMethod,
                    readValueCallExpression);
            }

            return readValueCallExpression;
        }
    }
}


