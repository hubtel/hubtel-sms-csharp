using System;
using System.Globalization;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Represents an API child account.
    /// </summary>
    public class ChildAccount
    {
        // Data fields.
        private readonly long _accountNumber;
        private readonly double _balance;
        private readonly bool _canImpersonate;
        private readonly string _child;
        private readonly double _credit;
        private readonly long _id;
        private readonly string _parent;
        private readonly string _productId;
        private readonly string _productName;
        private readonly int _status;
        private readonly DateTime? _timeCreated;
        private readonly DateTime? _timeRemoved;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChildAccount" /> class.
        /// </summary>
        public ChildAccount(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "accountnumber":
                        _accountNumber = Convert.ToInt64(jso[key]);
                        break;
                    case "balance":
                        _balance = Convert.ToDouble(jso[key]);
                        break;
                    case "canimpersonate":
                        _canImpersonate = Convert.ToBoolean(jso[key]);
                        break;
                    case "child":
                        _child = Convert.ToString(jso[key]);
                        break;
                    case "credit":
                        _credit = Convert.ToDouble(jso[key]);
                        break;
                    case "id":
                        _id = Convert.ToInt64(jso[key]);
                        break;
                    case "parent":
                        _parent = Convert.ToString(jso[key]);
                        break;
                    case "productid":
                        _productId = Convert.ToString(jso[key]);
                        break;
                    case "productname":
                        _productName = Convert.ToString(jso[key]);
                        break;
                    case "status":
                        _status = Convert.ToInt32(jso[key]);
                        break;
                    case "timecreated":
                        DateTime dateCreated;
                        if (jso[key].ToString() != "") {
                            _timeCreated = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated)
                                ? dateCreated
                                : (DateTime?) null;
                        }

                        break;
                    case "timeremoved":
                        DateTime tmr;
                        if (jso[key].ToString() != "")
                            _timeRemoved = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out tmr) ? tmr : (DateTime?) null;

                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the account number of this API child account.
        /// </summary>
        public long AccountNumber
        {
            get { return _accountNumber; }
        }

        /// <summary>
        ///     Gets the balance of this API child account.
        /// </summary>
        public double Balance
        {
            get { return _balance; }
        }

        /// <summary>
        ///     Indicates whether this API child account can be impersonated.
        /// </summary>
        public bool CanImpersonate
        {
            get { return _canImpersonate; }
        }

        /// <summary>
        ///     Gets the child of this API child account.
        /// </summary>
        public string Child
        {
            get { return _child; }
        }

        /// <summary>
        ///     Gets the credit of this API child account.
        /// </summary>
        public double Credit
        {
            get { return _credit; }
        }

        /// <summary>
        ///     Gets the ID of this API child account.
        /// </summary>
        public long Id
        {
            get { return _id; }
        }

        /// <summary>
        ///     Gets the parent of this API child account.
        /// </summary>
        public string Parent
        {
            get { return _parent; }
        }

        /// <summary>
        ///     Gets the product ID of this API child account.
        /// </summary>
        public string ProductId
        {
            get { return _productId; }
        }

        /// <summary>
        ///     Gets the product name of this API child account.
        /// </summary>
        public string ProductName
        {
            get { return _productName; }
        }

        /// <summary>
        ///     Gets the status of this API child account.
        /// </summary>
        public int Status
        {
            get { return _status; }
        }

        /// <summary>
        ///     Gets the created time of this API child account.
        /// </summary>
        public DateTime? TimeCreated
        {
            get { return _timeCreated; }
        }

        /// <summary>
        ///     Gets the removed time of this API child account.
        /// </summary>
        public DateTime? TimeRemoved
        {
            get { return _timeRemoved; }
        }
    }
}