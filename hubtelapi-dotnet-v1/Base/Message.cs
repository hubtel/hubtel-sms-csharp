using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Represents an API message.
    /// </summary>
    public class Message
    {
        // Data fields.
        private readonly string _direction;
        private readonly Guid _messageId;
        private readonly string _networkId;
        private readonly double _rate;
        private readonly string _status;
        private readonly double _units;
        private readonly DateTime? _updateTime;

        /// <summary>
        ///     Initializes a new instance of this API message.
        /// </summary>
        public Message() {}

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        public Message(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "type":
                        Type = Convert.ToInt32(jso[key]);
                        break;
                    case "clientreference":
                        ClientReference = Convert.ToString(jso[key]);
                        break;
                    case "content":
                        Content = Convert.ToString(jso[key]);
                        break;
                    case "direction":
                        _direction = Convert.ToString(jso[key]);
                        break;
                    case "flashmessage":
                        FlashMessage = Convert.ToBoolean(jso[key]);
                        break;
                    case "from":
                        From = Convert.ToString(jso[key]);
                        break;
                    case "messageid":
                        _messageId = new Guid(Convert.ToString(jso[key]));
                        break;
                    case "networkid":
                        _networkId = Convert.ToString(jso[key]);
                        break;
                    case "rate":
                        _rate = Convert.ToDouble(jso[key]);
                        break;
                    case "registereddelivery":
                        RegisteredDelivery = Convert.ToBoolean(jso[key]);
                        break;
                    case "status":
                        _status = Convert.ToString(jso[key]);
                        break;
                    case "time":
                        //Time = Convert.ToDateTime(jso[key]);
                        DateTime time;
                        if (jso[key].ToString() != "")
                            Time = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out time) ? time : (DateTime?) null;
                        break;
                    case "to":
                        To = Convert.ToString(jso[key]);
                        break;
                    case "billinginfo":
                        BillingInfo = Convert.ToString(jso[key]);
                        break;
                    case "udh":
                        Udh = Convert.ToString(jso[key]);
                        break;
                    case "units":
                        _units = Convert.ToDouble(jso[key]);
                        break;
                    case "updatetime":
                        //_updateTime = Convert.ToDateTime(jso[key]);

                        DateTime dateCreated;
                        if (jso[key].ToString() != "") {
                            _updateTime = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated)
                                ? dateCreated
                                : (DateTime?) null;
                        }

                        break;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the API message type of this API message.
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        ///     Gets or sets the client reference of this API message.
        /// </summary>
        public string ClientReference { get; set; }

        /// <summary>
        ///     Gets or sets the content of this API message.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     Gets the direction of this API message.
        /// </summary>
        [JsonIgnore]
        public string Direction
        {
            get { return _direction; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether is this API message is flash.
        /// </summary>
        public bool FlashMessage { get; set; }

        /// <summary>
        ///     Gets or sets the originator of this API message.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        ///     Gets the ID of this API message.
        /// </summary>
        [JsonIgnore]
        public Guid MessageId
        {
            get { return _messageId; }
        }

        /// <summary>
        ///     Gets the network ID of this API message.
        /// </summary>
        [JsonIgnore]
        public string NetworkId
        {
            get { return _networkId; }
        }

        /// <summary>
        ///     Gets the rate of this API message.
        /// </summary>
        [JsonIgnore]
        public double Rate
        {
            get { return _rate; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this API message is registered delivery.
        /// </summary>
        public bool RegisteredDelivery { get; set; }

        /// <summary>
        ///     Gets the status of this API message.
        /// </summary>
        [JsonIgnore]
        public string Status
        {
            get { return _status; }
        }

        /// <summary>
        ///     Gets or sets the scheduled time of this API message.
        /// </summary>
        public DateTime? Time { get; set; }

        /// <summary>
        ///     Gets or sets the destination of this API message.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        ///     Gets or sets the UDH of this API message.
        /// </summary>
        public string Udh { get; set; }

        /// <summary>
        ///     Gets or sets the BillingInfo
        /// </summary>
        public string BillingInfo { get; set; }

        /// <summary>
        ///     Gets the units of this API message.
        /// </summary>
        [JsonIgnore]
        public double Units
        {
            get { return _units; }
        }

        /// <summary>
        ///     Gets the update time of this API message.
        /// </summary>
        [JsonIgnore]
        public DateTime? UpdateTime
        {
            get { return _updateTime; }
        }
    }
}