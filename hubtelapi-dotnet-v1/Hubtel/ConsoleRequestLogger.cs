using System;
using System.Net;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Console Http Request Logger. It is a logging framework to log whatever is sent to the server and whatever it is
    ///     received as response
    /// </summary>
    public class ConsoleRequestLogger : IRequestLogger
    {
        private readonly bool _loggingEnabled;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="logging">States whether logging is enabled or not.</param>
        public ConsoleRequestLogger(bool logging)
        {
            _loggingEnabled = logging;
        }

        /// <summary>
        ///     Returns the logging state.
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsLoggingEnabled()
        {
            return _loggingEnabled;
        }

        /// <summary>
        ///     Logs message to the console
        /// </summary>
        /// <param name="mesg">message to log</param>
        public void Log(string mesg)
        {
            Console.WriteLine(mesg);
        }

        /// <summary>
        ///     Log Http Request
        /// </summary>
        /// <param name="urlConnection">Http Url connection</param>
        /// <param name="content">Http Content</param>
        public void LogRequest(HttpWebRequest urlConnection, object content)
        {
            Log("=== HTTP Request ===");
            Log(String.Format("{0}  {1}", urlConnection.Method, urlConnection.Address));
            if (content is string) Log("Content: " + content);
            LogHeaders(urlConnection.Headers);
        }

        /// <summary>
        ///     Log Http Response
        /// </summary>
        /// <param name="response">Http Response</param>
        public void LogResponse(HttpResponse response)
        {
            if (response != null) {
                Log("=== HTTP Response ===");
                Log("Receive url: " + response.Url);
                Log("Status: " + response.Status);
                LogHeaders(response.Headers);
                Log("Content:\n" + response.GetBodyAsString());
            }
        }

        /// <summary>
        ///     Log Http Request Headers
        /// </summary>
        /// <param name="headers">Http Request Headers</param>
        protected void LogHeaders(WebHeaderCollection headers)
        {
            if (headers != null) {
                foreach (string key in headers.AllKeys) {
                    string values = headers[key];
                    Log(key + ":" + values);
                }
            }
        }
    }
}