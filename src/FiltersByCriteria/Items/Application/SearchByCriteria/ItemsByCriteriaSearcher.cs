using System.Linq;
using System.Threading.Tasks;
using src.CsharpBasicSkeleton.Items.Domain;
using src.CsharpBasicSkeleton.Shared.Domain.FiltersByCriteria;

namespace src.CsharpBasicSkeleton.Items.Application.SearchByCriteria
{
    public class ItemsByCriteriaSearcher
    {
        private readonly ItemRepository _repository;

        public ItemsByCriteriaSearcher(ItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<ItemsResponse> Search(Filters filters, Order order, int? limit = null, int? offset = null)
        {
            Criteria criteria = new Criteria(filters, order, limit, offset);

            return new ItemsResponse((await _repository.Matching(criteria)).Select(x =>
                new ItemResponse(x.Id, x.Name, x.IsCompleted, x.Priority)));
        }
    }
}