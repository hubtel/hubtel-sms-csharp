// ***********************************************************************
// <copyright file="RequestData.cs" company="">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace hubtelapi_dotnet_v1.Payments
{
    /// <summary>
    /// Class Result.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        /// <value>The response code.</value>
        public string ResponseCode { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public Data Data { get; set; }
    }
}