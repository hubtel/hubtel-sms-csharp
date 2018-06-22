using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Content Media
    /// </summary>
    public class ContentMedia
    {
        private readonly string _accountId;
        private readonly Guid _id;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public ContentMedia() {}

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        /// <param name="jso"></param>
        public ContentMedia(ApiDictionary jso)
        {
            Tags = new List<Tag>();
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "id":
                        _id = new Guid(Convert.ToString(jso[key]));
                        break;
                    case "accountid":
                        _accountId = Convert.ToString(jso[key]);
                        break;
                    case "name":
                        Name = Convert.ToString(jso[key]);
                        break;
                    case "libraryid":
                        LibraryId = new Guid(Convert.ToString(jso[key]));
                        break;
                    case "locationpath":
                        LocationPath = Convert.ToString(jso[key]);
                        break;
                    case "tags":
                        var tags = jso[key] as IEnumerable;
                        if (tags != null)
                            foreach (JObject mo in tags) Tags.Add(new Tag(mo.ToObject<ApiDictionary>()));
                        break;
                    case "type":
                        Type = Convert.ToString(jso[key]);
                        break;
                    case "preference":
                        Preference = Convert.ToString(jso[key]);
                        break;
                    case "drmprotect":
                        DrmProtect = Convert.ToBoolean(jso[key]);
                        break;
                    case "encodingstatus":
                        EncodingStatus = Convert.ToString(jso[key]);
                        break;
                    case "streamable":
                        Streamable = Convert.ToBoolean(jso[key]);
                        break;
                    case "displaytext":
                        DisplayText = Convert.ToString(jso[key]);
                        break;
                    case "contenttext":
                        ContentText = Convert.ToString(jso[key]);
                        break;
                    case "approved":
                        Approved = Convert.ToBoolean(jso[key]);
                        break;
                    case "deleted":
                        Deleted = Convert.ToBoolean(jso[key]);
                        break;
                    case "datecreated":
                        if (jso[key].ToString() != "") {
                            DateTime dateCreated;
                            DateCreated = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated)
                                ? dateCreated
                                : (DateTime?) null;
                        }
                        break;
                    case "datemodified":
                        if (jso[key].ToString() != "") {
                            DateTime dateModified;
                            DateModified = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateModified)
                                ? dateModified
                                : (DateTime?) null;
                        }
                        break;
                    case "datedeleted":
                        if (jso[key].ToString() != "") {
                            DateTime dateDeleted;
                            DateDeleted = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateDeleted)
                                ? dateDeleted
                                : (DateTime?) null;
                        }
                        break;
                    case "callbackurl":
                        CallbackUrl = Convert.ToString(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Content Media ID
        /// </summary>
        [JsonIgnore]
        public Guid Id
        {
            get { return _id; }
        }

        /// <summary>
        ///     Account ID
        /// </summary>
        [JsonIgnore]
        public string AccountId
        {
            get { return _accountId; }
        }

        /// <summary>
        ///     Content Media Name
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        ///     Content Library ID
        /// </summary>
        public Guid LibraryId { set; get; }

        /// <summary>
        ///     Content Media Path
        /// </summary>
        public string LocationPath { set; get; }

        /// <summary>
        ///     Content Media Tags
        /// </summary>
        public List<Tag> Tags { set; get; }

        /// <summary>
        ///     Content Media Type
        /// </summary>
        public string Type { set; get; }

        /// <summary>
        ///     Content Media Preference
        /// </summary>
        public string Preference { set; get; }

        /// <summary>
        ///     Content Media DrmProtect
        /// </summary>
        public bool DrmProtect { set; get; }

        /// <summary>
        ///     Content Media Encoding Status
        /// </summary>
        public string EncodingStatus { set; get; }

        /// <summary>
        ///     Streamable
        /// </summary>
        public bool Streamable { set; get; }

        /// <summary>
        ///     DisplayText
        /// </summary>
        public string DisplayText { set; get; }

        /// <summary>
        ///     Content Text
        /// </summary>
        public string ContentText { set; get; }

        /// <summary>
        ///     Approved
        /// </summary>
        public bool Approved { set; get; }

        /// <summary>
        ///     Deleted
        /// </summary>
        public bool Deleted { set; get; }

        /// <summary>
        ///     Creation Date
        /// </summary>
        public DateTime? DateCreated { set; get; }

        /// <summary>
        ///     Modification Date
        /// </summary>
        public DateTime? DateModified { set; get; }

        /// <summary>
        ///     Deletion Date
        /// </summary>
        public DateTime? DateDeleted { set; get; }

        /// <summary>
        ///     Callback Url
        /// </summary>
        public string CallbackUrl { set; get; }
    }
}