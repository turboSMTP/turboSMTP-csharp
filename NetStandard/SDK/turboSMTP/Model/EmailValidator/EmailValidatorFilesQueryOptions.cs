using System;
using TurboSMTP.Model.Shared;

namespace TurboSMTP.Model.EmailValidator
{
    public class EmailValidatorFilesQueryOptions : IDateRange
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public int? Page { get; private set; }
        public int? Limit { get; private set; }

        private EmailValidatorFilesQueryOptions() { }

        public class Builder
        {
            private readonly EmailValidatorFilesQueryOptions _options;

            public Builder()
            {
                _options = new EmailValidatorFilesQueryOptions();
            }

            public Builder SetFrom(DateTime from)
            {
                _options.From = from;
                return this;
            }

            public Builder SetTo(DateTime to)
            {
                _options.To = to;
                return this;
            }

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

            private void Validate()
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

            public EmailValidatorFilesQueryOptions Build()
            {
                Validate();
                return _options;
            }
        }
    }
}
