using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Represents an API number plan.
    /// </summary>
    public class NumberPlan
    {
        // Data fields.
        private readonly DateTime? _dateActivated;
        private readonly DateTime? _dateCreated;
        private readonly DateTime? _dateDeactivated;
        private readonly DateTime? _dateExpiring;
        private readonly double _initialCost;
        private readonly bool _isActive;
        private readonly bool _isPremium;
        private readonly int _maxAllowedKeywords;
        private readonly List<MoKeyWord> _moKeywords;
        private readonly string _notes;
        private readonly List<NumberPlanItem> _numberPlanItems;
        private readonly double _periodicCostBasis;
        private readonly ServiceType _serviceType;

        /// <summary>
        ///     Used internally to initialize a new instance of this class.
        /// </summary>
        public NumberPlan(ApiDictionary jso)
        {
            _moKeywords = new List<MoKeyWord>();
            _numberPlanItems = new List<NumberPlanItem>();

            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "accountid":
                        AccountId = Convert.ToString(jso[key]);
                        break;
                    case "dateactivated":
                        if (jso[key].ToString() != "") {
                            DateTime dateActivated;
                            _dateActivated = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateActivated)
                                ? dateActivated
                                : (DateTime?) null;
                        }

                        break;
                    case "datecreated":
                        if (jso[key].ToString() != "") {
                            DateTime dateCreated;
                            _dateCreated = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated)
                                ? dateCreated
                                : (DateTime?) null;
                        }
                        break;
                    case "datedeactivated":
                        DateTime dateDeactivated;
                        if (jso[key].ToString() != "") {
                            _dateDeactivated = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateDeactivated)
                                ? dateDeactivated
                                : (DateTime?) null;
                        }
                        break;
                    case "dateexpiring":
                        DateTime dateExpiring;
                        if (jso[key].ToString() != "") {
                            _dateExpiring = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateExpiring)
                                ? dateExpiring
                                : (DateTime?) null;
                        }
                        break;
                    case "description":
                        Description = Convert.ToString(jso[key]);
                        break;
                    case "id":
                        Id = Convert.ToInt64(jso[key]);
                        break;
                    case "initialcost":
                        _initialCost = Convert.ToDouble(jso[key]);
                        break;
                    case "isactive":
                        _isActive = Convert.ToBoolean(jso[key]);
                        break;
                    case "ispremium":
                        _isPremium = Convert.ToBoolean(jso[key]);
                        break;
                    case "maxallowedkeywords":
                        _maxAllowedKeywords = Convert.ToInt32(jso[key]);
                        break;
                    case "mokeywords":
                        var mos = jso[key] as IEnumerable;
                        if (mos != null) {
                            foreach (JObject o in mos)
                                _moKeywords.Add(new MoKeyWord(o.ToObject<ApiDictionary>()));
                        }
                        break;
                    case "notes":
                        _notes = Convert.ToString(jso[key]);
                        break;
                    case "numberplanitems":
                        var os = jso[key] as IEnumerable;
                        if (os != null) {
                            foreach (JObject o in os)
                                _numberPlanItems.Add(new NumberPlanItem(o.ToObject<ApiDictionary>()));
                        }
                        break;
                    case "periodiccostbasis":
                        _periodicCostBasis = Convert.ToDouble(jso[key]);
                        break;
                    case "servicetype":
                        var svc = jso[key] as JObject;
                        _serviceType = new ServiceType(svc.ToObject<ApiDictionary>());
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the account ID of this API number plan.
        /// </summary>
        public string AccountId { get; private set; }

        /// <summary>
        ///     Gets the activated date of this API number plan.
        /// </summary>
        public DateTime? DateActivated
        {
            get { return _dateActivated; }
        }

        /// <summary>
        ///     Gets the created date of this API number plan.
        /// </summary>
        public DateTime? DateCreated
        {
            get { return _dateCreated; }
        }

        /// <summary>
        ///     Gets the deactivated date of this API number plan.
        /// </summary>
        public DateTime? DateDeactivated
        {
            get { return _dateDeactivated; }
        }

        /// <summary>
        ///     Gets the expiring date of this API number plan.
        /// </summary>
        public DateTime? DateExpiring
        {
            get { return _dateExpiring; }
        }

        /// <summary>
        ///     Gets the description of this API number plan.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        ///     Gets the ID of this API number plan.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        ///     Gets the initial cost of this API number plan.
        /// </summary>
        public double InitialCost
        {
            get { return _initialCost; }
        }

        /// <summary>
        ///     Indicated whether this API number plan is active.
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
        }

        /// <summary>
        ///     Indicates whether this API number plan is a premium.
        /// </summary>
        public bool IsPremium
        {
            get { return _isPremium; }
        }

        /// <summary>
        ///     Gets the maximum allowed keywords on this API number plan.
        /// </summary>
        public int MaxAllowedKeywords
        {
            get { return _maxAllowedKeywords; }
        }

        /// <summary>
        ///     Gets the API MO keywords this API number plan.
        /// </summary>
        public List<MoKeyWord> MoKeywords
        {
            get { return _moKeywords; }
        }

        /// <summary>
        ///     Gets the notes of this API number plan.
        /// </summary>
        public string Notes
        {
            get { return _notes; }
        }

        /// <summary>
        ///     Gets the API number plan items of this API number plan.
        /// </summary>
        public List<NumberPlanItem> NumberPlanItems
        {
            get { return _numberPlanItems; }
        }

        /// <summary>
        ///     Gets the periodic cost basis of this API number plan.
        /// </summary>
        public double PeriodicCostBasis
        {
            get { return _periodicCostBasis; }
        }

        /// <summary>
        ///     Gets the API service type of this API number plan.
        /// </summary>
        public ServiceType ServiceType
        {
            get { return _serviceType; }
        }
    }
}