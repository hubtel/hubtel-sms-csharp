using System;
using System.IO;
using System.Net;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Http Request Handler
    /// </summary>
    public class BasicRequestHandler : IRequestHandler
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="logger">The http request logger</param>
        public BasicRequestHandler(IRequestLogger logger)
        {
            Logger = logger;
        }

        /// <summary>
        ///     Default constructor
        /// </summary>
        public BasicRequestHandler() : this(new ConsoleRequestLogger(true)) {}

        /// <summary>
        ///     Request Logger
        /// </summary>
        protected IRequestLogger Logger { private set; get; }

        /// <summary>
        ///     Obtain an Http Url connection
        /// </summary>
        /// <param name="url">Url connection</param>
        /// <returns>
        ///     <see cref="HttpWebRequest" />
        /// </returns>
        /// <exception cref="WebException"></exception>
        public HttpWebRequest OpenConnection(string url)
        {
            var uri = new Uri(url);
            //HttpWebRequest urlConnection = WebRequest.CreateHttp(uri);
            var urlConnection = WebRequest.Create(uri) as HttpWebRequest;
            if (urlConnection == null) throw new WebException("Cannot Initialize the Http request");
            return urlConnection;
        }

        /// <summary>
        ///     Prepare an Http Url connection  for http requests.
        /// </summary>
        /// <param name="urlConnection">The Http Url connection</param>
        /// <param name="method">The Http Method</param>
        /// <param name="contentType">The Content Type</param>
        /// <param name="accept">The Accept Header</param>
        /// <param name="readWriteTimeout">The read timeout</param>
        /// <param name="connectionTimeout">The connection timeout</param>
        public void PrepareConnection(HttpWebRequest urlConnection, string method, string contentType, string accept, int readWriteTimeout, int connectionTimeout)
        {
            if (!contentType.IsEmpty()) urlConnection.ContentType = contentType.Trim();
            if (!accept.IsEmpty()) urlConnection.Accept = accept.Trim();
            urlConnection.KeepAlive = true;
            urlConnection.ReadWriteTimeout = readWriteTimeout*1000;
            urlConnection.Timeout = connectionTimeout*1000;
            urlConnection.Method = method;
            urlConnection.Headers.Add("Accept-Charset", "UTF-8");
        }

        /// <summary>
        ///     Write data onto a stream
        /// </summary>
        /// <param name="outputStream">The data stream <see cref="Stream" /></param>
        /// <param name="content">The actual data to write</param>
        public void WriteStream(Stream outputStream, byte[] content)
        {
            if (content != null
                && content.Length != 0)
                using (outputStream) outputStream.Write(content, 0, content.Length);
        }

        /// <summary>
        ///     Open an Http Url connection for data writing
        /// </summary>
        /// <param name="urlConnection">The Url connection <see cref="HttpWebRequest" /></param>
        /// <returns><see cref="Stream" /> an output stream.</returns>
        public Stream OpenOutput(HttpWebRequest urlConnection)
        {
            return urlConnection.GetRequestStream();
        }

        /// <summary>
        ///     Open an Http Url connection for data reading
        /// </summary>
        /// <param name="urlConnection">The Url connection <see cref="HttpWebRequest" /></param>
        /// <returns><see cref="Stream" /> an input stream.</returns>
        public Stream OpenInput(HttpWebRequest urlConnection)
        {
            return urlConnection.GetResponse().GetResponseStream();
        }

        /// <summary>
        ///     Raised in case of errors
        /// </summary>
        /// <param name="error">The error object <see cref="HttpRequestException" /></param>
        /// <returns>true or false</returns>
        public bool OnError(HttpRequestException error)
        {
            HttpResponse response = error.HttpResponse;
            if (Logger.IsLoggingEnabled()) {
                Logger.Log("BasicRequestHandler.onError got");
                Logger.Log(error.Message);
            }

            if (response != null) {
                int status = response.Status;
                if (status > 0) return true; // Perhaps a 404, 501, or something that will be fixed later
            }
            return false;
        }
    }

    //public void WriteStream(HttpWebRequest urlConnection, byte[] content)
    //{
    //    if(content != null && content.Length != 0) urlConnection.GetRequestStream().Write(content, 0, content.Length);
    //}
}