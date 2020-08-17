using System.Collections.Generic;
using System.Linq;

namespace src.CsharpBasicSkeleton.Shared.Domain.FiltersByCriteria
{
    public class Filters
    {
        public List<Filter> Values { get; }

        public Filters(List<Filter> filters)
        {
            this.Values = filters;
        }

        public static Filters FromValues(List<Dictionary<string, string>> filters)
        {
            return new Filters(filters.Select(Filter.FromValues).ToList());
        }

    }
}