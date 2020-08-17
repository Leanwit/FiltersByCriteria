using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using src.CsharpBasicSkeleton.Shared.Domain.FiltersByCriteria;

namespace src.CsharpBasicSkeleton.Shared.Infrastructure.Criteria
{
    public static class LinqBuilderByCriteria
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> collection, Domain.FiltersByCriteria.Criteria criteria)
        {
            if (criteria == null || !criteria.Filters.Values.Any())
            {
                return collection;
            }

            var queries = new List<string>();
            string query;

            foreach (var filter in criteria.Filters.Values)
            {
                query = GetQueryByFilter(filter);

                if (!string.IsNullOrEmpty(query))
                {
                    queries.Add(query);
                }
            }

            string where = string.Join(" && ", queries);
            return collection.Where(where);
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> collection,
            Domain.FiltersByCriteria.Criteria criteria)
        {
            if (criteria == null || criteria.Order == null || criteria.Order.OrderType == OrderType.NONE || criteria.Order.OrderBy.Value == null)
            {
                return collection;
            }
            
            switch (criteria.Order.OrderType)
            {
                case OrderType.ASC:
                    return collection.OrderBy(criteria.Order.OrderBy.Value);
                case OrderType.DESC:
                    return collection.OrderBy($"{criteria.Order.OrderBy.Value} DESC");
            }
            
            return collection;
        }
        
        public static IQueryable<T> Limit<T>(this IQueryable<T> collection,
            Domain.FiltersByCriteria.Criteria criteria)
        {
            if (criteria == null || !criteria.Limit.HasValue )
            {
                return collection;
            }

            return collection.Take(criteria.Limit.GetValueOrDefault());
        }
        
        public static IQueryable<T> Offset<T>(this IQueryable<T> collection,
            Domain.FiltersByCriteria.Criteria criteria)
        {
            if (criteria == null || !criteria.Offset.HasValue )
            {
                return collection;
            }
            
            return collection.Skip(criteria.Offset.GetValueOrDefault());
        }

       
        private static string GetQueryByFilter(Filter filter)
        {
            switch (filter.Operator)
            {
                case FilterOperator.EQUAL:
                    return $"{filter.Field.Value} == \"{filter.Value.Value}\"";
                case FilterOperator.NOT_EQUAL:
                    return $"{filter.Field.Value} != \"{filter.Value.Value}\"";
                case FilterOperator.GT:
                    return $"{filter.Field.Value} > {filter.Value.Value}";
                case FilterOperator.LT:
                    return $"{filter.Field.Value} < {filter.Value.Value}";
                case FilterOperator.CONTAINS:
                    return $"{filter.Field.Value}.Contains(\"{filter.Value.Value}\", StringComparison.CurrentCultureIgnoreCase)";
                case FilterOperator.NOT_CONTAINS:
                    return $"!{filter.Field.Value}.Contains(\"{filter.Value.Value}\", StringComparison.CurrentCultureIgnoreCase)";
            }

            return string.Empty;
        }
    }
}