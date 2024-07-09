using TurboSMTP.Model.Shared;

namespace TurboSMTP.Model.Relays
{
    public class RelaysQueryOptions : RelaysBaseOptions<RelaysQueryOptions,RelaysQueryOptions.Builder>, IPagingOptions
    { 
        public int? Page { get; private set; }

        public int? Limit { get; private set; }

        public class Builder : RelaysBaseOptions<RelaysQueryOptions,Builder>.BaseBuilder
        {
            public Builder() : base(new RelaysQueryOptions()) { }

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
        }
    }
}
