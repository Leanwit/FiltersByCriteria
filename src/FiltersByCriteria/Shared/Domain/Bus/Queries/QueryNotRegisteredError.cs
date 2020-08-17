using System;

namespace src.CsharpBasicSkeleton.Shared.Domain.Bus.Queries
{
    public class QueryNotRegisteredError : Exception
    {
        public QueryNotRegisteredError(Query query) : base(
            $"The query {query} has not a query handler associated")
        {
        }
    }
}