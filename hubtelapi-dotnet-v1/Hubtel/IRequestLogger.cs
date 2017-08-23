using System.Net;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     IRequestLogger
    /// </summary>
    public interface IRequestLogger
    {
        /// <summary>
        ///     State whether logging is enabed or not
        /// </summary>
        /// <returns></returns>
        bool IsLoggingEnabled();

        /// <summary>
        ///     Log the HTTP message onto the console
        /// </summary>
        /// <param name="mesg"></param>
        void Log(string mesg);

        /// <summary>
        ///     Log the HTTP request and content to be sent with the request.
        /// </summary>
        /// <param name="urlConnection">an open HttpWebRequest url connection</param>
        /// <param name="content">Content to log</param>
        void LogRequest(HttpWebRequest urlConnection, object content);

        /// <summary>
        ///     Logs the HTTP response.
        /// </summary>
        void LogResponse(HttpResponse response);
    }
}