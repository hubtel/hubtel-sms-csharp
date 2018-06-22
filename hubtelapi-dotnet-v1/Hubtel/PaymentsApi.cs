// ***********************************************************************
// Assembly         : hubtelapi-dotnet-v1.462
// Author           : hubtel
// Created          : 06-18-2018
//
// Last Modified By : DUHO
// Last Modified On : 06-19-2018
// ***********************************************************************
// <copyright file="PaymentsApi.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using hubtelapi_dotnet_v1.Payments;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    /// Class PaymentsApi.
    /// </summary>
    /// <seealso cref="hubtelapi_dotnet_v1.Hubtel.AbstractApi" />
    public class PaymentsApi: AbstractApi
    {
        private readonly string _merchant;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsApi" /> class.
        /// </summary>
        /// <param name="host"><see cref="ApiHost" /></param>
        public PaymentsApi(ApiHost host) : base(host)
        {
            _merchant = ConfigurationManager.AppSettings["MerchantNumber"];

        }
       
        /// <summary>
        /// Requests the payment.
        /// </summary>
        /// <param name="mobile">The mobile.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="clientReference"></param>
        /// <param name="description">The description.</param>
        /// <param name="primaryCallbackUrl">The primary callback URL.</param>
        /// <param name="secondaryCallbackUrl">The secondary callback URL.</param>
        /// <returns>Task&lt;MoneyResponse&gt;.</returns>
        /// <exception cref="Exception">Request Failed. Unable to get server response
        /// or
        /// Request Failed : " + errorMessage
        /// or</exception>
        public MoneyResponse RequestPayment(string mobile, decimal amount, string fullName, string channel,
            string clientReference, string description = null, string primaryCallbackUrl = null,
            string secondaryCallbackUrl = null)
        {
            try
            {
                var data = new
                {
                    CustomerName = fullName,
                    CustomerMsisdn = mobile,
                    CustomerEmail = "",
                    Channel = channel,
                    Amount = amount,
                    PrimaryCallbackUrl = primaryCallbackUrl,
                    SecondaryCallbackUrl = secondaryCallbackUrl,
                    Description = description,
                    ClientReference = clientReference,
                    Token = "string"
                };
                var resource = $"/merchantaccount/merchants/{_merchant}/send/mobilemoney";
                var stringWriter = new StringWriter();
                new JsonSerializer().Serialize(stringWriter, data);
                const string contentType = "application/json";
                var response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
                if (response == null) throw new Exception("Request Failed. Unable to get server response");
                if (response.Status == Convert.ToInt32(HttpStatusCode.OK))
                    return  JsonConvert.DeserializeObject<MoneyResponse>(response.GetBodyAsString());
                var errorMessage = $"Status Code={response.Status}, Message={response.GetBodyAsString()}";
                throw new Exception("Request Failed : " + errorMessage);
            }
            catch (Exception e)
            {
                throw new Exception(JsonConvert.SerializeObject(e));
            }
        }



        /// <summary>
        /// Makes the payment.
        /// </summary>
        /// <param name="mobile">The mobile.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="description">The description.</param>
        /// <param name="primaryCallbackUrl">The primary callback URL.</param>
        /// <param name="secondaryCallbackUrl">The secondary callback URL.</param>
        /// <returns>MoneyResponse.</returns>
        /// <exception cref="Exception">
        /// Request Failed. Unable to get server response
        /// or
        /// Request Failed : " + errorMessage
        /// or
        /// </exception>
        public MoneyResponse MakePayment( string mobile,decimal amount, string fullName, string channel,string description=null,string primaryCallbackUrl=null,string secondaryCallbackUrl=null)
        {
            try
            {
                var data = new
                {
                    CustomerName = fullName,
                    CustomerMsisdn = mobile,
                    CustomerEmail = "",
                    Channel = channel,
                    Amount = amount,
                    PrimaryCallbackUrl = primaryCallbackUrl,
                    SecondaryCallbackUrl = secondaryCallbackUrl,
                    Description = description,
                    ClientReference = "",
                    Token = "string"
                };
                var resource = $"/merchantaccount/merchants/{_merchant}/receive/mobilemoney";
                var stringWriter = new StringWriter();
                new JsonSerializer().Serialize(stringWriter, data);
                const string contentType = "application/json";
                var response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
                if (response == null) throw new Exception("Request Failed. Unable to get server response");
                if (response.Status == Convert.ToInt32(HttpStatusCode.OK))
                    return  JsonConvert.DeserializeObject<MoneyResponse>(response.GetBodyAsString());
                var errorMessage = $"Status Code={response.Status}, Message={response.GetBodyAsString()}";
                throw new Exception("Request Failed : " + errorMessage);
            }
            catch (Exception e)
            {
                throw new Exception(JsonConvert.SerializeObject(e));
            }
        }

        /// <summary>
        /// Checks the payment status.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <returns>TransactionResponse.</returns>
        /// <exception cref="Exception">
        /// Request Failed. Unable to get server response
        /// or
        /// Request Failed : " + errorMessage
        /// or
        /// </exception>
        public TransactionResponse CheckPaymentStatus(Transaction transaction)
        {
            try
            {

                var resource = $"/merchantaccount/merchants/{_merchant}/transactions/status";

                var parameterMap = RestClient.NewParams();
                if (!string.IsNullOrWhiteSpace(transaction.HubtelTransactionId)) parameterMap.Set("hubtelTransactionId", HttpUtility.UrlEncode(transaction.HubtelTransactionId));
                if (!string.IsNullOrWhiteSpace(transaction.NetworkTransactionId)) parameterMap.Set("networkTransactionId", HttpUtility.UrlEncode(transaction.NetworkTransactionId));
                if (!string.IsNullOrWhiteSpace(transaction.InvoiceToken)) parameterMap.Set("invoiceToken", HttpUtility.UrlEncode(transaction.InvoiceToken));
                
                var response = RestClient.Get(resource, parameterMap);
                if (response == null) throw new Exception("Request Failed. Unable to get server response");
                if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return JsonConvert.DeserializeObject<TransactionResponse>(response.GetBodyAsString());
                var errorMessage = $"Status Code={response.Status}, Message={response.GetBodyAsString()}";
                throw new Exception("Request Failed : " + errorMessage);
            }
            catch (Exception e)
            {
                throw new Exception(JsonConvert.SerializeObject(e));
            }
        }


        /// <summary>
        /// Online Payment Status version one.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>InvoiceStatusResponse.</returns>
        /// <exception cref="Exception">
        /// Request Failed. Unable to get server response
        /// or
        /// Request Failed : " + errorMessage
        /// or
        /// </exception>
        public InvoiceStatusResponse OnlinePaymentStatusV1(string token)
        {
            try
            {

                var resource = $"/merchantaccount/onlinecheckout/invoice/status/{token}";
                var response = RestClient.Get(resource);

                if (response == null) throw new Exception("Request Failed. Unable to get server response");
                if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return JsonConvert.DeserializeObject<InvoiceStatusResponse>(response.GetBodyAsString());
                var errorMessage = $"Status Code={response.Status}, Message={response.GetBodyAsString()}";
                throw new Exception("Request Failed : " + errorMessage);
            }
            catch (Exception e)
            {
                throw new Exception(JsonConvert.SerializeObject(e));
            }

        }

    }
}