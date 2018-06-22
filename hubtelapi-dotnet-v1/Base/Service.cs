using System;
using System.Globalization;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Represents an API service.
    /// </summary>
    public class Service
    {
        // Data fields.
        private readonly DateTime? _billDate;
        private readonly DateTime? _dateCreated;

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        public Service(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "accountid":
                        AccountId = Convert.ToString(jso[key]);
                        break;
                    case "billdate":
                        DateTime billDate;
                        if (jso[key].ToString() != "")
                            _billDate = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out billDate)
                                ? billDate
                                : (DateTime?) null;

                        break;
                    case "billingcycleid":
                        BillingCycleId = Convert.ToInt64(jso[key]);
                        break;
                    case "datecreated":
                        if (jso[key].ToString() != "") {
                            DateTime dateCreated;
                            _dateCreated = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated)
                                ? dateCreated
                                : (DateTime?) null;
                        }

                        break;
                    case "description":
                        Description = Convert.ToString(jso[key]);
                        break;
                    case "iscreditbased":
                        IsCreditBased = Convert.ToBoolean(jso[key]);
                        break;
                    case "isprepaid":
                        IsPrepaid = Convert.ToBoolean(jso[key]);
                        break;
                    case "rate":
                        Rate = Convert.ToDecimal(jso[key]);
                        break;
                    case "serviceid":
                        ServiceId = Convert.ToInt64(jso[key]);
                        break;
                    case "servicestatustypeid":
                        ServiceStatusTypeId = Convert.ToInt64(jso[key]);
                        break;
                    case "servicetypeid":
                        ServiceTypeId = Convert.ToInt64(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        /// </summary>
        public Service() {}

        /// <summary>
        ///     Gets the account ID of this API service.
        /// </summary>
        public string AccountId { get; private set; }

        /// <summary>
        ///     Gets the bill date of this API service.
        /// </summary>
        public DateTime BillDate
        {
            get
            {
                if (_billDate != null) return (DateTime) _billDate;
                return new DateTime();
            }
        }

        /// <summary>
        ///     Gets the billing cycle ID of this API service.
        /// </summary>
        public long BillingCycleId { get; private set; }

        /// <summary>
        ///     Gets the created date of this API service.
        /// </summary>
        public DateTime? DateCreated
        {
            get { return _dateCreated; }
        }

        /// <summary>
        ///     Gets the description of this API service.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        ///     Indicates whether this API service is credit based.
        /// </summary>
        public bool IsCreditBased { get; private set; }

        /// <summary>
        ///     Indicated whether this API service is prepaid.
        /// </summary>
        public bool IsPrepaid { get; private set; }

        /// <summary>
        ///     Gets the rate of this API service.
        /// </summary>
        public decimal Rate { get; private set; }

        /// <summary>
        ///     Gets the ID of this API service.
        /// </summary>
        public long ServiceId { get; private set; }

        /// <summary>
        ///     Gets the status type ID of this API service.
        /// </summary>
        public long ServiceStatusTypeId { get; private set; }

        /// <summary>
        ///     Gets the type ID of this API service.
        /// </summary>
        public long ServiceTypeId { get; private set; }
    }
}