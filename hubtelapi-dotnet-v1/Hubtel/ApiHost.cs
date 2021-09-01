namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Wrapper that sets API EndPoint.
    /// </summary>
    public class ApiHost
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl">Contact Hubtel support (tel:0307000577 or support@hubtel.com) for your base URL (e.g. https://sms-api.hubtel-test.com/v1)</param>
        public ApiHost(string baseUrl)
        {
            BaseUrl = baseUrl;
            Port = -1;
            ContextPath = "v1";
            Timeout = 5000;
            EnabledConsoleLog = true;
            SecuredConnection = true;
            Auth = null;
        }
         

      /// <summary>
      /// 
      /// </summary>
      /// <param name="auth"></param>
      /// <param name="baseUrl">Contact Hubtel support (tel:0307000577 or support@hubtel.com) for your base URL (e.g. https://sms-api.hubtel-test.com/v1)</param>
        public ApiHost(IAuth auth,string baseUrl) : this(baseUrl)
      {
          Auth = auth;
          
      }

        /// <summary>
        ///     The hostname
        /// </summary>
        public string BaseUrl { set; get; }

        /// <summary>
        ///     The Port
        /// </summary>
        public int Port { set; get; }

        /// <summary>
        ///     The context path
        /// </summary>
        public string ContextPath { set; get; }

        /// <summary>
        ///     The request timeout
        /// </summary>
        public int Timeout { set; get; }

        /// <summary>
        ///     Enable console log
        /// </summary>
        public bool EnabledConsoleLog { set; get; }

        /// <summary>
        ///     Http Authorization header
        /// </summary>
        public IAuth Auth { set; get; }

        /// <summary>
        ///     HTTPs or not
        /// </summary>
        public bool SecuredConnection { set; get; }
    }
}