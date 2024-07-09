using System;
using TurboSMTP.Domain;
using TurboSMTP.Model.Shared;

namespace TurboSMTP.Model.Relays
{
    public class RelaysBaseOptions<TOptions, TBuilder> : IDateRange
    where TOptions : RelaysBaseOptions<TOptions, TBuilder>, new()
    where TBuilder : RelaysBaseOptions<TOptions, TBuilder>.BaseBuilder, new()
    {
        public RelayStatus[] RelayStatuses { get; private set; } = default(RelayStatus[]);
        public RelayFilterCriteria[] FilterBy { get; private set; } = default(RelayFilterCriteria[]);
        public string Filter { get; private set; } = default(string);
        public bool? SmartSearch { get; private set; } = default(bool?);
        public RelayOrderByOption Orderby { get; private set; } = RelayOrderByOption.SendTime;
        public OrderType Ordertype { get; private set; } = OrderType.Desc;
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public abstract class BaseBuilder
        {
            protected TOptions _options = new TOptions();

            protected BaseBuilder(TOptions options)
            {
                _options = options;
            }

            public TBuilder SetRelayStatuses(RelayStatus[] relayStatuses)
            {
                _options.RelayStatuses = relayStatuses;
                return (TBuilder)this;
            }

            public TBuilder SetFilterBy(RelayFilterCriteria[] filterBy)
            {
                _options.FilterBy = filterBy;
                return (TBuilder)this;
            }

            public TBuilder SetFilter(string filter)
            {
                _options.Filter = filter;
                return (TBuilder)this;
            }

            public TBuilder SetSmartSearch(bool? smartSearch)
            {
                _options.SmartSearch = smartSearch;
                return (TBuilder)this;
            }

            public TBuilder SetOrderBy(RelayOrderByOption orderBy)
            {
                _options.Orderby = orderBy;
                return (TBuilder)this;
            }

            public TBuilder SetOrderType(OrderType orderType)
            {
                _options.Ordertype = orderType;
                return (TBuilder)this;
            }

            public TBuilder SetFrom(DateTime date)
            {
                _options.From = date;
                return (TBuilder)this;
            }

            public TBuilder SetTo(DateTime date)
            {
                _options.To = date;
                return (TBuilder)this;    
            }

            private void Validate()
            {
                if(_options.From == null)
                {
                    throw new InvalidOperationException("From parameter is required");
                }
                if (_options.To == null)
                {
                    throw new InvalidOperationException("To parameter is required");
                }
            }

            public TOptions Build()
            {
                Validate();
                return _options;
            }
        }
    }
}
