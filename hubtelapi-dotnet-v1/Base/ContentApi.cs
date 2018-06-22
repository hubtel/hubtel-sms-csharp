using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     The content API. Please refer to http://developers.smsgh.com for further information on how to set
    ///     some parameters
    /// </summary>
    /// <remarks>
    ///     All Exceptions thrown in this class contains the actual message of what has happened. Just by reading the
    ///     error message helps the developer to fix the issue.
    /// </remarks>
    public class ContentApi : AbstractApi
    {
        /// <summary>
        ///     Default constructor. Use this constructor whenever this class is going to be referenced.
        /// </summary>
        /// <param name="host"><see cref="ApiHost" /> The Api Host object.</param>
        public ContentApi(ApiHost host) : base(host) {}

        /// <summary>
        ///     Fetches a paginated list of content libraries related to a particular account.
        /// </summary>
        /// <param name="page">The Page Number</param>
        /// <param name="pageSize">The Number of items on a page</param>
        /// <returns>
        ///     Custom List of <see cref="ContentLibrary" />.
        ///     <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message. </exception>
        public ApiList<ContentLibrary> GetContentLibraries(uint page, uint pageSize)
        {
            const string resource = "/libraries/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0
                && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<ContentLibrary>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Fetches all the content libraries related to a particular account.
        /// </summary>
        /// <returns>
        ///     Custom List of <see cref="ContentLibrary" />.
        ///     <seealso cref="ApiList{T}" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message. </exception>
        public ApiList<ContentLibrary> GetContentLibraries()
        {
            return GetContentLibraries(0, 0);
        }

        /// <summary>
        ///     Fetches the metadata of a content library.
        /// </summary>
        /// <param name="libraryId">Content Library Id</param>
        /// <returns>
        ///     <see cref="ContentLibrary" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ContentLibrary GetContentLibrary(Guid libraryId)
        {
            string resource = "/libraries/";
            resource += libraryId.ToString().Replace("-", "");
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ContentLibrary(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get a content library based upon the id.
        /// </summary>
        /// <param name="libraryId">The content library Id</param>
        /// <returns>
        ///     <see cref="ContentLibrary" />
        /// </returns>
        /// <exception cref="HttpRequestException"></exception>
        public ContentLibrary GetContentLibrary(string libraryId)
        {
            if (!libraryId.IsGuid()) throw new HttpRequestException(new Exception("libraryId must not be null and be a valid UUID"));
            return GetContentLibrary(new Guid(libraryId));
        }

        /// <summary>
        ///     Creates a new content library and returns the created content metadata.
        /// </summary>
        /// <param name="library">Content Library object to create</param>
        /// <returns>
        ///     <see cref="ContentLibrary" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ContentLibrary AddContentLibrary(ContentLibrary library)
        {
            const string resource = "/libraries/";
            const string contentType = "application/json";
            if (library == null) throw new HttpRequestException(new Exception("Parameter 'library' cannot be null"));
            var stringWriter = new StringWriter();
            new JsonSerializer().Serialize(stringWriter, library);

            HttpResponse response = RestClient.Post(resource, contentType, Encoding.UTF8.GetBytes(stringWriter.ToString()));
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new ContentLibrary(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Creates a new content library and returns the created content metadata.
        /// </summary>
        /// <param name="name">Content Library Name</param>
        /// <param name="shortName">Content Library ShortName</param>
        /// <returns>
        ///     <see cref="ContentLibrary" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ContentLibrary AddContentLibrary(string name, string shortName)
        {
            const string resource = "/libraries/";
            if (name == null
                || name.IsEmpty()
                || shortName == null
                || shortName.IsEmpty()) throw new Exception("Parameter 'name' and 'shortName' cannot be null.");
            if (!name.IsValidFileName(true)
                || !shortName.IsValidFileName(true)) throw new Exception("Parameter 'name' and 'shortName' must be valid folder name.");
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("Name", name).Set("ShortName", shortName);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new ContentLibrary(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Creates a new content library and returns the created content metadata.
        /// </summary>
        /// <param name="parameterMap">
        ///     The Content Library data. The required parameters to set are Name and ShortName with their
        ///     respective values. <see cref="ParameterMap" />
        /// </param>
        /// <example>
        ///     How to set Parameter: ParameterMap parameterMap = RestClient.NewParams(parameterMap.Set("Name",
        ///     "Wallpapers").Set("ShortName", "Wallpapers");
        /// </example>
        /// <returns>
        ///     <see cref="ContentLibrary" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ContentLibrary AddContentLibrary(ParameterMap parameterMap)
        {
            const string resource = "/libraries/";
            if (parameterMap == null) throw new Exception("Parameter 'parameterMap' cannot be null");
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new ContentLibrary(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates the metadata of a given library and returns the updated library.
        /// </summary>
        /// <param name="libraryId">The content library Id</param>
        /// <param name="parameterMap">
        ///     The Content Library data. The required parameters to set are Name and ShortName with their
        ///     respective values.<see cref="ParameterMap" />
        /// </param>
        /// <example>
        ///     How to set Parameter: ParameterMap parameterMap = RestClient.NewParams(parameterMap.Set("Name",
        ///     "Wallpapers").Set("ShortName", "Wallpapers");
        /// </example>
        /// <returns>
        ///     <see cref="ContentLibrary" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ContentLibrary UpdateContentLibrary(Guid libraryId, ParameterMap parameterMap)
        {
            string resource = "/libraries/";
            if (parameterMap == null) throw new Exception("Parameter 'parameterMap' cannot be null");
            resource += libraryId.ToString().Replace("-", "");
            HttpResponse response = RestClient.Put(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ContentLibrary(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates the metadata of a given library and returns the updated library.
        /// </summary>
        /// <param name="libraryId">The content library Id</param>
        /// <param name="parameterMap">
        ///     The Content Library data. A key-value pair data structure <see cref="ParameterMap" />
        /// </param>
        /// <returns>
        ///     <see cref="ContentLibrary" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ContentLibrary UpdateContentLibrary(string libraryId, ParameterMap parameterMap)
        {
            if (!libraryId.IsGuid()) throw new Exception("libraryId must not be null and be a valid UUID");
            if (parameterMap == null) throw new Exception("Parameter 'parameterMap' cannot be null");
            return UpdateContentLibrary(new Guid(libraryId), parameterMap);
        }

        /// <summary>
        ///     Updates the metadata of a given library and returns the updated library.
        /// </summary>
        /// <param name="libraryId">The Content Library Id</param>
        /// <param name="name">The Library Name</param>
        /// <param name="shortName">The Library ShortName</param>
        /// <returns>
        ///     <see cref="ContentLibrary" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ContentLibrary UpdateContentLibrary(Guid libraryId, string name = null, string shortName = null)
        {
            string resource = "/libraries/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (name != null
                && !name.IsEmpty()) {
                if (!name.IsValidFileName(true)) throw new Exception("Parameter 'name' and 'shortName' must be valid folder name.");
                parameterMap.Set("Name", name);
            }

            if (shortName != null
                && !shortName.IsEmpty()) {
                if (!shortName.IsValidFileName(true)) throw new Exception("Parameter 'name' and 'shortName' must be valid folder name.");
                parameterMap.Set("ShortName", shortName);
            }
            resource += libraryId.ToString().Replace("-", "");
            HttpResponse response = RestClient.Put(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ContentLibrary(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates the metadata of a given library and returns the updated library.
        /// </summary>
        /// <param name="libraryId">The content library Id</param>
        /// <param name="name">The library name</param>
        /// <param name="shortName">The library short name</param>
        /// <returns>
        ///     <see cref="ContentLibrary" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ContentLibrary UpdateContentLibrary(string libraryId, string name = null, string shortName = null)
        {
            if (!libraryId.IsGuid()) throw new Exception("libraryId must not be null and be a valid UUID");
            return UpdateContentLibrary(new Guid(libraryId), name, shortName);
        }

        /// <summary>
        ///     Deletes a content library  and returns true when successful.
        /// </summary>
        /// <param name="libraryId">The content library Id</param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool DeleteContentLibrary(Guid libraryId)
        {
            string resource = "/libraries/";
            resource += libraryId.ToString().Replace("-", "");
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Deletes a content library.
        /// </summary>
        /// <param name="libraryId">The content library Id</param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool DeleteContentLibrary(string libraryId)
        {
            string resource = "/libraries/";
            if (!libraryId.IsGuid()) throw new Exception("libraryId must not be null and be a valid UUID");
            resource += libraryId.Replace("-", "");
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Fetches a paginated list of Content Folders for a given account.
        /// </summary>
        /// <param name="page">The page number</param>
        /// <param name="pageSize">The Number of item per page</param>
        /// <returns>Custom List of <see cref="ContentFolder" /> <seealso cref="ApiList{T}" /> </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ApiList<ContentFolder> GetContentFolders(uint page, uint pageSize)
        {
            const string resource = "/folders/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));

            if (page == 0
                && pageSize == 0) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<ContentFolder>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Fecthes the list of all content folders for a given account.
        /// </summary>
        /// <returns>>Custom List of <see cref="ContentFolder" /> <seealso cref="ApiList{T}" /> </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ApiList<ContentFolder> GetContentFolders()
        {
            return GetContentFolders(0, 0);
        }

        /// <summary>
        ///     Fecthes the details of a content folder including content medias and sub folders attached to that content folder.
        /// </summary>
        /// <param name="folderId">The Content Folder Id</param>
        /// <returns>
        ///     <see cref="ContentFolder" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ContentFolder GetContentFolder(ulong folderId)
        {
            string resource = "/folders/" + folderId;
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ContentFolder(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Creates a new content folder and returns the created folder.
        /// </summary>
        /// <param name="folderName">The folder name</param>
        /// <param name="libraryId">The Content library Id</param>
        /// <param name="parentFolder">The parent folder Id or Name if it is a sub folder</param>
        /// <returns>
        ///     <see cref="ContentFolder" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ContentFolder AddContentFolder(string folderName, Guid libraryId, string parentFolder = null)
        {
            const string resource = "/folders/";
            if (folderName == null
                || (folderName != null && folderName.IsEmpty())) throw new Exception("Parameter 'folderName' cannot be null.");
            if (folderName != null
                && !folderName.IsValidFileName(true)) throw new Exception("Parameter 'folderName' must be valid folder name.");

            if (parentFolder != null
                && !parentFolder.IsEmpty()) {
                if (!parentFolder.IsNumeric()
                    && !parentFolder.IsValidFileName(true)) throw new Exception("Parameter 'parentFolder' must be valid folder name.");
            }

            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("FolderName", folderName).Set("LibraryId", libraryId.ToString()).Set("Parent", parentFolder);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new ContentFolder(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Create a new content folder.
        /// </summary>
        /// <param name="folderName">The folder name</param>
        /// <param name="libraryId">The content library Id</param>
        /// <param name="parentFolder">The parent folder name</param>
        /// <returns>
        ///     <see cref="ContentFolder" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ContentFolder AddContentFolder(string folderName, String libraryId, string parentFolder = null)
        {
            const string resource = "/folders/";
            if (folderName == null) throw new Exception("Parameter 'folderName' cannot be null.");
            if (folderName != null
                && !folderName.IsValidFileName(true)) throw new Exception("Parameter 'folderName' must be valid folder name.");

            if (libraryId == null) throw new Exception("Parameter 'libaryId' cannot be null.");
            if (!libraryId.IsGuid()) throw new Exception("Parameter 'libaryId' must be a valid UUID.");

            if (parentFolder != null
                && !parentFolder.IsEmpty()) {
                if (!parentFolder.IsNumeric()
                    && !parentFolder.IsValidFileName(true)) throw new Exception("Parameter 'parentFolder' must be valid folder name.");
            }

            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("FolderName", folderName).Set("LibraryId", libraryId).Set("Parent", parentFolder);
            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new ContentFolder(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }


        /// <summary>
        ///     Updates a content folder
        /// </summary>
        /// <param name="folderId">The content folder id</param>
        /// <param name="folderName">Folder name</param>
        /// <param name="libraryId">Library Id</param>
        /// <param name="parentFolder">Parent folder Id or Name</param>
        /// <returns>
        ///     <see cref="ContentFolder" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ContentFolder UpdateContentFolder(ulong folderId, string folderName = null, Guid? libraryId = null, string parentFolder = null)
        {
            string resource = "/folders/" + folderId;
            if (folderName != null
                && folderName.IsEmpty()) throw new Exception("Parameter 'folderName' cannot be null.");
            if (folderName != null
                && !folderName.IsValidFileName(true)) throw new Exception("Parameter 'folderName' must be valid folder name.");

            if (parentFolder != null
                && !parentFolder.IsEmpty()) {
                if (!parentFolder.IsNumeric()
                    && !parentFolder.IsValidFileName(true)) throw new Exception("Parameter 'parentFolder' must be valid folder name.");
            }

            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("FolderName", folderName).Set("LibraryId", libraryId.ToString()).Set("Parent", parentFolder);
            HttpResponse response = RestClient.Put(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ContentFolder(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Deletes a content folder and returns true when successful
        /// </summary>
        /// <param name="folderId">The content folder id</param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool DeleteContentFolder(ulong folderId)
        {
            string resource = "/folders/" + folderId;
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Fetches a paginated list of content medias
        /// </summary>
        /// <param name="page">The page number</param>
        /// <param name="pageSize">The number of items on a page</param>
        /// <param name="filters">Query filters</param>
        /// <returns>Custom List of <see cref="ContentMedia" /> <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate nessage.</exception>
        public ApiList<ContentMedia> GetContentMedias(uint page, uint pageSize, Dictionary<string, string> filters = null)
        {
            const string resource = "/media/";
            ParameterMap parameterMap = RestClient.NewParams();
            if (page > 0) parameterMap.Set("Page", Convert.ToString(page));
            if (pageSize > 0) parameterMap.Set("PageSize", Convert.ToString(pageSize));
            if (filters != null
                && filters.Count > 0) foreach (var filter in filters) parameterMap.Set(filter.Key, filter.Value);

            if (page == 0
                && pageSize == 0
                && filters == null) parameterMap = null;
            HttpResponse response = RestClient.Get(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ApiList<ContentMedia>(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Fetches the list of all content medias
        /// </summary>
        /// <returns>Custom List of <see cref="ContentMedia" /> <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate nessage.</exception>
        public ApiList<ContentMedia> GetContentMedias()
        {
            return GetContentMedias(0, 0);
        }

        /// <summary>
        ///     Fetches the list of all content medias based upon some filters
        /// </summary>
        /// <param name="filters">Filters</param>
        /// <returns>Custom List of <see cref="ContentMedia" /> <seealso cref="ApiList{T}" /></returns>
        /// <exception cref="Exception">Exception with the appropriate nessage.</exception>
        public ApiList<ContentMedia> GetContentMedias(Dictionary<string, string> filters)
        {
            return GetContentMedias(0, 0, filters);
        }

        /// <summary>
        ///     Retrieves a given content media.
        /// </summary>
        /// <param name="contentMediaId">The Content Media Id</param>
        /// <returns>
        ///     <see cref="ContentMedia" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate nessage.</exception>
        public ContentMedia GetContentMedia(Guid contentMediaId)
        {
            string resource = "/media/";
            resource += contentMediaId.ToString().Replace("-", "");
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ContentMedia(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Get a content media
        /// </summary>
        /// <param name="contentMediaId">The content media Id</param>
        /// <returns>
        ///     <see cref="ContentMedia" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ContentMedia GetContentMedia(string contentMediaId)
        {
            string resource = "/media/";
            if (!contentMediaId.IsGuid()) throw new Exception("contentMediaId must not be null and be a valid UUID");
            resource += contentMediaId.Replace("-", "");
            HttpResponse response = RestClient.Get(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ContentMedia(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Upload a new content media file with content media metadata
        /// </summary>
        /// <param name="filePath">Content Media file</param>
        /// <param name="mediaInfo">Content Media Info</param>
        /// <returns>
        ///     <see cref="ContentMedia" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ContentMedia AddContentMedia(string filePath, MediaInfo mediaInfo)
        {
            const string resource = "/media/";
            if (mediaInfo == null) throw new Exception("Parameter 'mediaInfo' cannot be null.");
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("ContentName", mediaInfo.ContentName)
                .Set("LibraryId", mediaInfo.LibraryId.ToString())
                .Set("DestinationFolder", mediaInfo.DestinationFolder ?? string.Empty)
                .Set("Preference", mediaInfo.Preference)
                .Set("Width", Convert.ToString(mediaInfo.Width))
                .Set("Height", Convert.ToString(mediaInfo.Height))
                .Set("DrmProtect", mediaInfo.DrmProtect ? "true" : "false")
                .Set("Streamable", mediaInfo.Streamable ? "true" : "false")
                .Set("DisplayText", mediaInfo.DisplayText ?? string.Empty)
                .Set("ContentText", mediaInfo.ContentText ?? string.Empty)
                .Set("Tags", mediaInfo.Tags != null && mediaInfo.Tags.Count > 0 ? JsonConvert.SerializeObject(mediaInfo.Tags) : string.Empty);

            // Let us build the upload file
            var mediaFile = new UploadFile(filePath, "MediaFile", FileExtensionMimeTypeMapping.GetMimeType(Path.GetExtension(filePath)));
            UploadFile[] files = {mediaFile};
            HttpResponse response = RestClient.PostFiles(resource, files, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new ContentMedia(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Add a content media
        /// </summary>
        /// <param name="mediaInfo">The content media data <see cref="MediaInfo" /></param>
        /// <returns>
        ///     <see cref="ContentMedia" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public ContentMedia AddContentMedia(MediaInfo mediaInfo)
        {
            const string resource = "/media/";
            if (mediaInfo == null) throw new Exception("Parameter 'mediaRequest' cannot be null.");
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("ContentName", mediaInfo.ContentName)
                .Set("LibraryId", mediaInfo.LibraryId.ToString())
                .Set("DestinationFolder", mediaInfo.DestinationFolder ?? string.Empty)
                .Set("Preference", mediaInfo.Preference)
                .Set("ContentText", mediaInfo.ContentText ?? string.Empty)
                .Set("DisplayText", mediaInfo.DisplayText ?? string.Empty)
                .Set("Tags", mediaInfo.Tags != null && mediaInfo.Tags.Count > 0 ? JsonConvert.SerializeObject(mediaInfo.Tags) : string.Empty);

            HttpResponse response = RestClient.Post(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.Created)) return new ContentMedia(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Deletes a content media and returns true when successful.
        /// </summary>
        /// <param name="contentMediaId">The Content Media Id</param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool DeleteContentMedia(Guid contentMediaId)
        {
            string resource = "/media/";
            resource += contentMediaId.ToString().Replace("-", "");
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Deletes a content media and returns true when successful.
        /// </summary>
        /// <param name="contentMediaId">The Content Media Id</param>
        /// <returns>true when successful</returns>
        /// <exception cref="Exception">Exception with the appropriate message</exception>
        public bool DeleteContentMedia(string contentMediaId)
        {
            string resource = "/media/";
            if (!contentMediaId.IsGuid()) throw new Exception("contentMediaId must not be null and be a valid UUID");
            resource += contentMediaId.Replace("-", "");
            HttpResponse response = RestClient.Delete(resource);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.NoContent)) return true;
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates an existing content media and returns the updated content media
        /// </summary>
        /// <param name="contentMediaId">The Content Media ID</param>
        /// <param name="mediaInfo">Content Media Info <see cref="MediaInfo" /></param>
        /// <returns>
        ///     <see cref="ContentMedia" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ContentMedia UpdateContentMedia(Guid contentMediaId, MediaInfo mediaInfo)
        {
            string resource = "/media/";
            resource += contentMediaId.ToString().Replace("-", "");
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("ContentName", mediaInfo.ContentName)
                .Set("LibraryId", mediaInfo.LibraryId.ToString())
                .Set("DestinationFolder", mediaInfo.DestinationFolder ?? string.Empty)
                .Set("Preference", mediaInfo.Preference)
                .Set("ContentText", mediaInfo.ContentText ?? string.Empty)
                .Set("DisplayText", mediaInfo.DisplayText ?? string.Empty)
                .Set("DrmProtect", mediaInfo.DrmProtect ? "true" : "false")
                .Set("Tags", mediaInfo.Tags != null && mediaInfo.Tags.Count > 0 ? JsonConvert.SerializeObject(mediaInfo.Tags) : string.Empty);
            HttpResponse response = RestClient.Put(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ContentMedia(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }

        /// <summary>
        ///     Updates an existing content media and returns the updated content media
        /// </summary>
        /// <param name="contentMediaId">The Content Media ID</param>
        /// <param name="mediaInfo">Content Media Info <see cref="MediaInfo" /></param>
        /// <returns>
        ///     <see cref="ContentMedia" />
        /// </returns>
        /// <exception cref="Exception">Exception with the appropriate message.</exception>
        public ContentMedia UpdateContentMedia(string contentMediaId, MediaInfo mediaInfo)
        {
            string resource = "/media/";
            if (!contentMediaId.IsGuid()) throw new HttpRequestException(new Exception("contentMediaId must not be null and be a valid UUID"));
            resource += contentMediaId.Replace("-", "");
            ParameterMap parameterMap = RestClient.NewParams();
            parameterMap.Set("ContentName", mediaInfo.ContentName)
                .Set("LibraryId", mediaInfo.LibraryId.ToString())
                .Set("DestinationFolder", mediaInfo.DestinationFolder ?? string.Empty)
                .Set("Preference", mediaInfo.Preference)
                .Set("ContentText", mediaInfo.ContentText ?? string.Empty)
                .Set("DisplayText", mediaInfo.DisplayText ?? string.Empty)
                .Set("DrmProtect", mediaInfo.DrmProtect ? "true" : "false")
                .Set("Tags", mediaInfo.Tags != null && mediaInfo.Tags.Count > 0 ? JsonConvert.SerializeObject(mediaInfo.Tags) : string.Empty);
            HttpResponse response = RestClient.Put(resource, parameterMap);
            if (response == null) throw new Exception("Request Failed. Unable to get server response");
            if (response.Status == Convert.ToInt32(HttpStatusCode.OK)) return new ContentMedia(JsonConvert.DeserializeObject<ApiDictionary>(response.GetBodyAsString()));
            string errorMessage = String.Format("Status Code={0}, Message={1}", response.Status, response.GetBodyAsString());
            throw new Exception("Request Failed : " + errorMessage);
        }
    }
}