using System.Collections.Generic;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Custom Dictionary
    /// </summary>
    public class ApiDictionary : Dictionary<string, object>
    {
        /// <summary>
        /// </summary>
        public ApiDictionary() : base(EqualityComparer<string>.Default) {}

        /// <summary>
        /// </summary>
        /// <param name="apiDictionary"></param>
        public ApiDictionary(ApiDictionary apiDictionary) : base(apiDictionary, EqualityComparer<string>.Default) {}
    }
}