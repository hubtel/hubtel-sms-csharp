using System;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Represents an API account contact.
    /// </summary>
    public class AccountContact
    {
        // Data fields.
        private readonly long _accountContactId;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccountContact" /> class.
        /// </summary>
        public AccountContact(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "accountcontactid":
                        _accountContactId = Convert.ToInt64(jso[key]);
                        break;
                    case "address1":
                        Address1 = Convert.ToString(jso[key]);
                        break;
                    case "address2":
                        Address2 = Convert.ToString(jso[key]);
                        break;
                    case "city":
                        City = Convert.ToString(jso[key]);
                        break;
                    case "country":
                        Country = Convert.ToString(jso[key]);
                        break;
                    case "firstname":
                        FirstName = Convert.ToString(jso[key]);
                        break;
                    case "lastname":
                        LastName = Convert.ToString(jso[key]);
                        break;
                    case "province":
                        Province = Convert.ToString(jso[key]);
                        break;
                    case "postalcode":
                        PostalCode = Convert.ToString(jso[key]);
                        break;
                    case "primaryemail":
                        PrimaryEmail = Convert.ToString(jso[key]);
                        break;
                    case "primaryphone":
                        PrimaryPhone = Convert.ToString(jso[key]);
                        break;
                    case "privatenote":
                        PrivateNote = Convert.ToString(jso[key]);
                        break;
                    case "publicnote":
                        PublicNote = Convert.ToString(jso[key]);
                        break;
                    case "secondaryemail":
                        SecondaryEmail = Convert.ToString(jso[key]);
                        break;
                    case "secondaryphone":
                        SecondaryPhone = Convert.ToString(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the ID of this account contact.
        /// </summary>
        [JsonIgnore]
        public long AccountContactId
        {
            get { return _accountContactId; }
        }

        /// <summary>
        ///     Gets or sets the address 1 of this account contact.
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        ///     Gets or sets the address 2 of this account contact.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        ///     Gets or sets the city of this account contact.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Gets or sets the country of this account contact.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Gets or sets the first name of this account contact.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name of this account contact.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the province of this account contact.
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        ///     Gets or sets the postal code of this account contact.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        ///     Gets or sets the primary email of this account contact.
        /// </summary>
        public string PrimaryEmail { get; set; }

        /// <summary>
        ///     Gets or sets the primary phone number of this account contact.
        /// </summary>
        public string PrimaryPhone { get; set; }

        /// <summary>
        ///     Gets or sets the private note of this account contact.
        /// </summary>
        public string PrivateNote { get; set; }

        /// <summary>
        ///     Gets or sets the public note of this account contact.
        /// </summary>
        public string PublicNote { get; set; }

        /// <summary>
        ///     Gets or sets the secondary email of this account contact.
        /// </summary>
        public string SecondaryEmail { get; set; }

        /// <summary>
        ///     Gets or sets the secondary phone of this account contact.
        /// </summary>
        public string SecondaryPhone { get; set; }
    }
}