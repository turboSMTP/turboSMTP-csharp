using API.TurboSMTP.Api;
using API.TurboSMTP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboSMTPSDK.Model.Shared;
using TurboSMTPSDK.Model.Suppressions;
using Suppression = TurboSMTPSDK.Model.Suppressions.Suppression;

namespace TurboSMTPSDK.Services
{
    public sealed class Suppressions
    {
        private Suppressions()
        {
            
        }
        private readonly TurboSMTPClient turboSMTP;
        ISuppressionsApiAsync API;
        public Suppressions(TurboSMTPClient turboSMTP, string consumerkey, string consumerSecret)
        {
            this.turboSMTP = turboSMTP;
            var config = new API.TurboSMTP.Client.Configuration();
            //config.BasePath
            config.AddApiKeyPrefix("consumerKey", consumerkey);
            config.AddApiKeyPrefix("consumerSecret", consumerSecret);
            API = new SuppressionsApi(config);
        }

        private PagedListResults<Suppression> GetPagedListResults(SuppressionsSucessResponsetBody response)
        {
            return new PagedListResults<Suppression>()
            {
                TotalRecords = response.Count,
                Records = response.Results.Select(r => new Suppression(r.Date, r.Sender, (Source)r.Source, r.Subject, r.Recipient, r.Reason)).ToList()
            };
        }

        public async Task<PagedListResults<Suppression>> List(DateTime from, DateTime to)
        {
            return await List(from, to, new ListOptions());
        }

        public async Task<PagedListResults<Suppression>> List(DateTime from, DateTime to, ListOptions options)
        {

            var response = await API.GetSuppressionsAsync(
                from,
                to,
                options.page,
                options.limit,
                options.tz,
                options.filter,
                options.filterBy!=null ? options.filterBy.Select(f => (SuppressionSource)f).ToList() : null,
                options.smartSearch,
                (SuppressionOrderBy)options.orderby,
                (API.TurboSMTP.Model.OrderType)options.ordertype,
                0);

            return GetPagedListResults(response);
        }

        public async Task<PagedListResults<Suppression>> List(DateTime from, DateTime to, ListOptions options, List<AdvancedFilter> restrictions)
        {
            var suppressionFilterOrderPageRequestBody = new SuppressionFilterOrderPageRequestBody(from, to) {
                Page = options.page,
                Limit = options.limit,
                Tz = options.tz,
                Filter = options.filter,
                FilterBy = options.filterBy != null ? options.filterBy.Select(f => (SuppressionSource)f).ToList() : null,
                SmartSearch = options.smartSearch,
                Orderby = (SuppressionOrderBy)options.orderby,
                Ordertype = (API.TurboSMTP.Model.OrderType)options.ordertype,
                Restrict = restrictions.Select(r => new SuppressionRestriction(
                    (SuppressionRestrictBy)r.By,
                    (SuppressionOperator)r.Operator,
                    r.Filter,
                    r.SmartSearch
                )).ToList(),
            };
            var response = await API.FilterSuppressionsAsync(suppressionFilterOrderPageRequestBody);
            return GetPagedListResults(response);
        }

        public async Task<string> Export(DateTime from, DateTime to)
        {
            return await Export(from, to, new ExportOptions());
        }

        public async Task<string> Export(DateTime from, DateTime to, ExportOptions options)
        {
            var response = await API.ExportSuppressionsDataCSVAsync(
                from,
                to,
                options.tz,
                options.filter,
                options.filterBy != null ? options.filterBy.Select(f => (SuppressionSource)f).ToList() : null,
                options.smartSearch,
                (SuppressionOrderBy)options.orderby,
                (API.TurboSMTP.Model.OrderType)options.ordertype,
                0);

            return response;
        }

        public async Task<string> Export(DateTime from, DateTime to, ExportOptions options, List<AdvancedFilter> restrictions)
        {
            var response = await API.ExportFilterSuppressionsAsync(new SuppressionFilterRequestBody(from, to)
            {
                Tz = options.tz,
                Filter = options.filter,
                FilterBy = options.filterBy != null ? options.filterBy.Select(f => (SuppressionSource)f).ToList() : null,
                SmartSearch = options.smartSearch,
                Restrict = restrictions.Select(r => new SuppressionRestriction(
                    (SuppressionRestrictBy)r.By,
                    (SuppressionOperator)r.Operator,
                    r.Filter,
                    r.SmartSearch
                )).ToList()
            });

            return response;
        }

        public async Task<AddResult> AddRange(String reason, List<string> emailAddresses)
        {
            var result = await API.ImportSuppressionsAsync(new SuppressionImportJson(SuppressionImportJson.TypeEnum.Manual, reason, emailAddresses));

            return new AddResult(
                result.Status,
                result.Valid,
                result.Invalid
                );
        }
        public async Task<AddResult> Add(string reason, string emailAddress)
        {
            return await AddRange(reason, new List<string> {emailAddress });
        }
        public async Task<bool> DeleteRange(List<string> emails)
        {
            if (emails == null || emails.Count == 0)
                return false;
            var resp = await API.BulkDeleteSuppressionsAsync(emails);
            return resp.Success;
        }
        public async Task<bool> Delete(string email)
        {
            if (String.IsNullOrEmpty(email))
                return false;
            return await DeleteRange(new List<string>() { email });
        }

        public async Task<bool> Delete(DateTime from, DateTime to, DeleteOptions options, List<AdvancedFilter> restrictions)
        {
            var suppressionFilterRequestBody = new SuppressionFilterRequestBody(from, to)
            {
                Tz = options?.tz,
                Filter = options?.filter,
                FilterBy = options?.filterBy != null ? options?.filterBy.Select(f => (SuppressionSource)f).ToList() : null,
                SmartSearch = options?.smartSearch,
                Restrict = restrictions?.Select(r => new SuppressionRestriction(
                    (SuppressionRestrictBy)r.By,
                    (SuppressionOperator)r.Operator,
                    r.Filter,
                    r.SmartSearch
                )).ToList(),
            };
            var response = await API.DeleteFilterSuppressionsAsync(suppressionFilterRequestBody);
            return response.Success;
        }

        public async Task<bool> Delete(DateTime from, DateTime to, DeleteOptions options)
        {
            return await Delete(from, to, options, null);
        }


        public async Task<bool> Delete(DateTime from, DateTime to)
        {
            return await Delete(from, to, null);
        }

    }
}
