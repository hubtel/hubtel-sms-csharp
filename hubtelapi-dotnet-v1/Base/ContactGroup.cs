using System;
using Newtonsoft.Json;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Represents an API contact group.
    /// </summary>
    public class ContactGroup
    {
        // Data fields.
        private readonly string _accountId;
        private readonly long _contactCount;
        private readonly long _groupId;

        /// <summary>
        ///     Initializes a new instance of this API contact group.
        /// </summary>
        public ContactGroup() {}

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        public ContactGroup(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "accountid":
                        _accountId = Convert.ToString(jso[key]);
                        break;
                    case "contactcount":
                        _contactCount = Convert.ToInt64(jso[key]);
                        break;
                    case "groupid":
                        _groupId = Convert.ToInt64(jso[key]);
                        break;
                    case "name":
                        Name = Convert.ToString(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the account ID of this API contact group.
        /// </summary>
        [JsonIgnore]
        public string AccountId
        {
            get { return _accountId; }
        }

        /// <summary>
        ///     Gets the contact count of this API contact group.
        /// </summary>
        [JsonIgnore]
        public long ContactCount
        {
            get { return _contactCount; }
        }

        /// <summary>
        ///     Gets the ID of this API contact group.
        /// </summary>
        [JsonIgnore]
        public long GroupId
        {
            get { return _groupId; }
        }

        /// <summary>
        ///     Gets or sets the name of this API contact group.
        /// </summary>
        public string Name { get; set; }
    }
}