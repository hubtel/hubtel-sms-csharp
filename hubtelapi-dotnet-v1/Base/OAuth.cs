using System;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     OAUTH wrapper
    /// </summary>
    public class OAuth : IAuth
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="bearerToken"></param>
        public OAuth(string bearerToken)
        {
            BearerToken = bearerToken;
        }

        /// <summary>
        ///     Bearer Token
        /// </summary>
        public string BearerToken { private set; get; }

        /// <summary>
        ///     Generate the HTTP Authorization header for OAuth authentication method.
        /// </summary>
        /// <returns></returns>
        public string GetCredentials()
        {
            string encoded = String.Format("Bearer {0}", BearerToken);
            return encoded;
        }
    }
}