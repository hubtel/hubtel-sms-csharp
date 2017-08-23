using System;
using System.Net;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Http Response Wrapper
    /// </summary>
    public class HttpResponse
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="urlConnection">Http Url connection</param>
        /// <param name="body">Response raw body</param>
        public HttpResponse(HttpWebRequest urlConnection, byte[] body)
        {
            using (var response = urlConnection.GetResponse() as HttpWebResponse) {
                if (response != null) Status = Convert.ToInt32(response.StatusCode);
                Url = urlConnection.Address.AbsoluteUri;
                Headers = urlConnection.Headers;
                Body = body;
            }
        }


        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="headers">Http headers</param>
        /// <param name="status">Response status code</param>
        /// <param name="body">Response raw body</param>
        public HttpResponse(string url, WebHeaderCollection headers, int status, byte[] body)
        {
            Url = url;
            Headers = headers;
            Status = status;
            Body = body;
        }

        /// <summary>
        ///     Response Status code
        /// </summary>
        public int Status { private set; get; }

        /// <summary>
        ///     Url
        /// </summary>
        public string Url { private set; get; }

        /// <summary>
        ///     Http Response headers
        /// </summary>
        public WebHeaderCollection Headers { private set; get; }

        /// <summary>
        ///     Raw Http Response
        /// </summary>
        public byte[] Body { private set; get; }

        /// <summary>
        ///     Returns the Body as UTF-8 string
        /// </summary>
        /// <returns></returns>
        public string GetBodyAsString()
        {
            if (Body != null) return Body.GetString();
            return string.Empty;
        }

        public static implicit operator System.Web.HttpResponse(HttpResponse v)
        {
            throw new NotImplementedException();
        }
    }
}