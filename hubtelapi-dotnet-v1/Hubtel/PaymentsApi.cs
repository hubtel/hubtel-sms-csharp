// ***********************************************************************
// Assembly         : hubtelapi-dotnet-v1.462
// Author           : DUHO
// Created          : 06-18-2018
//
// Last Modified By : DUHO
// Last Modified On : 06-18-2018
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
using System.Threading.Tasks;
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
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsApi"/> class.
        /// </summary>
        /// <param name="host"><see cref="ApiHost" /></param>
        public PaymentsApi(ApiHost host) : base(host)
        {
        }

        /// <summary>
        /// Requests the payment.
        /// </summary>
        /// <param name="mobile">The mobile.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="description">The description.</param>
        /// <param name="primaryCallbackUrl">The primary callback URL.</param>
        /// <param name="secondaryCallbackUrl">The secondary callback URL.</param>
        /// <returns>Task&lt;MoneyResponse&gt;.</returns>
        /// <exception cref="Exception">
        /// Request Failed. Unable to get server response
        /// or
        /// Request Failed : " + errorMessage
        /// or
        /// </exception>
        public static async Task<MoneyResponse> RequestPayment( string mobile,decimal amount, string fullName, string channel,string description=null,string primaryCallbackUrl=null,string secondaryCallbackUrl=null)
        {
            try
            {
                var merchant = ConfigurationManager.AppSettings["MerchantNumber"];
                var data = new
                {
                    CustomerName = fullName,
                    CustomerMsisd = mobile,
                    CustomerEmail = "",
                    Channel = channel,
                    Amount = amount,
                    PrimaryCallbackUrl = primaryCallbackUrl,
                    SecondaryCallbackUrl = secondaryCallbackUrl,
                    Description = description,
                    ClientReference = "",
                    Token = "string"
                };
                var resource = $"/merchantaccount/merchants/{merchant}/receive/mobilemoney";
                var stringWriter = new StringWriter();
                new JsonSerializer().Serialize(stringWriter, data);
                const string contentType = "application/json";
                var response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
                if (response == null) throw new Exception("Request Failed. Unable to get server response");
                if (response.Status == Convert.ToInt32(HttpStatusCode.OK))
                    return await Task.FromResult(JsonConvert.DeserializeObject<MoneyResponse>(response.GetBodyAsString()));
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