// $Id: ApiMoKeyWord.cs 0 1970-01-01 00:00:00Z mkwayisi $

using System;
using Newtonsoft.Json;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Represents an API MO keyword.
    /// </summary>
    public class MoKeyWord
    {
        // Data fields.
        private readonly long _id;
        private readonly bool _isDefault;
        private bool _isActive;

        /// <summary>
        ///     Initializes a new instance of this API MO keyword class.
        /// </summary>
        public MoKeyWord() {}

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        public MoKeyWord(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "alias1":
                        Alias1 = Convert.ToString(jso[key]);
                        break;
                    case "alias2":
                        Alias2 = Convert.ToString(jso[key]);
                        break;
                    case "alias3":
                        Alias3 = Convert.ToString(jso[key]);
                        break;
                    case "alias4":
                        Alias4 = Convert.ToString(jso[key]);
                        break;
                    case "alias5":
                        Alias5 = Convert.ToString(jso[key]);
                        break;
                    case "id":
                        _id = Convert.ToInt64(jso[key]);
                        break;
                    case "isactive":
                        _isActive = Convert.ToBoolean(jso[key]);
                        break;
                    case "isdefault":
                        _isDefault = Convert.ToBoolean(jso[key]);
                        break;
                    case "keyword":
                        Keyword = Convert.ToString(jso[key]);
                        break;
                    case "numberplanid":
                        NumberPlanId = Convert.ToInt64(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the alias 1 of this API MO keyword.
        /// </summary>
        public string Alias1 { get; set; }

        /// <summary>
        ///     Gets or sets the alias 2 of this API MO keyword.
        /// </summary>
        public string Alias2 { get; set; }

        /// <summary>
        ///     Gets or sets the alias 3 of this API MO keyword.
        /// </summary>
        public string Alias3 { get; set; }

        /// <summary>
        ///     Gets or sets the alias 4 of this API MO keyword.
        /// </summary>
        public string Alias4 { get; set; }

        /// <summary>
        ///     Gets or sets the alias 5 of this API MO keyword.
        /// </summary>
        public string Alias5 { get; set; }

        /// <summary>
        ///     Gets the ID of this API MO keyword.
        /// </summary>
        [JsonIgnore]
        public long Id
        {
            get { return _id; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this API MO keyword is active.
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this API MO keyword is default.
        /// </summary>
        public bool IsDefault
        {
            get { return _isDefault; }
            set { _isActive = value; }
        }

        /// <summary>
        ///     Gets or sets the keyword of this API MO keyword.
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        ///     Gets or sets the number plan ID of this API MO keyword.
        /// </summary>
        public long NumberPlanId { get; set; }
    }
}