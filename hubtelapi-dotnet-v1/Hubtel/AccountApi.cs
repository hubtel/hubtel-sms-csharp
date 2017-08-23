using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     The Account API. Please refer to  http://developers.smsgh.com for further information on how to set
    ///     some of the parameters
    /// </summary>
    /// <remarks>
    ///     All Exceptions thrown in this class contains the actual message of what has happened. Just by reading the
    ///     error message helps the developer to fix the issue.
    /// </remarks>
    public class AccountApi : AbstractApi
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="host"></param>
        public AccountApi(ApiHost host) : base(host) {}

        /// <summary>
        ///     Gets the Account Profile
        /// </summary>
        /// <returns>AccountProfile object</returns>
        /// <exception cref="HttpRequestException">Exception with the appropriate message</exception>
        public AccountProfile GetAccountProfile()
        {
            const string resource = "/account/profile/";
            HttpResponse response = RestClient.Get(resource);
            if (response != null
                && response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new AccountProfile(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            throw new HttpRequestException(new Exception("Request Failed"), response);
        }

        /// <summary>
        ///     Returns the Primary Account Contact
        /// </summary>
        /// <returns>AccountContact object <see cref="AccountContact" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public AccountContact GetPrimaryContact()
        {
            const string resource = "/account/primary_contact/";
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return new AccountContact(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Returns the Billing Contact
        /// </summary>
        /// <returns>AccountContact object <see cref="AccountContact" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public AccountContact GetBillingContact()
        {
            const string resource = "/account/billing_contact/";
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return new AccountContact(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Returns the Technical Contact
        /// </summary>
        /// <returns>AccountContact object <see cref="AccountContact" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public AccountContact GetTechnicalContact()
        {
            const string resource = "/account/technical_contact/";
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return new AccountContact(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the Account Contacts List
        /// </summary>
        /// <returns>List of AccountContact Object <see cref="AccountContact" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public List<AccountContact> GetContacts()
        {
            const string resource = "/account/contacts/";
            var contacts = new List<AccountContact>();
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) {
                var list = JsonConvert.DeserializeObject<List<ApiDictionary>>(response.GetBodyAsString());
                contacts.AddRange(list.Select(jso => new AccountContact(jso)));
                return contacts;
            }
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates an Account Contact
        /// </summary>
        /// <param name="accountContactId">Account Contact Id</param>
        /// <param name="data">Account Contact Data to update</param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool UpdateAccountContact(uint accountContactId, ParameterMap data)
        {
            string resource = "/account/contacts/";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += accountContactId;
            HttpResponse response = RestClient.Put(resource, data);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Gets the list of services associated with the Account by page and page size.
        /// </summary>
        /// <param name="page">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>ApiList of Service  <see cref="Service" /> <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Service> GetServices(uint page, uint pageSize)
        {
            const string resource = "/account/services/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0
                && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response != null) {
                if (response.Status == Convert.ToInt32(HttpStatusCode.OK))
                    return new ApiList<Service>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
                string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
                throw new Exception("Request Failed : " + errorMessage);
            }
            throw new Exception("Request Failed. Unable to get server response");
        }

        /// <summary>
        ///     Gets the overall list of services associated with the account
        /// </summary>
        /// <returns>ApiList of Service <see cref="Service" /> <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Service> GetServices()
        {
            return GetServices(0, 0);
        }

        /// <summary>
        ///     Gets the Account Settings or Preference
        /// </summary>
        /// <returns>Settings object <see cref="Settings" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Settings GetSettings()
        {
            const string resource = "/account/settings/";
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return new Settings(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates Account Settings or Preferences and returns the updated preference object.
        /// </summary>
        /// <param name="settingId">The Account Setting ID</param>
        /// <param name="data">The setting data to update <see cref="ParameterMap" /></param>
        /// <returns>Settings object <see cref="Settings" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Settings UpdateAccountSettings(uint settingId, ParameterMap data)
        {
            string resource = "/account/settings/";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += settingId;
            HttpResponse response = RestClient.Put(resource, data);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return new Settings(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Gets invoices. The response can be paginated
        /// </summary>
        /// <param name="page">The Page index</param>
        /// <param name="pageSize">The Page size</param>
        /// <returns>ApiList of Invoice <see cref="Invoice" /> <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Invoice> GetInvoices(uint page, uint pageSize)
        {
            const string resource = "/account/invoices/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0
                && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return new ApiList<Invoice>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Gets the overall list of invoices associated with the account
        /// </summary>
        /// <returns>ApiList of Invoice <see cref="Invoice" /> <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Invoice> GetInvoices()
        {
            return GetInvoices(0, 0);
        }

        /// <summary>
        ///     Gets the five nearest TopUpLocations based upon the longitude and latitude
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns>List of TopupLocation object <see cref="TopupLocation" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public List<TopupLocation> GetTopupLocations(double longitude, double latitude)
        {
            const string resource = "/topup/voucher/vendors/";
            var locations = new List<TopupLocation>();
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("Longitude", Convert.ToString(longitude)).Set("Latitude", Convert.ToString(latitude));

            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            string errorMessage;
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) {
                var rst = JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString());
                if (!rst.ContainsKey("Locations")) {
                    errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
                    throw new Exception("Malformed Server Response : " + errorMessage);
                }
                var apiArray = rst["Locations"] as IEnumerable;
                if (apiArray != null)
                    locations.AddRange(from JObject o in apiArray select (TopupLocation) Convert.ChangeType(new TopupLocation(o.ToObject<ApiDictionary>()), typeof (TopupLocation)));
                return locations;
            }
            errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Credit account with voucher
        /// </summary>
        /// <param name="voucherNumber">Voucher Number</param>
        /// <returns>Topup object <see cref="Topup" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Topup GetVoucher(string voucherNumber)
        {
            string resource = "/topup/voucher/";
            if (voucherNumber.IsEmpty()) throw new HttpRequestException(new Exception("Voucher number is required"));
            resource += voucherNumber.Trim();
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK))
                return new Topup(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }
    }
}