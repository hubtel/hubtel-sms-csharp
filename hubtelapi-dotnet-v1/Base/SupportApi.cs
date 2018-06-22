using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     The Support API. Please refer to http://developers.smsgh.com/documentations/ for
    ///     further information on how to set
    ///     some of the parameters
    /// </summary>
    /// <remarks>
    ///     All Exceptions thrown in this class contains the actual message of what has happened. Just by reading the
    ///     error message helps the developer to fix the issue.
    /// </remarks>
    public class SupportApi : AbstractApi
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="host"></param>
        public SupportApi(ApiHost host) : base(host) {}

        /// <summary>
        ///     Get a paginated list of support tickets
        /// </summary>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">The number of items on a page</param>
        /// <returns>
        ///     <see cref="Ticket" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Ticket> GetSupportTickets(uint page, uint pageSize)
        {
            const string resource = "/tickets/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0
                && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<Ticket>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the overall list of all tickets
        /// </summary>
        /// <returns>
        ///     <see cref="Ticket" /> <seealso cref="ApiList{T}" />
        /// </returns>
        public ApiList<Ticket> GetSupportTickets()
        {
            return GetSupportTickets(0, 0);
        }

        /// <summary>
        ///     Get a ticket
        /// </summary>
        /// <param name="ticketId">The ticket Id</param>
        /// <returns>
        ///     <see cref="Ticket" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Ticket GetSupportTicket(ulong ticketId)
        {
            string resource = "/tickets/" + ticketId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Ticket(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Add a support ticket
        /// </summary>
        /// <param name="ticket">The ticket object</param>
        /// <returns>The created ticket <see cref="" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Ticket AddSupportTicket(Ticket ticket)
        {
            const string resource = "/tickets/";
            const string contentType = "application/json";
            if (ticket == null) throw new Exception("Parameter 'ticket' cannot be null");
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, ticket);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new Ticket(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Update a ticket
        /// </summary>
        /// <param name="ticketId">ticket id</param>
        /// <param name="reply">the update message</param>
        /// <returns>Updated ticket <see cref="Ticket" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Ticket UpdateSupportTicket(ulong ticketId, TicketResponse reply)
        {
            string resource = "/tickets/" + ticketId;
            const string contentType = "application/json";
            if (reply == null) throw new Exception("Parameter 'reply' cannot be null");
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, reply);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Ticket(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }
    }
}