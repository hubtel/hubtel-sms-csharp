using System;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Custom Api Exception
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of this API exception class.
        /// </summary>
        public ApiException(string message) : base(message)
        {
            HttpStatusCode = 400;
            Reason = string.Empty;
            Description = string.Empty;
            RawBody = string.Empty;
        }

        /// <summary>
        ///     The HTTP Status code
        /// </summary>
        public int HttpStatusCode { set; get; }

        /// <summary>
        ///     The Exception reason
        /// </summary>
        public string Reason { set; get; }

        /// <summary>
        ///     The description
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        ///     The Http raw error response
        /// </summary>
        public string RawBody { set; get; }
    }
}