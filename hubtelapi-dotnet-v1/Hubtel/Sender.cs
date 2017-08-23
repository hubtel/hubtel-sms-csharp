using System;
using System.Globalization;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Represents an API sender.
    /// </summary>
    public class Sender
    {
        // Data fields.
        private readonly bool _isDeleted;
        private readonly DateTime? _timeAdded;
        private readonly DateTime? _timeDeleted;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sender" /> class.
        /// </summary>
        public Sender() {}

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        public Sender(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "accountid":
                        AccountId = Convert.ToString(jso[key]);
                        break;
                    case "address":
                        Address = Convert.ToString(jso[key]);
                        break;
                    case "id":
                        Id = Convert.ToInt64(jso[key]);
                        break;
                    case "isdeleted":
                        _isDeleted = Convert.ToBoolean(jso[key]);
                        break;
                    case "timeadded":
                        if (jso[key].ToString() != "") {
                            DateTime dateCreated;
                            _timeAdded = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated)
                                ? dateCreated
                                : (DateTime?) null;
                        }
                        break;
                    case "timedeleted":
                        DateTime td;
                        if (jso[key].ToString() != "")
                            _timeDeleted = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out td) ? td : (DateTime?) null;
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the account ID of this API sender.
        /// </summary>
        [JsonIgnore]
        public string AccountId { get; private set; }

        /// <summary>
        ///     Gets or sets the address of this API sender.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Gets the ID of this API sender.
        /// </summary>
        [JsonIgnore]
        public long Id { get; private set; }

        /// <summary>
        ///     Indicated whether this API sender is deleted.
        /// </summary>
        [JsonIgnore]
        public bool IsDeleted
        {
            get { return _isDeleted; }
        }

        /// <summary>
        ///     Gets the created date of this API sender.
        /// </summary>
        [JsonIgnore]
        public DateTime? TimeAdded
        {
            get { return _timeAdded; }
        }

        /// <summary>
        ///     Gets the deleted date of this API sender.
        /// </summary>
        [JsonIgnore]
        public DateTime? TimeDeleted
        {
            get { return _timeDeleted; }
        }
    }
}