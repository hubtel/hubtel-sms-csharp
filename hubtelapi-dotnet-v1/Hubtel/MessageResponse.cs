using System;
using System.Collections.Generic;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Represents an API message response.
    /// </summary>
    public class MessageResponse
    {
        // Data fields.
        private readonly string _clientReference;
        private readonly Dictionary<string, string> _detail;
        private readonly Guid _messageId;
        private readonly string _networkId;
        private readonly double _rate;
        private readonly int _status;

        /// <summary>
        ///     Initializes a new instance of this API message response.
        /// </summary>
        public MessageResponse() {}

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        public MessageResponse(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "clientreference":
                        _clientReference = Convert.ToString(jso[key]);
                        break;
                    case "detail":
                        // ???
                        _detail = null; // Suppress compiler warning.
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
                    case "status":
                        _status = Convert.ToInt32(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the status of this API message response.
        /// </summary>
        public int Status
        {
            get { return _status; }
        }

        /// <summary>
        ///     Gets the message ID of this API message response.
        /// </summary>
        public Guid MessageId
        {
            get { return _messageId; }
        }

        /// <summary>
        ///     Gets the rate of this API message response.
        /// </summary>
        public double Rate
        {
            get { return _rate; }
        }

        /// <summary>
        ///     Gets the network ID of this API message response.
        /// </summary>
        public string NetworkId
        {
            get { return _networkId; }
        }

        /// <summary>
        ///     Gets the client reference of this API message response.
        /// </summary>
        public string ClientReference
        {
            get { return _clientReference; }
        }

        /// <summary>
        ///     Gets the detail of this API message response.
        /// </summary>
        public Dictionary<string, string> Detail
        {
            get { return _detail; }
        }
    }
}