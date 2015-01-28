using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Reflection;

namespace BuildmateWebsite.Models
{
    public static class QueryExtensions
    {
        public static IQueryable<T> MultiValueContainsAny<T>(this IQueryable<T> source, ICollection<string> searchKeys, Expression<Func<T, string>> fieldSelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (fieldSelector == null)
                throw new ArgumentNullException("fieldSelector");
            if (searchKeys == null || searchKeys.Count == 0)
                return source;

            MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            Expression expression = null;
            foreach (var searchKeyPart in searchKeys)
            {
                Tuple<string> tmp = new Tuple<string>(searchKeyPart);
                Expression searchKeyExpression = Expression.Property(Expression.Constant(tmp), tmp.GetType().GetProperty("Item1"));
                Expression callContainsMethod = Expression.Call(fieldSelector.Body, containsMethod, searchKeyExpression);

                if (expression == null)
                    expression = callContainsMethod;
                else
                    expression = Expression.OrElse(expression, callContainsMethod);
            }
            return source.Where(Expression.Lambda<Func<T, bool>>(expression, fieldSelector.Parameters));
        }
    }
}