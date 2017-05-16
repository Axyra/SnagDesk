using System;
using System.Linq;

namespace SnagDesk.DAL
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IOrderedQueryable<T> queryable, int pageSize, int pageNumber)
        {
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than zero.");

            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than zero.");

            return queryable.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
        }
    }
}