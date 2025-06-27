using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MS.Services.Core.Base.Extentions;
public static class QueryExtensions
{
    private const string DESCENDING = "DESC";
    private const string ASCENDING = "ASC";
    
    public static IOrderedQueryable<TSource> OrderByDirection<TSource, TKey>(this IQueryable<TSource> query, Expression<Func<TSource, TKey>> keySelector, string direction = ASCENDING){
        if (DESCENDING.Equals(direction.ToUpper()))
        {
            return query.OrderByDescending(keySelector);
        } 
        else 
        {
            return query.OrderBy(keySelector);
        }
    }
    
}
