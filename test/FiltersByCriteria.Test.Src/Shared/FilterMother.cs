using src.CsharpBasicSkeleton.Shared.Domain.FiltersByCriteria;

namespace FiltersByCriteria.Test.Src.Shared
{
    public static class FilterMother
    {
        public static Filter Create(string field, string @operator, string value)
        {
            return new Filter(new FilterField(field), @operator.FilterOperatorFromValue(), new FilterValue(value));
        }
        
        public static Filter Create(string field, FilterOperator @operator, string value)
        {
            return new Filter(new FilterField(field),  @operator, new FilterValue(value));
        }

        public static Filter CreateDefault()
        {
            return new Filter(new FilterField("name"), FilterOperator.EQUAL, new FilterValue("Item 1"));
        }
        
        public static Filter CreateByOperator(FilterOperator @operator)
        {
            return new Filter(new FilterField("name"), @operator, new FilterValue("Item 1"));
        }
    }
}