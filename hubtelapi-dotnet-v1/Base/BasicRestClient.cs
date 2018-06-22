namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Implementation of the AbstractRestClient <see cref="AbstractRestClient" />.
    /// </summary>
    public class BasicRestClient : AbstractRestClient
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="logRequest">Log Request</param>
        public BasicRestClient(bool logRequest)
        {
            LogRequest = logRequest;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="baseUrl">Base Url</param>
        /// <param name="requestHandler">Http Request Handler <see cref="IRequestHandler" /></param>
        public BasicRestClient(string baseUrl, IRequestHandler requestHandler) : base(baseUrl, requestHandler)
        {
            LogRequest = true;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="baseUrl">Base Url</param>
        /// <param name="requestHandler">Http Request Handler</param>
        /// <param name="logRequest"></param>
        public BasicRestClient(string baseUrl, IRequestHandler requestHandler, bool logRequest) : base(baseUrl, requestHandler, new ConsoleRequestLogger(logRequest)) {}

        /// <summary>
        ///     Constructs the default client with baseUrl.
        /// </summary>
        /// <param name="baseUrl"></param>
        public BasicRestClient(string baseUrl) : base(baseUrl) {}

        /// <summary>
        ///     Constructs the default client with empty baseUrl.
        /// </summary>
        public BasicRestClient() : this("") {}

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="baseUrl">Base Url</param>
        /// <param name="logRequest">Log Request</param>
        public BasicRestClient(string baseUrl, bool logRequest) : this(baseUrl, new BasicRequestHandler(new ConsoleRequestLogger(logRequest))) {}

        /// <summary>
        ///     Log State variable
        /// </summary>
        public bool LogRequest { private set; get; }
    }
}