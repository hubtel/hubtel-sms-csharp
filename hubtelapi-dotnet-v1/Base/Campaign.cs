using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Represents an API campaign.
    /// </summary>
    public class Campaign
    {
        // Data fields.
        private readonly string _accountId;
        private readonly List<Action> _actions;
        private readonly long _campaignId;
        private readonly bool _enabled;
        private readonly bool _isDefault;
        private readonly List<MoKeyWord> _moKeywords;
        private readonly bool _pendingApproval;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Campaign" /> class.
        /// </summary>
        public Campaign() {}

        /// <summary>
        ///     Initializes a new instance of the <see cref="Campaign" />
        /// </summary>
        public Campaign(ApiDictionary jso)
        {
            _actions = new List<Action>();
            _moKeywords = new List<MoKeyWord>();

            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "accountid":
                        _accountId = Convert.ToString(jso[key]);
                        break;
                    case "actions":
                        var acs = jso[key] as IEnumerable;
                        if (acs != null) {
                            foreach (JObject o in acs)
                                _actions.Add(new Action(o.ToObject<ApiDictionary>()));
                        }
                        break;
                    case "brief":
                        Brief = Convert.ToString(jso[key]);
                        break;
                    case "campaignid":
                        _campaignId = Convert.ToInt64(jso[key]);
                        break;
                    case "datecreated":

                        if (jso[key].ToString() != "") {
                            DateTime dateCreated;
                            DateCreated = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated)
                                ? dateCreated
                                : (DateTime?) null;
                        }
                        break;
                    case "dateended":
                        if (jso[key].ToString() != "") {
                            DateTime dateEnded;
                            DateEnded = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateEnded)
                                ? dateEnded
                                : (DateTime?) null;
                        }
                        break;
                    case "description":
                        Description = Convert.ToString(jso[key]);
                        break;
                    case "enabled":
                        _enabled = Convert.ToBoolean(jso[key]);
                        break;
                    case "isdefault":
                        _isDefault = Convert.ToBoolean(jso[key]);
                        break;
                    case "mokeywords":
                        var mos = jso[key] as IEnumerable;
                        if (mos != null)
                            foreach (JObject mo in mos) _moKeywords.Add(new MoKeyWord(mo.ToObject<ApiDictionary>()));
                        break;
                    case "pendingapproval":
                        _pendingApproval = Convert.ToBoolean(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the account ID of this API campaign.
        /// </summary>
        [JsonIgnore]
        public string AccountId
        {
            get { return _accountId; }
        }

        /// <summary>
        ///     Gets the API actions of this API campaign.
        /// </summary>
        [JsonIgnore]
        public List<Action> Actions
        {
            get { return _actions; }
        }

        /// <summary>
        ///     Gets or sets the brief of this API campaign.
        /// </summary>
        public string Brief { get; set; }

        /// <summary>
        ///     Gets the ID of this API campaign.
        /// </summary>
        [JsonIgnore]
        public long CampaignId
        {
            get { return _campaignId; }
        }

        /// <summary>
        ///     Gets or sets the created date of this API campaign.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        ///     Gets or sets the end date of this API campaign.
        /// </summary>
        public DateTime? DateEnded { get; set; }

        /// <summary>
        ///     Gets or sets the description of this API campaign.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Indicates whether this API campaign is enabled.
        /// </summary>
        [JsonIgnore]
        public bool Enabled
        {
            get { return _enabled; }
        }

        /// <summary>
        ///     Indicated whether this API campaign is default.
        /// </summary>
        [JsonIgnore]
        public bool IsDefault
        {
            get { return _isDefault; }
        }

        /// <summary>
        ///     Gets the API MO keywords of this API campaign.
        /// </summary>
        [JsonIgnore]
        public List<MoKeyWord> MoKeywords
        {
            get { return _moKeywords; }
        }

        /// <summary>
        ///     Indicates whether this API campaign is pending approval.
        /// </summary>
        [JsonIgnore]
        public bool PendingApproval
        {
            get { return _pendingApproval; }
        }
    }
}