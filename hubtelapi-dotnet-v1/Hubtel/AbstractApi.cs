namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Abstract class that helps boostraps some of the work needed by the APIss
    /// </summary>
    public abstract class AbstractApi
    {
        protected static BasicRestClient RestClient;
        protected static ApiHost Host;

        /// <summary>
        /// </summary>
        /// <param name="host">
        ///     <see cref="ApiHost" />
        /// </param>
        protected AbstractApi(ApiHost host)
        {
            Host = host;
            string baseUrl = Host.SecuredConnection ? "https://" : "http://";
            baseUrl += Host.Hostname;

            if (Host.Port > 0) baseUrl += ":" + Host.Port;
            if (!Host.ContextPath.IsEmpty()) baseUrl += "/" + Host.ContextPath;

            RestClient = new BasicRestClient(baseUrl, Host.EnabledConsoleLog);

            // Add additional headers to process requests
            RestClient.RequestHeaders.Add("Authorization", Host.Auth.GetCredentials());
            RestClient.ConnectionTimeout = Host.Timeout;
            RestClient.ReadWriteTimeout = Host.Timeout;
        }
    }
}