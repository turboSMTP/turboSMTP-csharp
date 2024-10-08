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
    /// ConsumerKey
    /// </summary>
    [DataContract(Name = "ConsumerKey")]
    public partial class ConsumerKey
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumerKey" /> class.
        /// </summary>
        /// <param name="varConsumerKey">Consumer Key.</param>
        /// <param name="label">Consumer Key label..</param>
        /// <param name="creationTime">The time the consumer key was created..</param>
        public ConsumerKey(string varConsumerKey = default(string), string label = default(string), string creationTime = default(string))
        {
            this.VarConsumerKey = varConsumerKey;
            this.Label = label;
            this.CreationTime = creationTime;
        }

        /// <summary>
        /// Consumer Key
        /// </summary>
        /// <value>Consumer Key</value>
        /// <example>b914ad238d0e8e8851b81e86ce46ae1d</example>
        [DataMember(Name = "consumerKey", EmitDefaultValue = false)]
        public string VarConsumerKey { get; set; }

        /// <summary>
        /// Consumer Key label.
        /// </summary>
        /// <value>Consumer Key label.</value>
        /// <example>QAkey.</example>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; set; }

        /// <summary>
        /// The time the consumer key was created.
        /// </summary>
        /// <value>The time the consumer key was created.</value>
        /// <example>2021-03-17 00:00:00</example>
        [DataMember(Name = "creation_time", EmitDefaultValue = false)]
        public string CreationTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ConsumerKey {\n");
            sb.Append("  VarConsumerKey: ").Append(VarConsumerKey).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  CreationTime: ").Append(CreationTime).Append("\n");
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
