using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     The contact API. Please refer to http://developers.smsgh.com for further information on how to set
    ///     some of the parameters
    /// </summary>
    /// <remarks>
    ///     All Exceptions thrown in this class contains the actual message of what has happened. Just by reading the
    ///     error message helps the developer to fix the issue.
    /// </remarks>
    public class ContactApi : AbstractApi
    {
        /// <summary>
        /// </summary>
        /// <param name="host"></param>
        public ContactApi(ApiHost host) : base(host) {}

        /// <summary>
        ///     Get the list of contacts. It can be done by certain filters.
        /// </summary>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">The number of the items on a page.</param>
        /// <param name="groupId">The group id.</param>
        /// <param name="filter">The search filter.</param>
        /// <returns>Custom List of <see cref="Contact" /> object. <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Contact> GetContacts(uint page, uint pageSize, ulong groupId, string filter)
        {
            const string resource = "/contacts/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));
            if (groupId > 0) parameterMap.Set("GroupId", Convert.ToString(groupId));
            if (!filter.IsEmpty()) parameterMap.Set("Search", filter.Trim());

            if (page == 0
                && pageSize == 0
                && groupId == 0
                && filter.IsEmpty()) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<Contact>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the list of contacts using the pagination filters
        /// </summary>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">The number of the items on a page.</param>
        /// <returns>Custom List of <see cref="Contact" /> object.<seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Contact> GetContacts(uint page, uint pageSize)
        {
            return GetContacts(page, pageSize, 0, string.Empty);
        }

        /// <summary>
        ///     Get the list of contacts by group using a search.
        /// </summary>
        /// <param name="groupId">The group id</param>
        /// <param name="filter">The search filter</param>
        /// <returns>Custom List of <see cref="Contact" /> object.<seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Contact> GetContacts(ulong groupId, string filter)
        {
            return GetContacts(0, 0, groupId, filter);
        }

        /// <summary>
        ///     Get the list of contact by group using the pagination filters
        /// </summary>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">The number of items on a page.</param>
        /// <param name="groupId">The group id</param>
        /// <returns>Custom List of <see cref="Contact" />  object.<seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Contact> GetContacts(uint page, uint pageSize, ulong groupId)
        {
            return GetContacts(page, pageSize, groupId, string.Empty);
        }

        /// <summary>
        ///     Get ths list of contact based upon pagination and seacrh filter
        /// </summary>
        /// <param name="page">The page index</param>
        /// <param name="pageSize">THe number of items on a page.</param>
        /// <param name="filter">The search filter</param>
        /// <returns>Custom List of <see cref="Contact" />  object.<seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Contact> GetContacts(uint page, uint pageSize, string filter)
        {
            return GetContacts(page, pageSize, 0, filter);
        }

        /// <summary>
        ///     Get the overall list of contacts
        /// </summary>
        /// <returns>Custom List of <see cref="Contact" />  object. <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Contact> GetContacts()
        {
            return GetContacts(0, 0, 0, string.Empty);
        }

        /// <summary>
        ///     Get the contact list by group
        /// </summary>
        /// <param name="groupId">The group id</param>
        /// <returns>Custom List of <see cref="Contact" />  object.<seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Contact> GetContacts(ulong groupId)
        {
            return GetContacts(0, 0, groupId, string.Empty);
        }

        /// <summary>
        ///     Get the contact list by search
        /// </summary>
        /// <param name="filter">The search filter</param>
        /// <returns>Custom List of <see cref="Contact" />  object.<seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<Contact> GetContacts(string filter)
        {
            return GetContacts(0, 0, 0, filter);
        }

        /// <summary>
        ///     Get a contact by its Id
        /// </summary>
        /// <param name="contactId">The contact Id.</param>
        /// <returns>A <see cref="Contact" />  object.</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Contact GetContact(ulong contactId)
        {
            string resource = "/contacts/" + contactId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new Contact(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Add a new contact. The contact data is key-value pairs data structure
        /// </summary>
        /// <param name="data">Contact parameter data <see cref="ParameterMap" /></param>
        /// <returns>A <see cref="Contact" />  object.</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Contact AddContact(ParameterMap data)
        {
            const string resource = "/contacts/";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            HttpResponse response = RestClient.Post(resource, data);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new Contact(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Add a new contact. The contact object to add.
        /// </summary>
        /// <param name="contact">The <see cref="Contact" /> object.</param>
        /// <returns>A <see cref="Contact" />  object.</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public Contact AddContact(Contact contact)
        {
            const string resource = "/contacts/";
            const string contentType = "application/json";
            if (contact == null) throw new Exception("Parameter 'contact' cannot be null");
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, contact);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new Contact(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates a contact details based upon some key-value pairs data structure.
        /// </summary>
        /// <param name="contactId">The contact Id to update</param>
        /// <param name="data">Contact data parameter <see cref="ParameterMap" /></param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool UpdateContact(ulong contactId, ParameterMap data)
        {
            string resource = "/contacts/";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += contactId;
            HttpResponse response = RestClient.Put(resource, data);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates a contact details based upon a contact object.
        /// </summary>
        /// <param name="contactId">The contact Id</param>
        /// <param name="data"><see cref="Contact" /> object.</param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool UpdateContact(ulong contactId, Contact data)
        {
            string resource = "/contacts/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += contactId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates a contact details based upon a contact object.
        /// </summary>
        /// <param name="data">The <see cref="Contact" /> object. </param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool UpdateContact(Contact data)
        {
            string resource = "/contacts/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += data.ContactId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Delete a contact
        /// </summary>
        /// <param name="contactId">The contact Id</param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool DeleteContact(ulong contactId)
        {
            string resource = "/contacts/" + contactId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }


        /// <summary>
        ///     Get the list of paginated contact groups
        /// </summary>
        /// <param name="page">The page index.</param>
        /// <param name="pageSize">The number of items on a page</param>
        /// <returns>ApiList of<see cref="ContactGroup" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<ContactGroup> GetContactGroups(uint page, uint pageSize)
        {
            const string resource = "/contacts/groups/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0
                && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<ContactGroup>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get the list of all contact group
        /// </summary>
        /// <returns>ApiList of<see cref="ContactGroup" /></returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<ContactGroup> GetContactGroups()
        {
            return GetContactGroups(0, 0);
        }

        /// <summary>
        ///     Get a contact group by Id.
        /// </summary>
        /// <param name="groupId">The contact group Id</param>
        /// <returns>A <see cref="ContactGroup" /> object.</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ContactGroup GetContactGroup(ulong groupId)
        {
            string resource = "/contacts/groups/" + groupId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ContactGroup(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Add a contact group
        /// </summary>
        /// <param name="group">The contact group object</param>
        /// <returns>A <see cref="ContactGroup" /> object.</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ContactGroup AddContactGroup(ContactGroup group)
        {
            const string resource = "/contacts/groups/";
            const string contentType = "application/json";
            if (group == null) throw new HttpRequestException(new Exception("Parameter 'group' cannot be null"));
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, group);
            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new ContactGroup(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Add a contact group using the contact group name
        /// </summary>
        /// <param name="groupName">The contact group name</param>
        /// <returns>A <see cref="ContactGroup" /> object.</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ContactGroup AddContactGroup(string groupName)
        {
            const string resource = "/contacts/groups/";
            if (groupName.IsEmpty())
                throw new HttpRequestException(new Exception("Parameter 'groupName' cannot be null"));
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("Name", groupName);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new ContactGroup(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Add a contact group using a key-value pairs data structure
        /// </summary>
        /// <param name="data">The contact group data <see cref="ParameterMap" /></param>
        /// <returns>A <see cref="ContactGroup" /> object.</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ContactGroup AddContactGroup(ParameterMap data)
        {
            const string resource = "/contacts/groups/";
            if (data == null) throw new HttpRequestException(new Exception("Parameter 'data' cannot be null"));
            HttpResponse response = RestClient.Post(resource, data);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new ContactGroup(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Update a contact group
        /// </summary>
        /// <param name="groupId">The contact group Id</param>
        /// <param name="data">The contact group data <see cref="ParameterMap" /></param>
        /// <returns>true when successful.</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool UpdateContactGroup(ulong groupId, ParameterMap data)
        {
            string resource = "/contacts/groups/";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += groupId;
            HttpResponse response = RestClient.Put(resource, data);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Update a contact group
        /// </summary>
        /// <param name="groupId">The contact group Id</param>
        /// <param name="data">The contact group data <see cref="ContactGroup" /></param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool UpdateContactGroup(ulong groupId, ContactGroup data)
        {
            string resource = "/contacts/groups/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += groupId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updae a contact group
        /// </summary>
        /// <param name="data">The contact group data <see cref="ContactGroup" /></param>
        /// <returns>true when successful.</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool UpdateContactGroup(ContactGroup data)
        {
            string resource = "/contacts/groups/";
            const string contentType = "application/json";
            if (data == null) throw new Exception("Parameter 'data' cannot be null");
            resource += data.GroupId;
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, data);
            HttpResponse response = RestClient.Put(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Update a contact group using the contact group name
        /// </summary>
        /// <param name="groupId">The contact group Id</param>
        /// <param name="groupName">The contact group name</param>
        /// <returns>true when successful.</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool UpdateContactGroup(ulong groupId, string groupName)
        {
            string resource = "/contacts/groups/";
            if (groupName.IsEmpty()) throw new Exception("Parameter 'groupName' cannot be null");
            resource += groupId;
            ParameterMap parameter = RestClient.NewParams();
            parameter.Set("Name", groupName);
            HttpResponse response = RestClient.Put(resource, parameter);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Delete a contact group
        /// </summary>
        /// <param name="groupId">The contact group Id</param>
        /// <returns>true when successful.</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool DeleteContactGroup(ulong groupId)
        {
            string resource = "/contacts/groups/" + groupId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }
    }
}