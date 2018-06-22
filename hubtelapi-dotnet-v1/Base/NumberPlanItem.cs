using System;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Represents an API number plan item.
    /// </summary>
    public class NumberPlanItem
    {
        // Data fields.
        private readonly long _id;
        private readonly string _network;
        private readonly double _payout;
        private readonly double _reversePayout;
        private readonly string _shortCode;

        /// <summary>
        ///     Used internally to initialize this API number plan item.
        /// </summary>
        public NumberPlanItem(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "id":
                        _id = Convert.ToInt64(jso[key]);
                        break;
                    case "network":
                        _network = Convert.ToString(jso[key]);
                        break;
                    case "payout":
                        _payout = Convert.ToDouble(jso[key]);
                        break;
                    case "reversepayout":
                        _reversePayout = Convert.ToDouble(jso[key]);
                        break;
                    case "shortcode":
                        _shortCode = Convert.ToString(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the ID of this API number plan item.
        /// </summary>
        public long Id
        {
            get { return _id; }
        }

        /// <summary>
        ///     Gets the network of this API number plan item.
        /// </summary>
        public string Network
        {
            get { return _network; }
        }

        /// <summary>
        ///     Gets the payout of this API number plan item.
        /// </summary>
        public double Payout
        {
            get { return _payout; }
        }

        /// <summary>
        ///     Gets the reverse payout of this API number plan item.
        /// </summary>
        public double ReversePayout
        {
            get { return _reversePayout; }
        }

        /// <summary>
        ///     Gets the short code of this API number plan item.
        /// </summary>
        public string ShortCode
        {
            get { return _shortCode; }
        }
    }
}