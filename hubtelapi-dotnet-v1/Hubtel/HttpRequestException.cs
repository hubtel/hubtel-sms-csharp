using System;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Custom Exception
    /// </summary>
    public class HttpRequestException : Exception
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="e"></param>
        /// <param name="httpResponse"></param>
        public HttpRequestException(Exception e, HttpResponse httpResponse) : base(e.Message)
        {
            HttpResponse = httpResponse;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="e"></param>
        public HttpRequestException(Exception e) : base(e.Message) {}

        /// <summary>
        ///     Http Response
        /// </summary>
        public HttpResponse HttpResponse { private set; get; }
    }
}