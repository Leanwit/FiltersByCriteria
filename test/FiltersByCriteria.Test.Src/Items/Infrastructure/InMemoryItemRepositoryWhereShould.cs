using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltersByCriteria.Test.Src.Shared;
using src.CsharpBasicSkeleton.Items.Domain;
using src.CsharpBasicSkeleton.Items.Infrastructure;
using src.CsharpBasicSkeleton.Shared.Domain.FiltersByCriteria;
using Xunit;

namespace FiltersByCriteria.Test.Src.Items.Infrastructure
{
    public class InMemoryItemRepositoryWhereShould
    {
        private readonly InMemoryItemRepository _repository;
        private readonly List<Item> _items;
        public InMemoryItemRepositoryWhereShould()
        {
            _items = new List<Item>
            {
                new Item(new Guid("47f04654-6017-4b98-83db-c0e36a4ea698"), "Item 1", 3)
            };

            _repository = new InMemoryItemRepository(_items);
        }

        [Fact]
        public async Task It_should_find_an_existing_item_equal()
        {
            var filters = new Filters(new List<Filter> {FilterMother.CreateDefault()});
            var criteria = new Criteria(filters, Order.FromValues("name", "asc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(_items.Where(x => x.Name == "Item 1").ToList(), result);
        }

        [Fact]
        public async Task It_should_not_find_an_existing_item_not_equal()
        {
            var filters = new Filters(new List<Filter> {FilterMother.CreateByOperator(FilterOperator.NOT_EQUAL)});
            var criteria = new Criteria(filters, Order.FromValues("name", "asc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(_items.Where(x => x.Name != "Item 1").ToList(), result);
        }

        [Fact]
        public async Task It_should_find_an_existing_item_not_equal()
        {
            var filters = new Filters(new List<Filter> {FilterMother.Create("name", "!=", "item 1")});
            var criteria = new Criteria(filters, Order.FromValues("name", "asc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(_items.Where(x => x.Name != "item 1").ToList(), result);
        }
        
        [Fact]
        public async Task It_should_find_an_existing_item_greater_than_priority()
        {
            var filters = new Filters(new List<Filter> {FilterMother.Create("priority", ">", "2")});
            var criteria = new Criteria(filters, Order.FromValues("name", "asc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(_items.Where(x => x.Priority > 2).ToList(), result);
        }
        
        [Fact]
        public async Task It_should_not_find_an_existing_item_greater_than_priority()
        {
            var filters = new Filters(new List<Filter> {FilterMother.Create("priority", ">", "4")});
            var criteria = new Criteria(filters, Order.FromValues("name", "asc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(_items.Where(x => x.Priority > 4).ToList(), result);
        }
        
        [Fact]
        public async Task It_should_find_an_existing_item_less_than_priority()
        {
            var filters = new Filters(new List<Filter> {FilterMother.Create("priority", "<", "4")});
            var criteria = new Criteria(filters, Order.FromValues("name", "asc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(_items.Where(x => x.Priority < 4).ToList(), result);
        }
        
        [Fact]
        public async Task It_should_not_find_an_existing_item_less_than_priority()
        {
            var filters = new Filters(new List<Filter> {FilterMother.Create("priority", "<", "2")});
            var criteria = new Criteria(filters, Order.FromValues("name", "asc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(_items.Where(x => x.Priority < 2).ToList(), result);
        }
        
        //1
        [Fact]
        public async Task It_should_find_an_existing_item_contains()
        {
            var filters = new Filters(new List<Filter> {FilterMother.Create("name", "CONTAINS", "Item")});
            var criteria = new Criteria(filters, Order.FromValues("name", "asc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(_items.Where(x => x.Name.Contains("Item", StringComparison.CurrentCultureIgnoreCase)).ToList(), result);
        }
        
        [Fact]
        public async Task It_should_not_find_an_existing_item_contains()
        {
            var filters = new Filters(new List<Filter> {FilterMother.Create("name", "CONTAINS", "Items")});
            var criteria = new Criteria(filters, Order.FromValues("name", "asc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(_items.Where(x => x.Name.Contains("Items", StringComparison.CurrentCultureIgnoreCase)).ToList(), result);
        }
        //2
        [Fact]
        public async Task It_should_find_an_existing_item_not_contains()
        {
            var filters = new Filters(new List<Filter> { FilterMother.Create("name", "NOT_CONTAINS", "Items")});
            var criteria = new Criteria(filters, null, 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(_items.Where(x => !x.Name.Contains("Items", StringComparison.CurrentCultureIgnoreCase)).ToList(), result);
        }
        
        [Fact]
        public async Task It_should_not_find_an_existing_not_contains()
        {
            var filters = new Filters(new List<Filter> {FilterMother.Create("name", "NOT CONTAINS", "Item")});
            var criteria = new Criteria(filters, Order.FromValues("name", "asc"), 10, 0);

            var result = await _repository.Matching(criteria);
            Assert.Equal(_items.Where(x => !x.Name.Contains("Item", StringComparison.CurrentCultureIgnoreCase)).ToList(), result);
        }
    }
}