using System;
using System.Collections.Generic;
using TurboSMTP.Domain;
using TurboSMTP.Model.Shared;

namespace TurboSMTP.Model.Suppressions
{
    public class SuppressionsBaseOptions<TOptions, TBuilder> : IDateRange
    where TOptions : SuppressionsBaseOptions<TOptions, TBuilder>, new()
    where TBuilder : SuppressionsBaseOptions<TOptions, TBuilder>.BaseBuilder, new()
    {
        public string Filter { get; private set; } = default(string);
        public SuppresionSource[] FilterBy { get; private set; } = default(SuppresionSource[]);
        public bool? SmartSearch { get; private set; } = default(bool?);
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public SuppressionsRestriction[] Restrictions { get; private set; }

        public abstract class BaseBuilder
        {
            protected TOptions _options = new TOptions();

            protected BaseBuilder(TOptions options)
            {
                _options = options;
            }

            public TBuilder SetFilterBy(SuppresionSource[] filterBy)
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

            public TBuilder SetRestrictions(SuppressionsRestriction[] restrictions)
            {
                _options.Restrictions = restrictions;
                return (TBuilder)this;
            }

            protected virtual void Validate()
            {
                if (_options.From == null)
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
