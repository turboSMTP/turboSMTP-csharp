using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboSMTP.Domain;
using TurboSMTP.Model.Shared;
using TurboSMTP.Model.Suppressions;
using Suppression = TurboSMTP.Domain.Suppression;


namespace TurboSMTP.Services
{
    public sealed class Suppressions
    {
        ISuppressionsApiAsync API;
        String TimeZone = "00:00";
        private Suppressions()
        {
            
        }

        public Suppressions(Configuration configuration, string timeZone)
        {
            API = new SuppressionsApi(configuration);
            this.TimeZone = timeZone;
        }

        public async Task<SuppressionsAddResult> AddRangeAsync(String reason, List<string> emailAddresses)
        {
            var result = await API.ImportSuppressionsAsync(new SuppressionImportJson(SuppressionImportJson.TypeEnum.Manual, reason, emailAddresses));

            return new SuppressionsAddResult(
                result.Status,
                result.Valid,
                result.Invalid
                );
        }
        public async Task<SuppressionsAddResult> AddAsync(string reason, string emailAddress)
        {
            return await AddRangeAsync(reason, new List<string> { emailAddress });
        }

        public async Task<PagedListResults<Suppression>> QueryAsync(SuppressionsQueryOptions options)
        {
            var suppressionFilterOrderPageRequestBody = new SuppressionFilterOrderPageRequestBody(options.From, options.To) {
                Page = options.Page,
                Limit = options.Limit,
                Tz = TimeZone,
                Filter = options.Filter,
                FilterBy = options.FilterBy != null ? options.FilterBy.Select(f => (SuppressionSource)f).ToList() : null,
                SmartSearch = options.SmartSearch,
                Orderby = (SuppressionOrderBy)options.OrderBy,
                Ordertype = (API.TurboSMTP.Model.OrderType)options.OrderType,
                Restrict = options.Restrictions != null ? options.Restrictions.Select(r => new SuppressionRestriction(
                    (SuppressionRestrictBy)r.By,
                    (SuppressionOperator)r.Operator,
                    r.Filter,
                    r.SmartSearch
                )).ToList() : null
            };
            var response = await API.FilterSuppressionsAsync(suppressionFilterOrderPageRequestBody);

            return new PagedListResults<Suppression>()
            {
                TotalRecords = response.Count,
                Records = response.Results.Select(r => new Suppression(r.Date, r.Sender, (SuppresionSource)r.Source, r.Subject, r.Recipient, r.Reason)).ToList()
            };
        }

        public async Task<string> ExportAsync(SuppressionsExportOptions options)
        {
            var response = await API.ExportFilterSuppressionsAsync(new SuppressionFilterRequestBody(options.From, options.To)
            {
                Tz = TimeZone,
                Filter = options.Filter,
                FilterBy = options.FilterBy != null ? options.FilterBy.Select(f => (SuppressionSource)f).ToList() : null,
                SmartSearch = options.SmartSearch,
                Restrict = options.Restrictions != null ? options.Restrictions.Select(r => new SuppressionRestriction(
                    (SuppressionRestrictBy)r.By,
                    (SuppressionOperator)r.Operator,
                    r.Filter,
                    r.SmartSearch
                )).ToList() : null
            });

            return response;
        }


        public async Task<bool> DeleteRangeAsync(List<string> emails)
        {
            if (emails == null || emails.Count == 0)
                return false;
            var resp = await API.BulkDeleteSuppressionsAsync(emails);
            return resp.Success;
        }
        public async Task<bool> DeleteAsync(string email)
        {
            if (String.IsNullOrEmpty(email))
                return false;
            return await DeleteRangeAsync(new List<string>() { email });
        }
        public async Task<bool> DeleteAsync(SuppressionsDeleteOptions options)
        {
            var suppressionFilterRequestBody = new SuppressionFilterRequestBody(options.From, options.To)
            {
                Tz = TimeZone,
                Filter = options.Filter,
                FilterBy = options.FilterBy != null ? options.FilterBy.Select(f => (SuppressionSource)f).ToList() : null,
                SmartSearch = options.SmartSearch,
                Restrict = options.Restrictions?.Select(r => new SuppressionRestriction(
                    (SuppressionRestrictBy)r.By,
                    (SuppressionOperator)r.Operator,
                    r.Filter,
                    r.SmartSearch
                )).ToList(),
            };
            var response = await API.DeleteFilterSuppressionsAsync(suppressionFilterRequestBody);
            return response.Success;
        }
    }
}
