/*
 * TurboSMTP Public APIs
 *
 * This document describes all public turboSMTP **V2** API and offers endpoints Descriptions, Parameters, Requests, Responses and Samples of usage.  [Click here to view the previous version of turboSMTP Public API Version 1.0](https://www.serversmtp.com/turbo-api-1)   # Security For the most part (and where not otherwise explicit) turboSMTP’s API requires Authorization.   Authorization to access a user’s resource is granted to clients provided they set  authentication headers into their request, valued with the proper values issued by turboSMTP servers.  ## *  Authorization via ConsumerKey/ConsumerSecret  This type of authorization consists of a pair of headers, named consumerKey and consumerSecret that are created and granted to the end user to be used in a permanent way (unless they´re deleted of course). This kind of authentication is intended to provide access to endpoints features without the need of providing the user the account details (email address + password).  *consumerKey:* Consumer Key Granted.  *consumerSecret:* Consumer Secret Granted.  (Use [/consumerKeys/create](#/consumerkey/createConsumerKey) create a consumer key/secret pair).      ## *  Authorization via Authentication Key  The authentication key is user-based and it is issued by turboSMTP servers upon successful user’s email address + password challenge, performed by means of appropriate request.      *Authorization:* Authorization_Key  (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  # Data Interchange Format  For the most part (and where not otherwise explicit) turboSMTP’s API uses JSON as the data format of choice when it comes to request and response bodies.       
 *
 * The version of the OpenAPI document: 2.0.0-oas3
 * Contact: api@turbo-smtp.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = API.TurboSMTP.Client.OpenAPIDateConverter;

namespace API.TurboSMTP.Model
{
    /// <summary>
    /// Email
    /// </summary>
    [DataContract(Name = "Email")]
    public partial class Email
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Email" /> class.
        /// </summary>
        /// <param name="from">from mail address.</param>
        /// <param name="to">comma-separated recipients emails list.</param>
        /// <param name="subject">email subject.</param>
        /// <param name="cc">comma-separated copy emails list.</param>
        /// <param name="bcc">comma-separated hidden copy emails list.</param>
        /// <param name="content">text content of the email.</param>
        /// <param name="htmlContent">html content of the email.</param>
        /// <param name="customHeaders">email additional headers, use any additional header like standard ones List-Unsubscribe (to allow users to easily unsubscribe), X-Entity-Ref-ID (to handle how gmail and other clients group threads), and your own ones.  .</param>
        /// <param name="referenceId">custom argument included within an email to be added to the Event Webhook response..</param>
        /// <param name="xCampaignID">custom argument included within an email identify the campaign the email belongs to..</param>
        /// <param name="mimeRaw">mime message which replaces content and hmtl content.</param>
        /// <param name="attachments">array of attachment objects.</param>
        public Email(string from = default(string), string to = default(string), string subject = default(string), string cc = default(string), string bcc = default(string), string content = default(string), string htmlContent = default(string), Dictionary<string, string> customHeaders = default(Dictionary<string, string>), string referenceId = default(string), string xCampaignID = default(string), string mimeRaw = default(string), List<Attachment> attachments = default(List<Attachment>))
        {
            this.From = from;
            this.To = to;
            this.Subject = subject;
            this.Cc = cc;
            this.Bcc = bcc;
            this.Content = content;
            this.HtmlContent = htmlContent;
            this.CustomHeaders = customHeaders;
            this.ReferenceId = referenceId;
            this.XCampaignID = xCampaignID;
            this.MimeRaw = mimeRaw;
            this.Attachments = attachments;
        }

        /// <summary>
        /// from mail address
        /// </summary>
        /// <value>from mail address</value>
        [DataMember(Name = "from", EmitDefaultValue = false)]
        public string From { get; set; }

        /// <summary>
        /// comma-separated recipients emails list
        /// </summary>
        /// <value>comma-separated recipients emails list</value>
        [DataMember(Name = "to", EmitDefaultValue = false)]
        public string To { get; set; }

        /// <summary>
        /// email subject
        /// </summary>
        /// <value>email subject</value>
        [DataMember(Name = "subject", EmitDefaultValue = true)]
        public string Subject { get; set; }

        /// <summary>
        /// comma-separated copy emails list
        /// </summary>
        /// <value>comma-separated copy emails list</value>
        [DataMember(Name = "cc", EmitDefaultValue = true)]
        public string Cc { get; set; }

        /// <summary>
        /// comma-separated hidden copy emails list
        /// </summary>
        /// <value>comma-separated hidden copy emails list</value>
        [DataMember(Name = "bcc", EmitDefaultValue = true)]
        public string Bcc { get; set; }

        /// <summary>
        /// text content of the email
        /// </summary>
        /// <value>text content of the email</value>
        [DataMember(Name = "content", EmitDefaultValue = true)]
        public string Content { get; set; }

        /// <summary>
        /// html content of the email
        /// </summary>
        /// <value>html content of the email</value>
        [DataMember(Name = "html_content", EmitDefaultValue = true)]
        public string HtmlContent { get; set; }

        /// <summary>
        /// email additional headers, use any additional header like standard ones List-Unsubscribe (to allow users to easily unsubscribe), X-Entity-Ref-ID (to handle how gmail and other clients group threads), and your own ones.  
        /// </summary>
        /// <value>email additional headers, use any additional header like standard ones List-Unsubscribe (to allow users to easily unsubscribe), X-Entity-Ref-ID (to handle how gmail and other clients group threads), and your own ones.  </value>
        [DataMember(Name = "custom_headers", EmitDefaultValue = true)]
        public Dictionary<string, string> CustomHeaders { get; set; }

        /// <summary>
        /// custom argument included within an email to be added to the Event Webhook response.
        /// </summary>
        /// <value>custom argument included within an email to be added to the Event Webhook response.</value>
        [DataMember(Name = "reference_id", EmitDefaultValue = true)]
        public string ReferenceId { get; set; }

        /// <summary>
        /// custom argument included within an email identify the campaign the email belongs to.
        /// </summary>
        /// <value>custom argument included within an email identify the campaign the email belongs to.</value>
        [DataMember(Name = "X-campaign-ID", EmitDefaultValue = true)]
        public string XCampaignID { get; set; }

        /// <summary>
        /// mime message which replaces content and hmtl content
        /// </summary>
        /// <value>mime message which replaces content and hmtl content</value>
        [DataMember(Name = "mime_raw", EmitDefaultValue = true)]
        public string MimeRaw { get; set; }

        /// <summary>
        /// array of attachment objects
        /// </summary>
        /// <value>array of attachment objects</value>
        [DataMember(Name = "attachments", EmitDefaultValue = false)]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Email {\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  Cc: ").Append(Cc).Append("\n");
            sb.Append("  Bcc: ").Append(Bcc).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  HtmlContent: ").Append(HtmlContent).Append("\n");
            sb.Append("  CustomHeaders: ").Append(CustomHeaders).Append("\n");
            sb.Append("  ReferenceId: ").Append(ReferenceId).Append("\n");
            sb.Append("  XCampaignID: ").Append(XCampaignID).Append("\n");
            sb.Append("  MimeRaw: ").Append(MimeRaw).Append("\n");
            sb.Append("  Attachments: ").Append(Attachments).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

    }

}
