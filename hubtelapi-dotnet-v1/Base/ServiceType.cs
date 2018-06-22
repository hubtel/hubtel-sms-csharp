using System;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Represents an API service type.
    /// </summary>
    public class ServiceType
    {
        // Data fields.
        private readonly string _descriptor;
        private readonly bool _isCreditBased;
        private readonly bool _isPrepaid;
        private readonly string _name;
        private readonly double _rate;
        private readonly bool _requiresActivation;

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        public ServiceType(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "descriptor":
                        _descriptor = Convert.ToString(jso[key]);
                        break;
                    case "iscreditbased":
                        _isCreditBased = Convert.ToBoolean(jso[key]);
                        break;
                    case "isprepaid":
                        _isPrepaid = Convert.ToBoolean(jso[key]);
                        break;
                    case "name":
                        _name = Convert.ToString(jso[key]);
                        break;
                    case "rate":
                        _rate = Convert.ToDouble(jso[key]);
                        break;
                    case "requiresactivation":
                        _requiresActivation = Convert.ToBoolean(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the descriptor of this API service type.
        /// </summary>
        public string Descriptor
        {
            get { return _descriptor; }
        }

        /// <summary>
        ///     Indicated whether this API service type is credit based.
        /// </summary>
        public bool IsCreditBased
        {
            get { return _isCreditBased; }
        }

        /// <summary>
        ///     Indicated whether this API service type is prepaid.
        /// </summary>
        public bool IsPrepaid
        {
            get { return _isPrepaid; }
        }

        /// <summary>
        ///     Gets the name of this API service type.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        ///     Gets the rate of this API service type.
        /// </summary>
        public double Rate
        {
            get { return _rate; }
        }

        /// <summary>
        ///     Indicated whether this API service type requires activation.
        /// </summary>
        public bool RequiresActivation
        {
            get { return _requiresActivation; }
        }
    }
}