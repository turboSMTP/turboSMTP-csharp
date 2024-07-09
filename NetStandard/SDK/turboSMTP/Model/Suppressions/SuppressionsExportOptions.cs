using TurboSMTP.Model.Shared;

namespace TurboSMTP.Model.Suppressions
{
    public class SuppressionsExportOptions : SuppressionsBaseOptions<SuppressionsExportOptions,SuppressionsExportOptions.Builder>
    { 
        public SuppressionsOrderByOption OrderBy { get; private set; } = SuppressionsOrderByOption.Date;
        public OrderType OrderType { get; private set; } = OrderType.Desc;

        public class Builder : SuppressionsBaseOptions<SuppressionsExportOptions,Builder>.BaseBuilder
        {
            public Builder() : base(new SuppressionsExportOptions()) { }

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
