﻿namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Wrapper that sets API EndPoint.
    /// </summary>
    public class ApiHost
    {
        /// <summary>
        ///     ApiHost
        /// </summary>
        public ApiHost()
        {
            Hostname = "api.hubtel.com";
            Port = -1;
            ContextPath = "v1";
            Timeout = 5000;
            EnabledConsoleLog = true;
            SecuredConnection = true;
            Auth = null;
        }

        public ApiHost(string hostname, int port, string contextPath, int timeout, bool enabledConsoleLog, IAuth auth, bool securedConnection)
        {
            Hostname = hostname;
            Port = port;
            ContextPath = contextPath;
            Timeout = timeout;
            EnabledConsoleLog = enabledConsoleLog;
            Auth = auth;
            SecuredConnection = securedConnection;
        }

        /// <summary>
        /// </summary>
        /// <param name="auth"></param>
        public ApiHost(IAuth auth) : this()
        {
            Auth = auth;
        }

        /// <summary>
        ///     The hostname
        /// </summary>
        public string Hostname { set; get; }

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