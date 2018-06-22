using System;
using Newtonsoft.Json;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Represents an API contact.
    /// </summary>
    public class Contact
    {
        // Data fields.
        private readonly long _contactId;
        private readonly string _groupName;
        private readonly string _owner;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Contact" /> class.
        /// </summary>
        public Contact() {}

        /// <summary>
        ///     Used internally to initialize the instance of this class.
        /// </summary>
        public Contact(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "contactid":
                        _contactId = Convert.ToInt64(jso[key]);
                        break;
                    case "custom1":
                        Custom1 = Convert.ToString(jso[key]);
                        break;
                    case "custom2":
                        Custom2 = Convert.ToString(jso[key]);
                        break;
                    case "custom3":
                        Custom3 = Convert.ToString(jso[key]);
                        break;
                    case "firstname":
                        FirstName = Convert.ToString(jso[key]);
                        break;
                    case "groupid":
                        GroupId = Convert.ToInt64(jso[key]);
                        break;
                    case "groupname":
                        _groupName = Convert.ToString(jso[key]);
                        break;
                    case "mobilenumber":
                        MobileNumber = Convert.ToString(jso[key]);
                        break;
                    case "owner":
                        _owner = Convert.ToString(jso[key]);
                        break;
                    case "surname":
                        Surname = Convert.ToString(jso[key]);
                        break;
                    case "title":
                        Title = Convert.ToString(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the ID of this API contact.
        /// </summary>
        [JsonIgnore]
        public long ContactId
        {
            get { return _contactId; }
        }

        /// <summary>
        ///     Gets or sets the custom 1 of this API contact.
        /// </summary>
        public string Custom1 { get; set; }

        /// <summary>
        ///     Gets or sets the custom 2 of this API contact.
        /// </summary>
        public string Custom2 { get; set; }

        /// <summary>
        ///     Gets or sets the custom 3 of this API contact.
        /// </summary>
        public string Custom3 { get; set; }

        /// <summary>
        ///     Gets or sets the first name of this API contact.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the group ID of this API contact.
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        ///     Gets the group name of this API contact.
        /// </summary>
        [JsonIgnore]
        public string GroupName
        {
            get { return _groupName; }
        }

        /// <summary>
        ///     Gets or sets the mobile number of this API contact.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        ///     Gets the owner of this API contact.
        /// </summary>
        [JsonIgnore]
        public string Owner
        {
            get { return _owner; }
        }

        /// <summary>
        ///     Gets or sets the surname of this API contact.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        ///     Gets or sets the title of this API contact.
        /// </summary>
        public string Title { get; set; }
    }
}