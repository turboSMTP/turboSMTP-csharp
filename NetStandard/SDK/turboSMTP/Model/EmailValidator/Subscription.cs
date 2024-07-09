using API.TurboSMTP.Model;
using System;
using System.Text;
using TurboSMTP.Model.Extensions;

namespace TurboSMTP.Model.EmailValidator
{
    public sealed class Subscription
    {
        private Subscription() { }
        public Subscription(Currency currency = default(Currency), int freeCredits = default(int), int freeCreditsUsed = default(int), string lastUsedPeriod = default(string), string latestPeriodStartDate = default(string), string periodExpirationDate = default(string), decimal paidCredits = default(decimal), int remainingFreeCredit = default(int))
        {
            this.Currency = currency;
            this.FreeCredits = freeCredits;
            this.FreeCreditsUsed = freeCreditsUsed;
            this.LastUsedPeriod = lastUsedPeriod.FromNullableTSDatetimes();
            this.LatestPeriodStartDate = latestPeriodStartDate.FromTSDatetimes();
            this.PeriodExpirationDate = periodExpirationDate.FromTSDatetimes();
            this.PaidCredits = paidCredits;
            this.RemainingFreeCredit = remainingFreeCredit;
        }
        public Currency Currency { get; set; }
        public int FreeCredits { get; set; }
        public int FreeCreditsUsed { get; set; }
        public DateTime? LastUsedPeriod { get; set; }
        public DateTime LatestPeriodStartDate { get; set; }
        public DateTime PeriodExpirationDate { get; set; }
        public decimal PaidCredits { get; set; }
        public int RemainingFreeCredit { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EmailValidatorSubscription {\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  FreeCredits: ").Append(FreeCredits).Append("\n");
            sb.Append("  FreeCreditsUsed: ").Append(FreeCreditsUsed).Append("\n");
            sb.Append("  LastUsedPeriod: ").Append(LastUsedPeriod).Append("\n");
            sb.Append("  LatestPeriodStartDate: ").Append(LatestPeriodStartDate).Append("\n");
            sb.Append("  PeriodExpirationDate: ").Append(PeriodExpirationDate).Append("\n");
            sb.Append("  PaidCredits: ").Append(PaidCredits).Append("\n");
            sb.Append("  RemainingFreeCredit: ").Append(RemainingFreeCredit).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
