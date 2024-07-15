
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// A helper for an expression
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles an expression and gets the function return value
        /// </summary>
        /// <typeparam name="T">type of return value</typeparam>
        /// <param name="Lambda">the expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        /// <summary>
        /// Sets the underlying value to the given value from expression that contains the property
        /// </summary>
        /// <typeparam name="T">The type of value to set</typeparam>
        /// <param name="Lambda">The expression</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue< T>(this Expression<Func< T>> lambda, T value)
        {
            //convert a lambda () => some.peoperty, to some.property
            var expression = (lambda as LambdaExpression).Body as MemberExpression; //suppose to be Body as MemberExpression

            //Get the property information so we can it
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            //set the property value
            propertyInfo.SetValue(target, value);
        }
    }
}
