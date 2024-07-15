using System;
using System.Text;

namespace TurboSMTP.Model.EmailValidator
{
    public class EmailAddressValidationDetails
    {
        public enum EmailAddressValidationStatus
        {
            Valid = 1,
            Invalid = 2,
            CatchAll = 3,
            Unknown = 4,
            Spamtrap = 5,
            Abuse = 6,
            DoNotMail = 7
        }

        public EmailAddressValidationStatus? Status { get; set; }
        public enum EmailAddressValidationSubStatus
        {
            Empty = 1,
            AntispamSystem = 2,
            Greylisted = 3,
            MailServerTemporaryError = 4,
            ForcibleDisconnect = 5,
            MailServerDidNotRespond = 6,
            TimeoutExceeded = 7,
            FailedSmtpConnection = 8,
            MailboxQuotaExceeded = 9,
            ExceptionOccurred = 10,
            PossibleTrap = 11,
            RoleBased = 12,
            GlobalSuppression = 13,
            MailboxNotFound = 14,
            NoDnsEntries = 15,
            FailedSyntaxCheck = 16,
            PossibleTypo = 17,
            UnroutableIpAddress = 18,
            LeadingPeriodRemoved = 19,
            DoesNotAcceptMail = 20,
            AliasAddress = 21,
            RoleBasedCatchAll = 22,
            Disposable = 23,
            Toxic = 24
        }

        public EmailAddressValidationSubStatus? SubStatus { get; set; }
        protected EmailAddressValidationDetails() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailValidatorMailDetailsBasic" /> class.
        /// </summary>
        /// <param name="email">email (required).</param>
        /// <param name="status"> The status of the email address you are validating.    DELIVERABILITY STATUS EXPLANATION    valid:   These are emails that were determined to be valid and safe to email to, they will have a very low bounce rate of under 2%. If you receive bounces it can be because your IP might be blacklisted where our IP was not. Sometimes the email accounts exist, but they are only accepting mail from people in their contact lists. Sometimes you will get throttle on number of emails you can send to a specific domain per hour. It&#39;s important to look at the SMTP Bounce codes to determine why.      invalid:   These are emails that were determined to be invalid, please delete them from your mailing list.      catch-all:    These emails are impossible to validate without sending a real email and waiting for a bounce. The term Catch-all means that the email server tells you that the email is valid, whether it&#39;s valid or invalid. If you want to email these addresses, we suggest you segment them into a catch-all group and be aware that some of these will most likely bounce.      spamtrap:    These emails are believed to be spamtraps and should not be mailed. We have technology in place to determine if certain emails should be classified as spamtrap. We don&#39;t know all the spamtrap email addresses, but we do know a lot of them.      abuse:    These emails belong to people who are known to click the abuse links in emails, hence abusers or complainers. We recommend not emailing these addresses.      do_not_mail:    These emails belong to companies, role-based, or people you just want to avoid emailing to. They are broken down into 6 sub-categories \&quot;disposable\&quot;,\&quot;toxic\&quot;, \&quot;role_based\&quot;, \&quot;role_based_catch_all\&quot;, \&quot;global_suppression\&quot; and \&quot;possible_trap\&quot;. You should decide if you want to email these address. They are valid email addresses, but shouldn&#39;t be mailed in most cases.      unknown:    These emails we weren&#39;t able to validate for one reason or another. Typical cases are \&quot;Their mail server was down\&quot; or \&quot;the anti-spam system is blocking us\&quot;. In most cases, 80% unknowns are invalid/bad email addresses. .</param>
        /// <param name="subStatus">The sub-status of the email address you are validating.  alias_address:  (valid) These emails addresses act as forwarders/aliases and are not real inboxes, for example if you send an email to forward@example.com and then the email is forwarded to realinbox@example.com. It&#39;s a valid email address and you can send to them, it&#39;s just a little more information about the email address. We can sometimes detect alias email addresses and when we do we let you know.  antispam_system:  (unknown) These emails have anti-spam systems deployed that are preventing us from validating these emails.  does_not_accept_mail:  (invalid) These domains only send mail and don&#39;t accept incoming mail.  exception_occurred:  (unknown) These emails caused an exception when validating.  failed_smtp_connection:  (unknown) These emails belong to a mail server that won&#39;t allow an SMTP connection. Most of the time, these emails will end up being invalid.  failed_syntax_check:  (Invalid) Emails that fail RFC syntax protocols  forcible_disconnect:  (Unknown) These emails belong to a mail server that disconnects immediately upon connecting. Most of the time, these emails will end up being invalid. global_suppression:  (do_not_mail) These emails are found in many popular global suppression lists (GSL), they consist of known ISP complainers, direct complainers, purchased addresses, domains that don&#39;t send mail, and known litigators.  greylisted:  (Unknown) Emails where we are temporarily unable to validate them. A lot of times if you resubmit these emails they will validate on a second pass.  leading_period_removed:  (valid) If a valid gmail.com email address starts with a period &#39;.&#39; we will remove it, so the email address is compatible with all mailing systems.  mail_server_did_not_respond-  (unknown) These emails belong to a mail server that is not responding to mail commands. Most of the time, these emails will end up being invalid.  mail_server_temporary_error:  (unknown) These emails belong to a mail server that is returning a temporary error. Most of the time, these emails will end up being invalid. mailbox_quota_exceeded:  (invalid) These emails exceeded their space quota and are not accepting emails. These emails are marked invalid.  mailbox_not_found:  (invalid) These emails addresses are valid in syntax, but do not exist. These emails are marked invalid.  no_dns_entries:  (invalid) These emails are valid in syntax, but the domain doesn&#39;t have any records in DNS or have incomplete DNS Records. Therefore, mail programs will be unable to or have difficulty sending to them. These emails are marked invalid.  possible_trap:  (do_not_mail) These emails contain keywords that might correlate to possible spam traps like spam@ or @spamtrap.com. Examine these before deciding to send emails to them or not.  possible_typo:  (invalid) These are emails of commonly misspelled popular domains. These emails are marked invalid.  role_based:  (do_not_mail) These emails belong to a position or a group of people, like sales@ info@ and contact@. Role-based emails have a strong correlation to people reporting mails sent to them as spam and abuse.  role_based_catch_all:  (do_not_mail) These emails are role-based and also belong to a catch_all domain.  timeout_exceeded:  (unknown) These emails belong to a mail server that is responding extremely slow. Most of the time, these emails will end up being invalid.  unroutable_ip_address: (invalid) These emails domains point to an un-routable IP address, these are marked invalid.  disposable:  (do_not_mail) These are temporary emails created for the sole purpose to sign up to websites without giving their real email address. These emails are short lived from 15 minutes to around 6 months. There is only 2 values (True and False). If you have valid emails with this flag set to TRUE, you shouldn&#39;t email them.  toxic:  (do_not_mail) These email addresses are known to be abuse, spam, or bot created emails. If you have valid emails with this flag set to TRUE, you shouldn&#39;t email them. .</param>
        /// <param name="freeEmail">True if the email address comes from a free email service provider..</param>
        /// <param name="domain">The portion of the email address after the \&quot;@\&quot; symbol..</param>
        /// <param name="domainAgeDays">Age of the email domain in days or [null]..</param>
        /// <param name="smtpProvider">The SMTP Provider of the email or [null]..</param>
        /// <param name="mxFound">True if the domain have an MX record..</param>
        /// <param name="mxRecord">The preferred MX record of the domain.</param>
        /// <param name="id">the id of the email address.</param>
        public EmailAddressValidationDetails(string email = default(string), EmailAddressValidationStatus? status = default(EmailAddressValidationStatus?), EmailAddressValidationSubStatus? subStatus = default(EmailAddressValidationSubStatus?), bool freeEmail = default(bool), string domain = default(string), int? domainAgeDays = default(int?), string smtpProvider = default(string), bool mxFound = default(bool), string mxRecord = default(string), int id = default(int))
        {
            // to ensure "email" is required (not null)
            if (email == null)
            {
                throw new ArgumentNullException("email is a required property for EmailValidatorMailDetailsBasic and cannot be null");
            }
            this.Email = email;
            this.Status = status;
            this.SubStatus = subStatus;
            this.FreeEmail = freeEmail;
            this.Domain = domain;
            this.DomainAgeDays = domainAgeDays;
            this.SmtpProvider = smtpProvider;
            this.MxFound = mxFound;
            this.MxRecord = mxRecord;
            this.Id = id;
        }

        public string Email { get; set; }
        public bool FreeEmail { get; set; }
        public string Domain { get; set; }
        public int? DomainAgeDays { get; set; }
        public string SmtpProvider { get; set; }
        public bool MxFound { get; set; }
        public string MxRecord { get; set; }
        public int Id { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EmailValidatorMailDetailsBasic {\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  SubStatus: ").Append(SubStatus).Append("\n");
            sb.Append("  FreeEmail: ").Append(FreeEmail).Append("\n");
            sb.Append("  Domain: ").Append(Domain).Append("\n");
            sb.Append("  DomainAgeDays: ").Append(DomainAgeDays).Append("\n");
            sb.Append("  SmtpProvider: ").Append(SmtpProvider).Append("\n");
            sb.Append("  MxFound: ").Append(MxFound).Append("\n");
            sb.Append("  MxRecord: ").Append(MxRecord).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }

}
