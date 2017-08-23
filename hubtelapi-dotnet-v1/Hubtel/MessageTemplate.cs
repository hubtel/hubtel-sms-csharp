using System;
using System.Globalization;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Represents an API message template.
    /// </summary>
    public class MessageTemplate
    {
        // Data fields.
        private readonly DateTime? _dateCreated;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageTemplate" /> class.
        /// </summary>
        public MessageTemplate() {}

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        public MessageTemplate(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "accountid":
                        AccountId = Convert.ToString(jso[key]);
                        break;
                    case "datecreated":
                        if (jso[key].ToString() != "") {
                            DateTime dateCreated;
                            _dateCreated = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated)
                                ? dateCreated
                                : (DateTime?) null;
                        }
                        break;
                    case "id":
                        Id = Convert.ToInt64(jso[key]);
                        break;
                    case "name":
                        Name = Convert.ToString(jso[key]);
                        break;
                    case "text":
                        Text = Convert.ToString(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the account ID of this API message template.
        /// </summary>
        [JsonIgnore]
        public string AccountId { get; private set; }

        /// <summary>
        ///     Gets the created date of this API message template.
        /// </summary>
        [JsonIgnore]
        public DateTime? DateCreated
        {
            get { return _dateCreated; }
        }

        /// <summary>
        ///     Gets the ID of this API message template.
        /// </summary>
        [JsonIgnore]
        public long Id { get; private set; }

        /// <summary>
        ///     Gets or sets the name of this API message template.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the text of this API message template.
        /// </summary>
        public string Text { get; set; }
    }
}