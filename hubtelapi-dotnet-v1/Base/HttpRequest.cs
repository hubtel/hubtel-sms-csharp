namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Http Request
    /// </summary>
    public abstract class HttpRequest
    {
        protected static string UrlEncoded = "application/x-www-form-urlencoded;charset=UTF-8";

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="path">Resource Path</param>
        /// <param name="parameters">Request parameter</param>
        protected HttpRequest(string path, ParameterMap parameters)
        {
            if (!path.IsEmpty()) Path = path;

            if (parameters != null) {
                string queryString = parameters.UrlEncode();
                Path += "?" + queryString;
            }
        }

        /// <summary>
        ///     Resource Path
        /// </summary>
        public string Path { set; get; } // avoid null in URL

        /// <summary>
        ///     HTTP Verb
        /// </summary>
        public string HttpMethod { set; get; }

        /// <summary>
        ///     Content Type
        /// </summary>
        public string ContentType { set; get; }

        /// <summary>
        ///     HTTP Content
        /// </summary>
        public byte[] Content { set; get; }
    }
}