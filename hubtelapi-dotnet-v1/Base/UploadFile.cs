// http://aspnetupload.com
// Copyright © 2009 Krystalware, Inc.
//
// This work is licensed under a Creative Commons Attribution-Share Alike 3.0 United States License
// http://creativecommons.org/licenses/by-sa/3.0/us/

using System.IO;

namespace Bict.Hubtel.Base
{
    /// <summary>
    /// </summary>
    public class UploadFile
    {
        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fieldName"></param>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        public UploadFile(Stream data, string fieldName, string fileName, string contentType)
        {
            Data = data;
            FieldName = fieldName;
            FileName = fileName;
            ContentType = contentType;
        }

        /// <summary>
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fieldName"></param>
        /// <param name="contentType"></param>
        public UploadFile(string fileName, string fieldName, string contentType) : this(File.OpenRead(fileName), fieldName, Path.GetFileName(fileName), contentType) {}

        /// <summary>
        /// </summary>
        /// <param name="fileName"></param>
        public UploadFile(string fileName) : this(fileName, null, "application/octet-stream") {}

        /// <summary>
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fieldName"></param>
        public UploadFile(string fileName, string fieldName) : this(fileName, fieldName, "application/octet-stream") {}

        /// <summary>
        /// </summary>
        public Stream Data { get; set; }

        /// <summary>
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// </summary>
        public string ContentType { get; set; }
    }
}