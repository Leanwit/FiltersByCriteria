using System.Threading.Tasks;
using src.CsharpBasicSkeleton.Shared.Domain.Bus.Queries;
using src.CsharpBasicSkeleton.Shared.Domain.FiltersByCriteria;

namespace src.CsharpBasicSkeleton.Items.Application.SearchByCriteria
{
    public class SearchItemByCriteriaQueryHandler : QueryHandler<SearchItemsByCriteriaQuery, ItemsResponse>
    {
        private readonly ItemsByCriteriaSearcher _searcher;

        public SearchItemByCriteriaQueryHandler(ItemsByCriteriaSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<ItemsResponse> Handle(SearchItemsByCriteriaQuery query)
        {
            Filters filters = Filters.FromValues(query.Filters);
            Order order = Order.FromValues(query.OrderBy, query.OrderType);

            return await _searcher.Search(filters, order, query.Limit, query.Offset);
        }
    }
}