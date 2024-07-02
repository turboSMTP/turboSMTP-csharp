/*
 * TurboSMTP Public APIs
 *
 * This document describes all public turboSMTP v2 API and offers endpoints Descriptions, Parameters, Requests, Responses and Samples of usage.  # Security For the most part (and where not otherwise explicit) turboSMTP’s API requires Authorization.   Authorization to access a user’s resource is granted to clients provided they set  authentication headers into their request, valued with the proper values issued by turboSMTP servers.  ## *  Authorization via ConsumerKey/ConsumerSecret  This type of authorization consists of a pair of headers, named consumerKey and consumerSecret that are created and granted to the end user to be used in a permanent way (unless they´re deleted of course). This kind of authentication is intended to provide access to endpoints features without the need of providing the user the account details (email address + password).  *consumerKey:* Consumer Key Granted.  *consumerSecret:* Consumer Secret Granted.  (Use [/consumerKeys/create](#/consumerkey/createConsumerKey) create a consumer key/secret pair).      ## *  Authorization via API Key  The authentication key is user-based and it is issued by turboSMTP servers upon successful user’s email address + password challenge, performed by means of appropriate request.      *Authorization:* Authorization_Key  (Use [/authentication/authorize](#/authentication/AuthenticationLogin) to obtain an API Key)  # Data Interchange Format  For the most part (and where not otherwise explicit) turboSMTP’s API uses JSON as the data format of choice when it comes to request and response bodies.  - --     
 *
 * The version of the OpenAPI document: 1.0.0-oas3
 * Contact: andrea@turbo-smtp.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using API.TurboSMTP.Client;
using API.TurboSMTP.Api;
// uncomment below to import models
//using API.TurboSMTP.Model;

namespace API.TurboSMTP.Test.Api
{
    /// <summary>
    ///  Class for testing EmailValidatorApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class EmailValidatorApiTests : IDisposable
    {
        private EmailValidatorApi instance;

        public EmailValidatorApiTests()
        {
            instance = new EmailValidatorApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of EmailValidatorApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' EmailValidatorApi
            //Assert.IsType<EmailValidatorApi>(instance);
        }

        /// <summary>
        /// Test DeleteEmailValidationListById
        /// </summary>
        [Fact]
        public void DeleteEmailValidationListByIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int id = null;
            //var response = instance.DeleteEmailValidationListById(id);
            //Assert.IsType<CommonSuccessResponseBody>(response);
        }

        /// <summary>
        /// Test ExportCSVValidatedEmailsByList
        /// </summary>
        [Fact]
        public void ExportCSVValidatedEmailsByListTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int id = null;
            //var response = instance.ExportCSVValidatedEmailsByList(id);
            //Assert.IsType<string>(response);
        }

        /// <summary>
        /// Test GetEmailValidationDataByEmailId
        /// </summary>
        [Fact]
        public void GetEmailValidationDataByEmailIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int id = null;
            //int emailId = null;
            //var response = instance.GetEmailValidationDataByEmailId(id, emailId);
            //Assert.IsType<EmailValidatorListEmailDetails>(response);
        }

        /// <summary>
        /// Test GetEmailValidationListSummary
        /// </summary>
        [Fact]
        public void GetEmailValidationListSummaryTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int id = null;
            //var response = instance.GetEmailValidationListSummary(id);
            //Assert.IsType<EmailValidatorList>(response);
        }

        /// <summary>
        /// Test GetEmailValidationLists
        /// </summary>
        [Fact]
        public void GetEmailValidationListsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int page = null;
            //DateTime from = null;
            //DateTime to = null;
            //int? limit = null;
            //string tz = null;
            //var response = instance.GetEmailValidationLists(page, from, to, limit, tz);
            //Assert.IsType<EmailValidatorSucessResponsetBody>(response);
        }

        /// <summary>
        /// Test GetEmailValidationSubscription
        /// </summary>
        [Fact]
        public void GetEmailValidationSubscriptionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetEmailValidationSubscription();
            //Assert.IsType<EmailValidatorSubscription>(response);
        }

        /// <summary>
        /// Test GetValidatedEmailsByList
        /// </summary>
        [Fact]
        public void GetValidatedEmailsByListTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int page = null;
            //int id = null;
            //int? limit = null;
            //var response = instance.GetValidatedEmailsByList(page, id, limit);
            //Assert.IsType<EmailValidatorValidatedMailsResults>(response);
        }

        /// <summary>
        /// Test UploadEmailValidationFile
        /// </summary>
        [Fact]
        public void UploadEmailValidationFileTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //System.IO.Stream file = null;
            //var response = instance.UploadEmailValidationFile(file);
            //Assert.IsType<EmailValidationUploadResponse>(response);
        }

        /// <summary>
        /// Test ValidateEmail
        /// </summary>
        [Fact]
        public void ValidateEmailTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //EmailRequestBody1 emailRequestBody1 = null;
            //var response = instance.ValidateEmail(emailRequestBody1);
            //Assert.IsType<EmailValidatorMailDetails>(response);
        }

        /// <summary>
        /// Test ValidateEmailValidatorList
        /// </summary>
        [Fact]
        public void ValidateEmailValidatorListTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int id = null;
            //instance.ValidateEmailValidatorList(id);
        }
    }
}
