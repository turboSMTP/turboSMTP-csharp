using API.TurboSMTP.Api;
using API.TurboSMTP.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using TurboSMTPSDK.Model.Analytics;
using TurboSMTPSDK.Model.Shared;

namespace TurboSMTPSDK.Services
{
    public sealed class Analytics
    {
        private Analytics()
        {
            
        }
        private readonly TurboSMTPClient turboSMTP;
        IAnalyticsApiAsync API;
        public Analytics(TurboSMTPClient turboSMTP, string consumerkey, string consumerSecret)
        {
            this.turboSMTP = turboSMTP;
            var config = new API.TurboSMTP.Client.Configuration();
            config.AddApiKeyPrefix("consumerKey", consumerkey);
            config.AddApiKeyPrefix("consumerSecret", consumerSecret);
            //config.BasePath = "https://google.api.serversmtp.com/api/v2";
            API = new AnalyticsApi(config);
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
