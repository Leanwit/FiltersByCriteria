using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.CsharpBasicSkeleton.Shared.Domain.FiltersByCriteria;

namespace src.CsharpBasicSkeleton.Items.Domain
{
    public interface ItemRepository
    {
        Task<Item> GetById(Guid id);
        Task Add(Item item);

        Task<List<Item>> Matching(Criteria criteria);
    }
}