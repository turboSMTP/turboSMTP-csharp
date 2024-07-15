using System;

namespace TurboSMTP.Model.EmailValidator
{
    public class EmailValidatorFileResultsQueryOptions
    {
        public int? Page { get; private set; }
        public int? Limit { get; private set; }

        public int FileId { get; private set; }

        private EmailValidatorFileResultsQueryOptions() {}

        public class Builder
        {
            private readonly EmailValidatorFileResultsQueryOptions _options;

            public Builder()
            {
                _options = new EmailValidatorFileResultsQueryOptions();
            }

            public Builder SetFileId(int fileId)
            {
                _options.FileId = fileId;
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
                if (_options.FileId == 0)
                {
                    throw new InvalidOperationException("File ID is required");
                }
            }

            public EmailValidatorFileResultsQueryOptions Build()
            {
                Validate();
                return _options;
            }
        }
    }
}
