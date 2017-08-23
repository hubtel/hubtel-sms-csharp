using System;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Represents an API action.
    /// </summary>
    public class Action
    {
        // Data fields.
        private readonly string _actionMeta;
        private readonly long _actionTypeId;
        private readonly long _campaignId;
        private readonly long _id;
        private readonly bool _isActive;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Action" /> class.
        /// </summary>
        public Action(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "actionmeta":
                        _actionMeta = Convert.ToString(jso[key]);
                        break;
                    case "actiontypeid":
                        _actionTypeId = Convert.ToInt64(jso[key]);
                        break;
                    case "campaignid":
                        _campaignId = Convert.ToInt64(jso[key]);
                        break;
                    case "id":
                        _id = Convert.ToInt64(jso[key]);
                        break;
                    case "isactive":
                        _isActive = Convert.ToBoolean(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the action meta of this API action.
        /// </summary>
        public string ActionMeta
        {
            get { return _actionMeta; }
        }

        /// <summary>
        ///     Gets the action type ID of this API action.
        /// </summary>
        public long ActionTypeId
        {
            get { return _actionTypeId; }
        }

        /// <summary>
        ///     Gets the campaign ID of this API action.
        /// </summary>
        public long CampaignId
        {
            get { return _campaignId; }
        }

        /// <summary>
        ///     Gets the ID of this API action.
        /// </summary>
        public long Id
        {
            get { return _id; }
        }

        /// <summary>
        ///     Indicates whether this API action is active.
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
        }
    }
}