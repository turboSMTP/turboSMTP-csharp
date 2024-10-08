using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using TurboSMTP.Domain;
using TurboSMTP.Model.Relays;
using TurboSMTP.Model.Shared;

namespace TurboSMTP.Services
{
    public sealed class Relays
    {
        IAnalyticsApiAsync API;
        String TimeZone = "00:00";

        private Relays()
        {
            
        }

        public Relays(Configuration configuration, string timeZone)
        {
            API = new AnalyticsApi(configuration);
            TimeZone = timeZone;
        }

        public async Task<PagedListResults<Relay>> QueryAsync(RelaysQueryOptions queryOptions)
        {

            var response = await API.GetAnalyticsDataAsync(
                queryOptions.From,
                queryOptions.To,
                queryOptions.Page,
                queryOptions.Limit,
                queryOptions.RelayStatuses!= null ? queryOptions.RelayStatuses.Select(ms=>(AnalyticMailStatus)ms).ToList() : null,
                queryOptions.FilterBy!=null ? queryOptions.FilterBy.Select(f => (AnalyticFilterByOption)f).ToList() : null,
                queryOptions.Filter,
                queryOptions.SmartSearch,
                (AnalyticOrderBy)queryOptions.Orderby,
                (API.TurboSMTP.Model.OrderType)queryOptions.Ordertype,
                TimeZone
                );

            return new PagedListResults<Relay>()
            {
                TotalRecords = response.Count,
                Records = response.Results.Select(r => new Relay(
                    r.Id,
                    r.Subject,
                    r.Sender,
                    r.Recipient,
                    r.SendTime,
                    (RelayStatus)r.Status.Value,
                    r.Domain,
                    r.ContactDomain,
                    r.Error,
                    r.XCampaignId
                    )
                ).ToList()
            };
        }

        public async Task<string> ExportAsync(RelaysExportOptions options)
        {
            var response = await API.ExportAnalyticsDataCSVAsync(
                options.From,
                options.To,
                options.RelayStatuses != null ? options.RelayStatuses.Select(ms => (AnalyticMailStatus)ms).ToList() : null,
                options.FilterBy != null ? options.FilterBy.Select(f => (AnalyticFilterByOption)f).ToList() : null,
                options.Filter,
                options.SmartSearch,
                (AnalyticOrderBy)options.Orderby,
                (API.TurboSMTP.Model.OrderType)options.Ordertype,
                TimeZone
                );

            return response;
        }
    }
}
