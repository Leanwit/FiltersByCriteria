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
    public class InMemoryItemRepositoryOrderShould
    {
        private readonly InMemoryItemRepository _repository;

        private readonly List<Item> _items = new List<Item>()
        {
            new Item(new Guid("47f04654-6017-4b98-83db-c0e36a4ea698"), "Item 1", 1),
            new Item(new Guid("47f04654-6017-4b98-83db-c0e36a4ea698"), "Item 2", 2)
        };

        public InMemoryItemRepositoryOrderShould()
        {
            _repository = new InMemoryItemRepository(_items);
        }

        [Fact]
        public async Task It_Should_Order_By_Asc_Int()
        {
            var filters = new Filters(new List<Filter>());
            var criteria = new Criteria(filters, Order.FromValues("priority","asc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(result, _items.OrderBy(x => x.Priority));
        }
        
        [Fact]
        public async Task It_Should_Order_By_Asc_String()
        {
            var filters = new Filters(new List<Filter>());
            var criteria = new Criteria(filters, Order.FromValues("name","asc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(result, _items.OrderBy(x => x.Name));
        }
        
        [Fact]
        public async Task It_Should_Order_By_Desc_Int()
        {
            var filters = new Filters(new List<Filter>());
            var criteria = new Criteria(filters, Order.FromValues("priority","desc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(result, _items.OrderByDescending(x => x.Priority));
        }
        
        [Fact]
        public async Task It_Should_Order_By_Desc_String()
        {
            var filters = new Filters(new List<Filter>());
            var criteria = new Criteria(filters, Order.FromValues("name","desc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(result, _items.OrderByDescending(x => x.Name));
        }
    }
}