using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     ContentFolder
    /// </summary>
    public class ContentFolder
    {
        private readonly long _contentFolderId;
        private readonly long _contentMediaCount;
        private readonly List<ContentFolder> _folders;
        private readonly List<ContentMedia> _medias;
        private readonly long _subFolderCount;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public ContentFolder() {}

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        /// <param name="jso"></param>
        public ContentFolder(ApiDictionary jso)
        {
            _folders = new List<ContentFolder>();
            _medias = new List<ContentMedia>();
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "contentfolderid":
                        _contentFolderId = Convert.ToInt64(jso[key]);
                        break;
                    case "contentlibraryid":
                        ContentLibraryId = new Guid(Convert.ToString(jso[key]));
                        break;
                    case "foldername":
                        FolderName = Convert.ToString(jso[key]);
                        break;
                    case "absolutepath":
                        AbosultePath = Convert.ToString(jso[key]);
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
                    case "parentid":
                        ParentId = Convert.ToInt64(jso[key]);
                        break;
                    case "subfoldercount":
                        _subFolderCount = Convert.ToInt64(jso[key]);
                        break;
                    case "contentmediacount":
                        _contentMediaCount = Convert.ToInt64(jso[key]);
                        break;
                    case "subfolders":
                        var subfolders = jso[key] as IEnumerable;
                        if (subfolders != null)
                            foreach (JObject mo in subfolders) _folders.Add(new ContentFolder(mo.ToObject<ApiDictionary>()));
                        break;
                    case "contentmedias":
                        var medias = jso[key] as IEnumerable;
                        if (medias != null)
                            foreach (JObject mo in medias) _medias.Add(new ContentMedia(mo.ToObject<ApiDictionary>()));
                        break;
                }
            }
        }

        /// <summary>
        ///     Content Folder ID
        /// </summary>
        [JsonIgnore]
        public long ContentFolderId
        {
            get { return _contentFolderId; }
        }

        /// <summary>
        ///     Content Folders sub-folder count
        /// </summary>
        [JsonIgnore]
        public long SubFolderCount
        {
            get { return _subFolderCount; }
        }

        /// <summary>
        ///     Content Medias count
        /// </summary>
        [JsonIgnore]
        public long ContentMediaCount
        {
            get { return _contentMediaCount; }
        }

        /// <summary>
        ///     Content Folder list
        /// </summary>
        [JsonIgnore]
        public List<ContentFolder> Folders
        {
            get { return _folders; }
        }

        /// <summary>
        ///     Content Media List
        /// </summary>
        public List<ContentMedia> Medias
        {
            get { return _medias; }
        }

        /// <summary>
        ///     Content Library ID
        /// </summary>
        public Guid ContentLibraryId { set; get; }

        /// <summary>
        ///     Content Folder Name
        /// </summary>
        public string FolderName { set; get; }

        /// <summary>
        ///     Content Folder Absolute Path
        /// </summary>
        public string AbosultePath { set; get; }

        /// <summary>
        ///     Content Folder Id
        /// </summary>
        public long? ParentId { set; get; }

        /// <summary>
        ///     Content Folder Created Date
        /// </summary>
        public DateTime? DateCreated { set; get; }

        /// <summary>
        ///     Content Folder Modified Date
        /// </summary>
        public DateTime? DateModified { set; get; }
    }
}