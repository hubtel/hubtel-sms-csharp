using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     The Messaging API. Please refer to http://developers.smsgh.com/documentations/sendmessage for
    ///     further information on how to set
    ///     some of the parameters
    /// </summary>
    /// <remarks>
    ///     All Exceptions thrown in this class contains the actual message of what has happened. Just by reading the
    ///     error message helps the developer to fix the issue.
    /// </remarks>
    public class MessagingApi : AbstractApi
    {
        /// <summary>
        /// </summary>
        /// <param name="host"></param>
        public MessagingApi(ApiHost host) : base(host) {}

        /// <summary>
        ///     Sends a message. It returns upon success a <see cref="MessageResponse" /> object.
        /// </summary>
        /// <param name="mesg">Message object <see cref="Message" /></param>
        /// <returns>
        ///     <see cref="MessageResponse" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public MessageResponse SendMessage(Message mesg)
        {
            if (mesg == null) throw new Exception("Parameter 'mesg' cannot be null");
            const string resource = "/";
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, mesg);
            const string contentType = "application/json";
            
            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new MessageResponse(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Sends a quick message. It returns upon success a <see cref="MessageResponse" /> object.
        /// </summary>
        /// <param name="from">Sender ID. Ensure that your Sender ID is approved</param>
        /// <param name="to">Recipient</param>
        /// <param name="content">Message to send</param>
        /// <param name="registeredDelivery">Request Delivery Receipt</param>
        /// <param name="billingInfo">Billing Info</param>
        /// <returns>
        ///     <see cref="MessageResponse" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public MessageResponse SendQuickMessage(string from, string to, string content, bool registeredDelivery, string billingInfo = null)
        {
            var mesg = new Message {From = @from, Content = content, To = to, RegisteredDelivery = registeredDelivery, BillingInfo = billingInfo};
            return SendMessage(mesg);
        }

        /// <summary>
        ///     Reschedule a message. It returns upon success a <see cref="MessageResponse" /> object.
        /// </summary>
        /// <param name="messageId">Message Id</param>
        /// <param name="time">Schedule Time</param>
        /// <returns>
        ///     <see cref="MessageResponse" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public MessageResponse ScheduleMessage(string messageId, DateTime time)
        {
            string resource = "/";
            if (!messageId.IsGuid()) throw new Exception("messageId must not be null and be a valid UUID");

            const string contentType = "application/json";
            resource += messageId.Replace("-", "");
            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(String.Format("{{\"Time\":\"{0}\"}}", time.ToString("yyyy-MM-dd HH:mm:ss"))));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new MessageResponse(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

     

        /// <summary>
        ///     Get a message. It returns upon success a <see cref="Message" /> object.
        /// </summary>
        /// <param name="messageId">Message Id</param>
        /// <returns>
        ///     <see cref="Message" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Message GetMessage(string messageId)
        {
            string resource = "/messages/";
            if (!messageId.IsGuid()) throw new Exception("messageId must not be null and be a valid UUID");
            resource += messageId.Replace("-", "");
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Message(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

       
    }
}