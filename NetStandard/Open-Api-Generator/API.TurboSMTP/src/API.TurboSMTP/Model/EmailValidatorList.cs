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
    /// EmailValidatorList
    /// </summary>
    [DataContract(Name = "EmailValidatorList")]
    public partial class EmailValidatorList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailValidatorList" /> class.
        /// </summary>
        /// <param name="id">Email validation list id..</param>
        /// <param name="creationTime">Date and Time of the validation list creation..</param>
        /// <param name="fileName">File name of the uploaded file..</param>
        /// <param name="isProcessed">True if the validation list was already processed..</param>
        /// <param name="percentage">Describes the percentage progress of validation list..</param>
        /// <param name="totalEmails">Amount of email addresses in the validation list..</param>
        /// <param name="totalProcessed">Describes the count of email addresses processed so far..</param>
        /// <param name="statusSummary">statusSummary.</param>
        public EmailValidatorList(int id = default(int), string creationTime = default(string), string fileName = default(string), bool isProcessed = default(bool), int percentage = default(int), int totalEmails = default(int), int totalProcessed = default(int), List<EmailValidatorStatusSummaryItem> statusSummary = default(List<EmailValidatorStatusSummaryItem>))
        {
            this.Id = id;
            this.CreationTime = creationTime;
            this.FileName = fileName;
            this.IsProcessed = isProcessed;
            this.Percentage = percentage;
            this.TotalEmails = totalEmails;
            this.TotalProcessed = totalProcessed;
            this.StatusSummary = statusSummary;
        }

        /// <summary>
        /// Email validation list id.
        /// </summary>
        /// <value>Email validation list id.</value>
        /// <example>2406</example>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Date and Time of the validation list creation.
        /// </summary>
        /// <value>Date and Time of the validation list creation.</value>
        /// <example>2021-03-17 08:56:00</example>
        [DataMember(Name = "creation_time", EmitDefaultValue = false)]
        public string CreationTime { get; set; }

        /// <summary>
        /// File name of the uploaded file.
        /// </summary>
        /// <value>File name of the uploaded file.</value>
        /// <example>BusinessProspects.txt</example>
        [DataMember(Name = "file_name", EmitDefaultValue = false)]
        public string FileName { get; set; }

        /// <summary>
        /// True if the validation list was already processed.
        /// </summary>
        /// <value>True if the validation list was already processed.</value>
        /// <example>true</example>
        [DataMember(Name = "is_processed", EmitDefaultValue = true)]
        public bool IsProcessed { get; set; }

        /// <summary>
        /// Describes the percentage progress of validation list.
        /// </summary>
        /// <value>Describes the percentage progress of validation list.</value>
        /// <example>83</example>
        [DataMember(Name = "percentage", EmitDefaultValue = false)]
        public int Percentage { get; set; }

        /// <summary>
        /// Amount of email addresses in the validation list.
        /// </summary>
        /// <value>Amount of email addresses in the validation list.</value>
        /// <example>314</example>
        [DataMember(Name = "total_emails", EmitDefaultValue = false)]
        public int TotalEmails { get; set; }

        /// <summary>
        /// Describes the count of email addresses processed so far.
        /// </summary>
        /// <value>Describes the count of email addresses processed so far.</value>
        /// <example>28</example>
        [DataMember(Name = "total_processed", EmitDefaultValue = false)]
        public int TotalProcessed { get; set; }

        /// <summary>
        /// Gets or Sets StatusSummary
        /// </summary>
        /// <example>[{&quot;status&quot;:&quot;valid&quot;,&quot;total&quot;:2},{&quot;status&quot;:&quot;invalid&quot;,&quot;total&quot;:5}]</example>
        [DataMember(Name = "status_summary", EmitDefaultValue = false)]
        public List<EmailValidatorStatusSummaryItem> StatusSummary { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EmailValidatorList {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CreationTime: ").Append(CreationTime).Append("\n");
            sb.Append("  FileName: ").Append(FileName).Append("\n");
            sb.Append("  IsProcessed: ").Append(IsProcessed).Append("\n");
            sb.Append("  Percentage: ").Append(Percentage).Append("\n");
            sb.Append("  TotalEmails: ").Append(TotalEmails).Append("\n");
            sb.Append("  TotalProcessed: ").Append(TotalProcessed).Append("\n");
            sb.Append("  StatusSummary: ").Append(StatusSummary).Append("\n");
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
