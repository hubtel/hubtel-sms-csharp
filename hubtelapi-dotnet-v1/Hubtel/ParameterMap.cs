using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     This class represents the Http Request Parameters
    /// </summary>
    public class ParameterMap : Dictionary<string, string>
    {
        private readonly Dictionary<string, string> _map = new Dictionary<string, string>();

        /// <summary>
        ///     Clear map
        /// </summary>
        public new void Clear()
        {
            _map.Clear();
        }

        /// <summary>
        ///     Determines whether the map contains the given key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>true or false</returns>
        public new bool ContainsKey(string key)
        {
            return _map.ContainsKey(key);
        }

        /// <summary>
        ///     Determines whether the map contains the given value.
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>true or false</returns>
        public new bool ContainsValue(string value)
        {
            return _map.ContainsValue(value);
        }

        /// <summary>
        ///     Get the value of a given key
        /// </summary>
        /// <param name="key">the key</param>
        /// <returns>the value</returns>
        public string Get(string key)
        {
            return _map[key];
        }

        /// <summary>
        ///     Checks whether the map is empty or not.
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEmpty()
        {
            return _map.Count != 0;
        }

        /// <summary>
        ///     Get the keys collection of the map.
        /// </summary>
        /// <returns>Map key collections </returns>
        public KeyCollection KeySet()
        {
            return _map.Keys;
        }

        /// <summary>
        ///     Add a new item to the map
        /// </summary>
        /// <param name="key">the key</param>
        /// <param name="val">the value</param>
        public new void Add(string key, string val)
        {
            _map.Add(key, val);
        }

        /// <summary>
        ///     Remove an item from the map based upon the key.
        /// </summary>
        /// <param name="key">the key</param>
        /// <returns>true or false</returns>
        public new bool Remove(string key)
        {
            return _map.Remove(key);
        }

        /// <summary>
        ///     Returns the number of items in the map.
        /// </summary>
        /// <returns></returns>
        public new int Count()
        {
            return _map.Count;
        }

        /// <summary>
        ///     Returns the values collection of the map.
        /// </summary>
        /// <returns>the collection of the values in the map</returns>
        public new ValueCollection Values()
        {
            return _map.Values;
        }

        /// <summary>
        ///     Convenience method returns this class so multiple calls can be chained
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="val">Value </param>
        /// <returns>The map</returns>
        public ParameterMap Set(string key, string val)
        {
            _map.Add(key, val);
            return this;
        }

        /// <summary>
        ///     Returns URL encoded data
        /// </summary>
        /// <returns></returns>
        public string UrlEncode()
        {
            var sb = new StringBuilder();
            foreach (string key in _map.Keys) {
                if (sb.Length > 0) sb.Append("&");
                sb.Append(key);
                string val = _map[key];
                if (!val.IsEmpty()) {
                    sb.Append("=");
                    //sb.Append(WebUtility.UrlEncode(val));
                    sb.Append(HttpUtility.UrlEncode(val));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Convert the map to NameValueCollection <see cref="NameValueCollection" />
        /// </summary>
        /// <returns></returns>
        public NameValueCollection ToNameValueCollection()
        {
            var form = new NameValueCollection();
            foreach (string key in _map.Keys) {
                string val = _map[key];
                form[key] = val;
            }
            return form;
        }

        /// <summary>
        ///     Return a URL encoded byte array in UTF-8 charset.
        /// </summary>
        /// <returns></returns>
        public byte[] UrlEncodeBytes()
        {
            byte[] bytes = Encoding.UTF8.GetBytes(UrlEncode());
            return bytes;
        }
    }
}