using TurboSMTP.Model.Shared;

namespace TurboSMTP.Model.Suppressions
{
    public class SuppressionsQueryOptions : SuppressionsBaseOptions<SuppressionsQueryOptions,SuppressionsQueryOptions.Builder>, IPagingOptions
    { 
        public int? Page { get; private set; }
        public int? Limit { get; private set; }
        public SuppressionsOrderByOption OrderBy { get; private set; } = SuppressionsOrderByOption.Date;
        public OrderType OrderType { get; private set; } = OrderType.Desc;

        public class Builder : SuppressionsBaseOptions<SuppressionsQueryOptions,Builder>.BaseBuilder
        {
            public Builder() : base(new SuppressionsQueryOptions()) { }

            public Builder SetPage(int? page)
            {
                _options.Page = page;
                return this;
            }

            public Builder SetLimit(int? limit)
            {
                _options.Limit = limit;
                return this;
            }

            public Builder SetOrderBy(SuppressionsOrderByOption orderBy)
            { 
                _options.OrderBy = orderBy;
                return this;
            }

            public Builder SetOrderType(OrderType orderType)
            {
                _options.OrderType = orderType;
                return this;
            }
        }
    }
}
