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
    /// SubaccountPasswordConfirmPassword
    /// </summary>
    [DataContract(Name = "SubaccountPasswordConfirmPassword")]
    public partial class SubaccountPasswordConfirmPassword
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubaccountPasswordConfirmPassword" /> class.
        /// </summary>
        /// <param name="password">subaccount password.</param>
        /// <param name="confirmPassword">subaccount confirm password.</param>
        public SubaccountPasswordConfirmPassword(string password = default(string), string confirmPassword = default(string))
        {
            this.Password = password;
            this.ConfirmPassword = confirmPassword;
        }

        /// <summary>
        /// subaccount password
        /// </summary>
        /// <value>subaccount password</value>
        /// <example>LetmeIn123!</example>
        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string Password { get; set; }

        /// <summary>
        /// subaccount confirm password
        /// </summary>
        /// <value>subaccount confirm password</value>
        /// <example>LetmeIn123!</example>
        [DataMember(Name = "confirm_password", EmitDefaultValue = false)]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SubaccountPasswordConfirmPassword {\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  ConfirmPassword: ").Append(ConfirmPassword).Append("\n");
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
