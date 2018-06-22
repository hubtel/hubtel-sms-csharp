using System;
using System.Collections.Generic;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     MediaInfo. Content Media Metadata class
    /// </summary>
    public class MediaInfo
    {
        /// <summary>
        ///     Content Name
        /// </summary>
        public string ContentName { set; get; }

        /// <summary>
        ///     Content Library Id
        /// </summary>
        public Guid LibraryId { set; get; }

        /// <summary>
        ///     Destination Folder
        /// </summary>
        public string DestinationFolder { set; get; }

        /// <summary>
        ///     Content Media Preference
        /// </summary>
        public string Preference { set; get; }

        /// <summary>
        ///     Content Media width. Image content
        /// </summary>
        public int Width { set; get; }

        /// <summary>
        ///     Content Media height. Image content
        /// </summary>
        public int Height { set; get; }

        /// <summary>
        ///     DRM Protection
        /// </summary>
        public bool DrmProtect { set; get; }

        /// <summary>
        ///     Content Media addtional data
        /// </summary>
        public Dictionary<string, string> Tags { set; get; }

        /// <summary>
        ///     Streamable. Audio and Video content
        /// </summary>
        public bool Streamable { set; get; }

        /// <summary>
        ///     Content Text. The actual content text.
        /// </summary>
        public string ContentText { set; get; }

        /// <summary>
        ///     Display Text. Short Message to show
        /// </summary>
        public string DisplayText { set; get; }
    }
}