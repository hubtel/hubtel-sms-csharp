using System;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Content Media extra data. It is a kind of key-value data structure
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// </summary>
        public Tag() {}

        /// <summary>
        /// </summary>
        /// <param name="jso"></param>
        public Tag(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "key":
                        Key = Convert.ToString(jso[key]);
                        break;
                    case "value":
                        Value = Convert.ToString(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     The key
        /// </summary>
        public string Key { set; get; }

        /// <summary>
        ///     The value
        /// </summary>
        public string Value { set; get; }
    }
}