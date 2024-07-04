using API.TurboSMTP.Api;
using API.TurboSMTP.Client;
using API.TurboSMTP.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using TurboSMTP;
using TurboSMTPSDK.Model.Analytics;
using TurboSMTPSDK.Model.Shared;

namespace TurboSMTPSDK.Services
{
    public sealed class Analytics
    {
        IAnalyticsApiAsync API;

        private Analytics()
        {
            
        }

        public Analytics(Configuration configuration)
        {
            API = new AnalyticsApi(configuration);
        }

        private PagedListResults<Analytic> GetPagedListResults(AnalyticsListSucessResponsetBody response)
        {
            return new PagedListResults<Analytic>()
            {
                TotalRecords = response.Count,
                Records = response.Results.Select(r => new Analytic(
                    r.Id,
                    r.Subject,
                    r.Sender,
                    r.Recipient,
                    r.SendTime,
                    (MailStatus)r.Status.Value,
                    r.Domain,
                    r.ContactDomain,
                    r.Error
                    )
                ).ToList()
            };
        }

        public async Task<PagedListResults<Analytic>> List(DateTime from, DateTime to)
        {
            return await List(from, to, new ListOptions());
        }

        public async Task<PagedListResults<Analytic>> List(DateTime from, DateTime to, ListOptions options)
        {

            var response = await API.GetAnalyticsDataAsync(
                from,
                to,
                options.page,
                options.limit,
                options.MailStatuses!= null ?options.MailStatuses.Select(ms=>(AnalyticMailStatus)ms).ToList() : null,
                options.filterBy!=null ? options.filterBy.Select(f => (AnalyticFilterByOption)f).ToList() : null,
                options.filter,
                options.smartSearch,
                (AnalyticOrderBy)options.orderby,
                (API.TurboSMTP.Model.OrderType)options.ordertype,
                options.tz,
                0
                );

            return GetPagedListResults(response);
        }

        public async Task<string> Export(DateTime from, DateTime to)
        {
            return await Export(from, to, new ListOptions());
        }

        public async Task<string> Export(DateTime from, DateTime to, ListOptions options)
        {
            var response = await API.ExportAnalyticsDataCSVAsync(
                from,
                to,
                options.MailStatuses != null ? options.MailStatuses.Select(ms => (AnalyticMailStatus)ms).ToList() : null,
                options.filterBy != null ? options.filterBy.Select(f => (AnalyticFilterByOption)f).ToList() : null,
                options.filter,
                options.smartSearch,
                (AnalyticOrderBy)options.orderby,
                (API.TurboSMTP.Model.OrderType)options.ordertype,
                options.tz
                );

            return response;
        }
    }
}
