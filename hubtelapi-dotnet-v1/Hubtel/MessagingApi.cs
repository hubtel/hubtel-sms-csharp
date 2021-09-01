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
        /// Schedule a message. It returns upon success a <see cref="MessageResponse"/> object.
        /// </summary>
        /// <param name="message"></param>
        /// <returns><see cref="MessageResponse" /></returns>
        public MessageResponse ScheduleMessage(Message message) {
            return SendMessage(message);
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
        public MessageResponse ScheduleMessage(Guid messageId, DateTime time)
        {
            string resource = "/messages/";
            const string contentType = "application/json";
            resource += messageId.ToString().Replace("-", "");
            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(String.Format("{{\"Time\":\"{0}\"}}", time.ToString("yyyy-MM-dd HH:mm:ss"))));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new MessageResponse(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
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
            string resource = "/messages/";
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
        public Message GetMessage(Guid messageId)
        {
            string resource = "/messages/";
            resource += messageId.ToString().Replace("-", "");
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Message(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
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

        /// <summary>
        ///     Retrieve messages. Upon success it return a list of messages. However one can provide some filters to narrow down
        ///     the query.
        /// </summary>
        /// <param name="start">Start date.</param>
        /// <param name="end">End date</param>
        /// <param name="index">The number of results to skip from the result set. The default is 0.</param>
        /// <param name="limit">The maximum number of results to return. This has a hard limit of 100 messages.</param>
        /// <param name="pending">
        ///     A true or false value used to indicate if only scheduled messages should be returned in the
        ///     result set. By default only sent message are returned.
        /// </param>
        /// <param name="direction">
        ///     Used to filter the result by the direction of the message. Possible values are "in" (to return
        ///     only inbound messages) and "out" (to return only outbound messages).
        /// </param>
        /// <returns>
        ///     <see cref="ApiList{T}" /> <seealso cref="Message" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Message> GetMessages(DateTime? start, DateTime? end, uint index, uint limit, bool pending, string direction)
        {
            const string resource = "/messages/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (start != null) parameterMap.Set("start", HttpUtility.UrlEncode(start.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss")));
            if (end != null) parameterMap.Set("end", HttpUtility.UrlEncode(end.GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss")));
            if (index > 0) parameterMap.Set("index", Convert.ToString(index));
            if (limit > 0) parameterMap.Set("limit", Convert.ToString(limit));
            parameterMap.Set("pending", pending ? "true" : "false");
            if (!direction.IsEmpty()) parameterMap.Set("direction", direction.Trim());
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<Message>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the paginated list of sender Ids
        /// </summary>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">The number of items on a page</param>
        /// <returns>Custom list of Sender <see cref="Sender" /> and <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Sender> GetSenderIds(uint page, uint pageSize)
        {
            const string resource = "/senders/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0
                && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<Sender>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the overall list of sender Ids
        /// </summary>
        /// <returns>Custom list of Sender <see cref="Sender" /> and <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Sender> GetSenderIds()
        {
            return GetSenderIds(0, 0);
        }

        /// <summary>
        ///     Get a sender Id.
        /// </summary>
        /// <param name="senderId">The Id of the sender Id</param>
        /// <returns>
        ///     <see cref="Sender" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Sender GetSender(ulong senderId)
        {
            string resource = "/senders/" + senderId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Creates a new Sender ID
        /// </summary>
        /// <param name="sender">The sender Id oject <see cref="Sender" /></param>
        /// <returns>
        ///     <see cref="Sender" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Sender AddSenderId(Sender sender)
        {
            const string resource = "/senders/";
            const string contentType = "application/json";
            if (sender == null) throw new Exception("Parameter 'sender' cannot be null");
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, sender);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Creates a new Sender ID by just using the address. This is the shortest way to create a sender Id
        /// </summary>
        /// <param name="address">The address</param>
        /// <returns>
        ///     <see cref="Sender" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Sender AddSenderId(string address)
        {
            const string resource = "/senders/";
            if (string.IsNullOrEmpty(address))
                throw new Exception("Parameter 'address' cannot be null");
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("Address", address);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates a Sender ID
        /// </summary>
        /// <param name="senderId">The id of the sender id</param>
        /// <param name="data">The sender id data <see cref="ParameterMap" /></param>
        /// <returns>
        ///     <see cref="Sender" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        /// <remarks>Use this <see cref="UpdateSenderId(ulong,string)" /></remarks>
        public Sender UpdateSenderId(ulong senderId, ParameterMap data)
        {
            string resource = "/senders/";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += senderId;
            HttpResponse response = RestClient.Put(resource, data);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates a Sender ID
        /// </summary>
        /// <param name="senderId">The id of the sender id</param>
        /// <param name="data">The sender id data <see cref="ParameterMap" /></param>
        /// <returns>
        ///     <see cref="Sender" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        /// <remarks>Use this <see cref="UpdateSenderId(ulong,string)" /></remarks>
        public Sender UpdateSenderId(ulong senderId, Sender data)
        {
            string resource = "/senders/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += senderId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates a Sender ID. However you have to set the id of the sender id in the data argument <see cref="Sender" />
        /// </summary>
        /// <param name="data">The sender id data <see cref="ParameterMap" /></param>
        /// <returns>
        ///     <see cref="Sender" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        /// <remarks>Use this <see cref="UpdateSenderId(ulong,string)" /></remarks>
        public Sender UpdateSenderId(Sender data)
        {
            string resource = "/senders/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += data.Id;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates a Sender ID. This is the quickest way to update a sender id.
        /// </summary>
        /// <param name="senderId">The id of the sender id</param>
        /// <param name="address">The address</param>
        /// <returns>
        ///     <see cref="Sender" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Sender UpdateSenderId(ulong senderId, string address)
        {
            string resource = "/senders/";
            if (string.IsNullOrEmpty(address)) throw new Exception("Parameter 'address' cannot be null");
            resource += senderId;
            ParameterMap parameter = RestClient.NewParams();
            parameter.Set("Address", address);
            HttpResponse response = RestClient.Put(resource, parameter);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Sender(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Delete a Sender Id.
        /// </summary>
        /// <param name="senderId">The Sender Id Id</param>
        /// <returns>true when successful.</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool DeleteSenderId(ulong senderId)
        {
            string resource = "/senders/" + senderId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the paginated list of MessageTemplates
        /// </summary>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">The number of items on a page</param>
        /// <returns>Custom List of MessageTemplate <see cref="MessageTemplate" /> <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<MessageTemplate> GetMessageTemplates(uint page, uint pageSize)
        {
            const string resource = "/templates/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0
                && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<MessageTemplate>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the overall list of MessageTemplates
        /// </summary>
        /// <returns>Custom List of MessageTemplate <see cref="MessageTemplate" /> <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<MessageTemplate> GetMessageTemplates()
        {
            return GetMessageTemplates(0, 0);
        }

        /// <summary>
        ///     Get a message template
        /// </summary>
        /// <param name="templateId">The message template Id</param>
        /// <returns>
        ///     <see cref="MessageTemplate" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public MessageTemplate GetMessageTemplate(ulong templateId)
        {
            string resource = "/templates/" + templateId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MessageTemplate(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Create a new MessageTemplate
        /// </summary>
        /// <param name="mesgTemplate">The message template object. <see cref="MessageTemplate" /></param>
        /// <returns>
        ///     <see cref="MessageTemplate" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public MessageTemplate AddMessageTemplate(MessageTemplate mesgTemplate)
        {
            const string resource = "/templates/";
            const string contentType = "application/json";
            if (mesgTemplate == null) throw new Exception("Parameter 'mesgTemplate' cannot be null");
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, mesgTemplate);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MessageTemplate(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Update a MessageTemplate. Just set the id of the message template to update.
        /// </summary>
        /// <param name="data">The message template object. <see cref="MessageTemplate" /></param>
        /// <returns>
        ///     <see cref="MessageTemplate" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public MessageTemplate UpdateMessageTemplate(MessageTemplate data)
        {
            string resource = "/templates/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += data.Id;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MessageTemplate(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Delete a message template
        /// </summary>
        /// <param name="templateId">The message template Id</param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool DeleteMessageTemplate(ulong templateId)
        {
            string resource = "/templates/" + templateId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get a paginated list of  number plans.
        /// </summary>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">The number of items on a page.</param>
        /// <param name="type">
        ///     The type of numberplans: The following values are accepted:
        ///     0 - Shared Number Plans
        ///     1 - Semi Dedicated Number Plans
        ///     2 - Dedicated Number Plans
        /// </param>
        /// <returns>
        ///     <see cref="NumberPlan" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<NumberPlan> GetNumberPlans(uint page, uint pageSize, int type)
        {
            const string resource = "/numberplans/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));
            if (type >= 0) parameterMap.Set("Type", Convert.ToString(type));

            if (page == 0
                && pageSize == 0
                && type < 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<NumberPlan>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the overall list of number plans
        /// </summary>
        /// <returns>
        ///     <see cref="NumberPlan" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<NumberPlan> GetNumberPlans()
        {
            return GetNumberPlans(0, 0, -1);
        }

        /// <summary>
        ///     Get the paginated list of keywords associated to a number plan
        /// </summary>
        /// <param name="numberPlanId">The number plan id</param>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">The number of items on a page</param>
        /// <returns>
        ///     <see cref="MoKeyWord" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<MoKeyWord> GetNumberPlanMoKeywords(ulong numberPlanId, uint page, uint pageSize)
        {
            string resource = "/numberplans/" + numberPlanId + "/keywords/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0
                && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<MoKeyWord>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the overall list of keywords associated to a number plan
        /// </summary>
        /// <param name="numberPlanId">The number plan id</param>
        /// <returns>
        ///     <see cref="MoKeyWord" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<MoKeyWord> GetNumberPlanMoKeywords(ulong numberPlanId)
        {
            return GetNumberPlanMoKeywords(numberPlanId, 0, 0);
        }

        /// <summary>
        ///     Get the paginated list of keywords associated to a campaign
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">The number of items on a page</param>
        /// <returns>
        ///     <see cref="MoKeyWord" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<MoKeyWord> GetCampaignMoKeywords(ulong campaignId, uint page, uint pageSize)
        {
            string resource = "/campaigns/" + campaignId + "/keywords/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0
                && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<MoKeyWord>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the overall list of keywords associated to a campaign.
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <returns>
        ///     <see cref="MoKeyWord" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<MoKeyWord> GetCampaignMoKeywords(ulong campaignId)
        {
            return GetCampaignMoKeywords(campaignId, 0, 0);
        }

        /// <summary>
        ///     Get a paginated list of campaigns
        /// </summary>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">The number of items on a page.</param>
        /// <param name="type">The type of campaign. Do set this value to -1</param>
        /// <returns>
        ///     <see cref="Campaign" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Campaign> GetCampaigns(uint page, uint pageSize, int type)
        {
            const string resource = "/campaigns/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));
            if (type >= 0) parameterMap.Set("Type", Convert.ToString(type));

            if (page == 0
                && pageSize == 0
                && type < 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<Campaign>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the overall list of campaigns
        /// </summary>
        /// <returns>
        ///     <see cref="Campaign" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Campaign> GetCampaigns()
        {
            return GetCampaigns(0, 0, -1);
        }

        /// <summary>
        ///     Get a campaign
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <returns>
        ///     <see cref="Campaign" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Campaign GetCampaign(ulong campaignId)
        {
            string resource = "/campaigns/" + campaignId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get a number plan
        /// </summary>
        /// <param name="numberPlanId">The number plan id</param>
        /// <returns>
        ///     <see cref="NumberPlan" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public NumberPlan GetNumberPlan(ulong numberPlanId)
        {
            string resource = "/numberplans/" + numberPlanId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new NumberPlan(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get a paginated list of keywords
        /// </summary>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">The number of items on a page</param>
        /// <returns>
        ///     <see cref="MoKeyWord" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<MoKeyWord> GetMoKeywords(uint page, uint pageSize)
        {
            const string resource = "/keywords/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0
                && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<MoKeyWord>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the overall list of keywords
        /// </summary>
        /// <returns>
        ///     <see cref="MoKeyWord" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<MoKeyWord> GetMoKeywords()
        {
            return GetMoKeywords(0, 0);
        }

        /// <summary>
        ///     Get a keyword
        /// </summary>
        /// <param name="keywordId">The keyword Id</param>
        /// <returns>
        ///     <see cref="MoKeyWord" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public MoKeyWord GetMoKeyword(ulong keywordId)
        {
            string resource = "/keywords/" + keywordId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MoKeyWord(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Creates a new campaign
        /// </summary>
        /// <param name="campaign">The campaign object <see cref="Campaign" /></param>
        /// <returns>Created Campaign <see cref="Campaign" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Campaign AddCampaign(Campaign campaign)
        {
            const string resource = "/campaigns/";
            const string contentType = "application/json";
            if (campaign == null) throw new Exception("Parameter 'campaign' cannot be null");
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, campaign);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Update a campaign. Set the campaign id in the campaign object
        /// </summary>
        /// <param name="campaign">The campaing object <see cref="Campaign" /></param>
        /// <returns>Updated Campaign <see cref="Campaign" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        /// <remarks> Use this <see cref="UpdateCampaign(ulong, Campaign)" /></remarks>
        public Campaign UpdateCampaign(Campaign campaign)
        {
            string resource = "/campaigns/";
            const string contentType = "application/json";
            if (campaign == null) throw new Exception("Parameter 'campaign' cannot be null");
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, campaign);
            resource += campaign.CampaignId;
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Update a campaing
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <param name="data">The campaing data to update <see cref="Campaign" /></param>
        /// <returns>Updated campaing <see cref="Campaign" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Campaign UpdateCampaign(ulong campaignId, Campaign data)
        {
            string resource = "/campaigns/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += campaignId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Delete a campaign
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool DeleteCampaign(ulong campaignId)
        {
            string resource = "/campaigns/" + campaignId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Add keyword
        /// </summary>
        /// <param name="keyword">The keyword data <see cref="MoKeyWord" /></param>
        /// <returns>
        ///     <see cref="MoKeyWord" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public MoKeyWord AddMoKeyword(MoKeyWord keyword)
        {
            const string resource = "/keywords/";
            const string contentType = "application/json";
            if (keyword == null) throw new Exception("Parameter 'keyword' cannot be null");
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, keyword);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MoKeyWord(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Update a keyword
        /// </summary>
        /// <param name="keywordId">The keyword id</param>
        /// <param name="keyword">The keyword data <see cref="MoKeyWord" /></param>
        /// <returns>
        ///     <see cref="MoKeyWord" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public MoKeyWord UpdateMoKeyword(ulong keywordId, MoKeyWord keyword)
        {
            string resource = "/keywords/";
            const string contentType = "application/json";
            if (keyword == null) throw new Exception("Parameter 'keyword' cannot be null");
            resource += keywordId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, keyword);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MoKeyWord(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Update a keyword . Set the keyword id in the keyword object
        /// </summary>
        /// <param name="keyword">The keyword data <see cref="MoKeyWord" /></param>
        /// <returns>
        ///     <see cref="MoKeyWord" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public MoKeyWord UpdateMoKeyword(MoKeyWord keyword)
        {
            string resource = "/keywords/";
            const string contentType = "application/json";
            if (keyword == null) throw new Exception("Parameter 'keyword' cannot be null");
            resource += keyword.Id;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, keyword);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new MoKeyWord(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Delete a keyword
        /// </summary>
        /// <param name="keywordId">The keyword id</param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool DeleteMoKeyword(ulong keywordId)
        {
            string resource = "/keywords/" + keywordId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Set campaign keyword. It will return the updated campaign
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <param name="keywordId">The keyword id</param>
        /// <returns>
        ///     <see cref="Campaign" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Campaign SetCampaignMoKeyword(ulong campaignId, long keywordId)
        {
            string resource = "/campaigns/" + campaignId + "/keywords/" + keywordId;
            HttpResponse response = RestClient.Put(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Delete campaign keyword. It will return the updated campaign
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <param name="keywordId">The keyword if</param>
        /// <returns>
        ///     <see cref="Campaign" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Campaign DeleteCampaignMoKeyword(ulong campaignId, long keywordId)
        {
            string resource = "/campaigns/" + campaignId + "/keywords/" + keywordId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get a paginated list of campaign actions
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">The number of items on a page</param>
        /// <returns>
        ///     <see cref="System.Action" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<System.Action> GetCampaignActions(ulong campaignId, uint page, uint pageSize)
        {
            string resource = "/campaigns/" + campaignId + "/actions/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0
                && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<System.Action>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the overall list of campaign actions
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <returns>
        ///     <see cref="System.Action" /> <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<System.Action> GetCampaignActions(ulong campaignId)
        {
            return GetCampaignActions(campaignId, 0, 0);
        }

        /// <summary>
        ///     Set campaign Default Reply text. It will return the updated campaign
        /// </summary>
        /// <param name="campaignId">The campaign Id</param>
        /// <param name="message">The text message</param>
        /// <returns>
        ///     <see cref="Campaign" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Campaign SetCampaignDefaultReplyTextAction(ulong campaignId, string message)
        {
            string resource = "/campaigns/" + campaignId + "/actions/default_reply";
            if (message.IsEmpty()) throw new Exception("Parameter 'message' cannot be empty ");
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("message", message);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Set the DynamicUrl of a campaign. It will return the updated campaign
        /// </summary>
        /// <param name="campaignId">The campaign Id</param>
        /// <param name="url">
        ///     A valid publicly accessible URL with one or more of the following query string parameters: %from% ,
        ///     %to% , %fulltext% , %keyword% , %text% (message without the keyword), %account% , and %campaign%.
        /// </param>
        /// <param name="sendResponse">The default values are Yes or No.</param>
        /// <returns>
        ///     <see cref="Campaign" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Campaign SetCampaignDynamicUrlAction(ulong campaignId, string url, string sendResponse)
        {
            string resource = "/campaigns/" + campaignId + "/actions/dynamic_url";
            if (url.IsValidUrl()) throw new Exception("Parameter 'url' must be a valid url");
            if (sendResponse.IsEmpty()) throw new HttpRequestException(new Exception("Parameter 'sendResponse' cannot be null"));
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("url", url).Set("send_response", sendResponse);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Set the DynamicUrl of a campaign. It will return the updated campaign. Here the sendResponse is set to No
        /// </summary>
        /// <param name="campaignId">The campaign Id</param>
        /// <param name="url">
        ///     A valid publicly accessible URL with one or more of the following query string parameters: %from% ,
        ///     %to% , %fulltext% , %keyword% , %text% (message without the keyword), %account% , and %campaign%.
        /// </param>
        /// <returns>
        ///     <see cref="Campaign" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Campaign SetCampaignDynamicUrlAction(ulong campaignId, string url)
        {
            return SetCampaignDynamicUrlAction(campaignId, url, "No");
        }

        /// <summary>
        ///     Set the email action of a campaign. It will return the updated campaign.
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <param name="address">the email address</param>
        /// <returns>
        ///     <see cref="Campaign" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Campaign SetCampaignEmailAddressAction(ulong campaignId, string address)
        {
            string resource = "/campaigns/" + campaignId + "/actions/email";
            if (address.IsEmail()) throw new Exception("Parameter 'address' must be a valid email ");
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("address", address);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Set mobile number acion of a campaign. It will return the updated campaign.
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <param name="number">The phone number</param>
        /// <returns>
        ///     <see cref="Campaign" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Campaign SetCampaignForwardToMobileAction(ulong campaignId, string number)
        {
            string resource = "/campaigns/" + campaignId + "/actions/phone";
            if (number.IsEmpty()) throw new Exception("Parameter 'number' must not be empty.");
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("number", number);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Set smpp action of a campaign. It will return the updated campaign.
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <param name="smppApiId">The Smpp API Id</param>
        /// <returns>
        ///     <see cref="Campaign" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Campaign SetCampaignForwardToSmppAction(ulong campaignId, string smppApiId)
        {
            string resource = "/campaigns/" + campaignId + "/actions/smpp";
            if (smppApiId.IsEmpty()) throw new Exception("Parameter 'smppApiId' must not be empty");
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("api_id", smppApiId);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Remove a campaign action. It will return the updated campaign.
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <param name="actionId">The action id</param>
        /// <returns>
        ///     <see cref="Campaign" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Campaign DeleteCampaignAction(ulong campaignId, ulong actionId)
        {
            string resource = "/campaigns/" + campaignId + "/actions/" + actionId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Campaign(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }
    }
}