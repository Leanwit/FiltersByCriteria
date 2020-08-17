using System.Collections.Generic;
using src.CsharpBasicSkeleton.Shared.Domain.Bus.Queries;

namespace src.CsharpBasicSkeleton.Items.Application.SearchByCriteria
{
    public class SearchItemsByCriteriaQuery : Query
    {
        public string OrderBy { get; }
        public string OrderType { get; }
        public int Limit { get; }
        public int Offset { get; }
        public List<Dictionary<string,string>> Filters { get; }

        public SearchItemsByCriteriaQuery(string orderBy, string orderType, int limit, int offset,
            List<Dictionary<string,string>> filters)
        {
            OrderBy = orderBy;
            OrderType = orderType;
            Limit = limit;
            Offset = offset;
            Filters = filters;
        }
    }
}