using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.CsharpBasicSkeleton.Items.Application;
using src.CsharpBasicSkeleton.Items.Application.SearchByCriteria;
using src.CsharpBasicSkeleton.Shared.Domain.Bus.Queries;

namespace FiltersByCriteria.Controllers.Items
{
    [Route("Items")]
    public class ItemsGetController : Controller
    {
        private readonly QueryBus _bus;

        public ItemsGetController(QueryBus bus)
        {
            _bus = bus;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromQuery] FiltersParam param)
        {
            if (param == null)
                return StatusCode(400, "Filters parameter is required");
                
            var items = await _bus.Ask<ItemsResponse>(
                new SearchItemsByCriteriaQuery(param.OrderBy, param.Order, param.Limit, param.Offset, param.Filters)
            );

            return StatusCode(200, items.Items);
        }
    }
}