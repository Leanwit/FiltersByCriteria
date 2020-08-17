using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.CsharpBasicSkeleton.Items.Domain;
using src.CsharpBasicSkeleton.Items.Infrastructure;
using src.CsharpBasicSkeleton.Shared.Domain.FiltersByCriteria;
using Xunit;

namespace FiltersByCriteria.Test.Src.Items.Infrastructure
{
    public class InMemoryItemRepositoryLimitShould
    {
        private readonly InMemoryItemRepository _repository;

        private readonly List<Item> _items = new List<Item>();

        private void PopulateItems(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _items.Add(new Item(Guid.NewGuid(), "Item 1", 1));
            }
        }

        public InMemoryItemRepositoryLimitShould()
        {
            PopulateItems(100);
            _repository = new InMemoryItemRepository(_items);
        }

        [Fact]
        public async Task It_Should_Limit()
        {
            var criteria = new Criteria(new Filters(new List<Filter>()), null, 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(result, _items.Take(10));
        }
    }
}