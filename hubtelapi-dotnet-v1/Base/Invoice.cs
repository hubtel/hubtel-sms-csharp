using System;
using System.Globalization;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Represents an API invoice.
    /// </summary>
    public class Invoice
    {
        // Data fields.
        private readonly double _amount;
        private readonly DateTime? _created;
        private readonly string _description;
        private readonly DateTime? _dueDate;
        private readonly double _ending;
        private readonly long _id;
        private readonly bool _isPaid;
        private readonly string _type;

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        public Invoice(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "amount":
                        _amount = Convert.ToDouble(jso[key]);
                        break;
                    case "created":
                        DateTime dateCreated;
                        if (jso[key].ToString() != "") {
                            _created = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated)
                                ? dateCreated
                                : (DateTime?) null;
                        }

                        break;
                    case "description":
                        _description = Convert.ToString(jso[key]);
                        break;
                    case "duedate":
                        if (jso[key].ToString() != "") {
                            _dueDate = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated)
                                ? dateCreated
                                : (DateTime?) null;
                        }

                        break;
                    case "ending":
                        _ending = Convert.ToDouble(jso[key]);
                        break;
                    case "id":
                        _id = Convert.ToInt64(jso[key]);
                        break;
                    case "ispaid":
                        _isPaid = Convert.ToBoolean(jso[key]);
                        break;
                    case "type":
                        _type = Convert.ToString(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the amount of this API invoice.
        /// </summary>
        public double Amount
        {
            get { return _amount; }
        }

        /// <summary>
        ///     Gets the created date of this API invoice.
        /// </summary>
        public DateTime? Created
        {
            get { return _created; }
        }

        /// <summary>
        ///     Gets the description of this API invoice.
        /// </summary>
        public string Description
        {
            get { return _description; }
        }

        /// <summary>
        ///     Gets the due date of this API invoice.
        /// </summary>
        public DateTime? DueDate
        {
            get { return _dueDate; }
        }

        /// <summary>
        ///     Gets the ending of this API invoice.
        /// </summary>
        public double Ending
        {
            get { return _ending; }
        }

        /// <summary>
        ///     Gets the ID of this API invoice.
        /// </summary>
        public long Id
        {
            get { return _id; }
        }

        /// <summary>
        ///     Indicates whether this API invoice is paid.
        /// </summary>
        public bool IsPaid
        {
            get { return _isPaid; }
        }

        /// <summary>
        ///     Gets the type of this API invoice.
        /// </summary>
        public string Type
        {
            get { return _type; }
        }
    }
}