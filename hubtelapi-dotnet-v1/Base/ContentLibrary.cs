using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Content Library
    /// </summary>
    public class ContentLibrary
    {
        /// <summary>
        ///     Unity Account Id attached to the Library
        /// </summary>
        private readonly string _accountId;

        private readonly long _folderId;

        /// <summary>
        ///     Library Id
        /// </summary>
        private readonly Guid _libraryId;

        /// <summary>
        ///     Default Constructor
        /// </summary>
        public ContentLibrary() {}

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        /// <param name="jso"></param>
        public ContentLibrary(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "libraryid":
                        _libraryId = new Guid(Convert.ToString(jso[key]));
                        break;
                    case "accountid":
                        _accountId = Convert.ToString(jso[key]);
                        break;
                    case "name":
                        Name = Convert.ToString(jso[key]);
                        break;
                    case "shortname":
                        ShortName = Convert.ToString(jso[key]);
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
                    case "folderid":
                        _folderId = Convert.ToInt64(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Library Name
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        ///     Library Short Name
        /// </summary>
        public string ShortName { set; get; }

        /// <summary>
        ///     Gets or sets the created date of this Library.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        ///     Gets or sets the modification date of the Library
        /// </summary>
        public DateTime? DateModified { get; set; }

        /// <summary>
        ///     Library ID
        /// </summary>
        [JsonIgnore]
        public Guid LibraryId
        {
            get { return _libraryId; }
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
        ///     Folder ID
        /// </summary>
        [JsonIgnore]
        public long FolderId
        {
            get { return _folderId; }
        }
    }
}