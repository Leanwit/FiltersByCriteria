using System.Collections.Generic;

namespace src.CsharpBasicSkeleton.Items.Application
{
    public class ItemsResponse
    {
        public readonly IEnumerable<ItemResponse> Items;

        public ItemsResponse(IEnumerable<ItemResponse> items)
        {
            Items = items;
        }
    }
}    