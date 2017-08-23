using System;
using System.IO;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Content Media File
    /// </summary>
    public class ContentMediaFile
    {
        private readonly string _fileExtension;
        private readonly string _fileLocalName;
        private readonly string _streamType;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public ContentMediaFile() {}

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="mediaType">File media Type</param>
        /// <param name="fileContent">File content</param>
        public ContentMediaFile(string fileName, string mediaType, byte[] fileContent)
        {
            FileName = fileName;

            _fileExtension = Path.GetExtension(fileName);
            _fileLocalName = string.Format("{0}{1}", Guid.NewGuid(), FileExtension);
            MediaType = mediaType;
            FileContent = fileContent;
            _streamType = mediaType == null ? null : mediaType.Split('/')[0];
        }

        /// <summary>
        ///     FileName
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        ///     ContentFile Mime Type
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        ///     FileContent
        /// </summary>
        public byte[] FileContent { get; set; }

        /// <summary>
        ///     File Extension
        /// </summary>
        public string FileExtension
        {
            get { return _fileExtension; }
        }

        /// <summary>
        ///     File Local Name
        /// </summary>
        public string FileLocalName
        {
            get { return _fileLocalName; }
        }

        /// <summary>
        ///     File Stream Type
        /// </summary>
        public string StreamType
        {
            get { return _streamType; }
        }
    }
}