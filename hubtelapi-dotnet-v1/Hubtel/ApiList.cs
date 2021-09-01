using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Represents an API list.
    /// </summary>
    public class ApiList<T>
    {
        // Data fields.
        private readonly long _count;
        private readonly List<T> _items;
        private readonly long _totalPages;

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        public ApiList(ApiDictionary jso)
        {
            _items = new List<T>();
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "count":
                        _count = Convert.ToInt64(jso[key]);
                        break;
                    case "totalpages":
                        _totalPages = Convert.ToInt64(jso[key]);
                        break;
                    case "actionlist":
                        var apiArray = jso[key] as IEnumerable;
                        if (apiArray != null) {
                            foreach (JObject o in apiArray)
                                _items.Add((T) Convert.ChangeType(new Action(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                   

                 
                    case "messages":
                        var apiArray2 = jso[key] as IEnumerable;
                        if (apiArray2 != null) {
                            foreach (JObject o in apiArray2)
                                _items.Add((T) Convert.ChangeType(new Message(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                  
                   
                }
            }
        }

        /// <summary>
        ///     Gets the count of this API list.
        /// </summary>
        public long Count
        {
            get { return _count; }
        }

        /// <summary>
        ///     Gets the total pages of this API list.
        /// </summary>
        public long TotalPages
        {
            get { return _totalPages; }
        }

        /// <summary>
        ///     Gets the items in this API list.
        /// </summary>
        public List<T> Items
        {
            get { return _items; }
        }

        /// <summary>
        ///     Returns the enumerator of this API list.
        /// </summary>
        public List<T>.Enumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}