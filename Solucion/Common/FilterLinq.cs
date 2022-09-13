using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Common
{
    public class FilterLinq<T>
    {
        /// <summary>
        /// Crea un filtro para la base en el Ef.core atra vez de linQ y Expressions
        /// </summary>
        /// <param name="campo"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public Expression<Func<T, bool>> CreateFilterExpresion(string campo, string filtro)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, campo);
            var method = typeof(StringExtensions).GetMethod("Contains", new[] { typeof(string), typeof(string) });
            var constant = Expression.Constant(filtro, typeof(string));
            var finalExpression = Expression.Call(null, method, member, constant);
            return Expression.Lambda<Func<T, bool>>(finalExpression, parameter);
        }
    }

    public static class StringExtensions
    {
        public static bool Contains(this string source, string searchString)
        {
            return source?.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
