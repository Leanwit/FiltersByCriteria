using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.CsharpBasicSkeleton.Items.Domain;
using src.CsharpBasicSkeleton.Shared.Domain.FiltersByCriteria;
using src.CsharpBasicSkeleton.Shared.Infrastructure.FiltersByCriteria;

namespace src.CsharpBasicSkeleton.Items.Infrastructure
{
    public class InMemoryItemRepository : ItemRepository
    {
        private readonly List<Item> _context;

        public InMemoryItemRepository()
        {
            _context = new List<Item>
            {
                new Item(new Guid("47f04654-6017-4b98-83db-c0e36a4ea698"), "Item 1"),
                new Item(new Guid("5afdb4ef-79fe-4dc1-b0b5-f5eb74010693"), "Item 2"),
                new Item(new Guid("dd9ef021-b09c-4b6c-b69b-453849a93fd5"), "Item 3")
            };
        }
        
        public InMemoryItemRepository(List<Item> items)
        {
            _context = items;
        }

        public Task<Item> GetById(Guid id)
        {
            return Task.FromResult(_context.FirstOrDefault(x => x.Id.Equals(id)));
        }
        
        public Task Add(Item item)
        {
            _context.Add(item);
            return Task.CompletedTask;
        }

        public Task<List<Item>> Matching(Criteria criteria)
        {
            return Task.FromResult(_context.AsQueryable()
                .Where(criteria)
                .OrderBy(criteria)
                .Offset(criteria)
                .Limit(criteria)
                .ToList());
        }
    }
}