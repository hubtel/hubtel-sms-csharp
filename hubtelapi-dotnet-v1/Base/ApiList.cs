using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Bict.Hubtel.Base
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
                    case "campaignlist":
                        var array = jso[key] as IEnumerable;
                        if (array != null) {
                            foreach (JObject o in array)
                                _items.Add((T) Convert.ChangeType(new Campaign(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                    case "libraries":
                        var os = jso[key] as IEnumerable;
                        if (os != null) {
                            foreach (JObject o in os)
                                _items.Add((T) Convert.ChangeType(new ContentLibrary(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                    case "contactlist":
                        var apiArray1 = jso[key] as IEnumerable;
                        if (apiArray1 != null) {
                            foreach (JObject o in apiArray1)
                                _items.Add((T) Convert.ChangeType(new Contact(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                    case "grouplist":
                        var array1 = jso[key] as IEnumerable;
                        if (array1 != null) {
                            foreach (JObject o in array1)
                                _items.Add((T) Convert.ChangeType(new ContactGroup(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;

                    case "invoicestatementlist":
                        var os1 = jso[key] as IEnumerable;
                        if (os1 != null) {
                            foreach (JObject o in os1)
                                _items.Add((T) Convert.ChangeType(new Invoice(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                    case "messages":
                        var apiArray2 = jso[key] as IEnumerable;
                        if (apiArray2 != null) {
                            foreach (JObject o in apiArray2)
                                _items.Add((T) Convert.ChangeType(new Message(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                    case "messagetemplatelist":
                        var array2 = jso[key] as IEnumerable;
                        if (array2 != null) {
                            foreach (JObject o in array2)
                                _items.Add((T) Convert.ChangeType(new MessageTemplate(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                    case "mokeywordlist":
                        var os2 = jso[key] as IEnumerable;
                        if (os2 != null) {
                            foreach (JObject o in os2)
                                _items.Add((T) Convert.ChangeType(new MoKeyWord(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                    case "numberplanlist":
                        var apiArray3 = jso[key] as IEnumerable;
                        if (apiArray3 != null) {
                            foreach (JObject o in apiArray3)
                                _items.Add((T) Convert.ChangeType(new NumberPlan(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                    case "senderaddresseslist":
                        var array3 = jso[key] as IEnumerable;
                        if (array3 != null) {
                            foreach (JObject o in array3)
                                _items.Add((T) Convert.ChangeType(new Sender(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                    case "ticketlist":
                        var array4 = jso[key] as IEnumerable;
                        if (array4 != null) {
                            foreach (JObject o in array4)
                                _items.Add((T) Convert.ChangeType(new Ticket(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                    case "servicelist":
                        var os3 = jso[key] as IEnumerable;
                        if (os3 != null) {
                            foreach (JObject o in os3) {
                                var d = o.ToObject<ApiDictionary>();
                                _items.Add((T) Convert.ChangeType(new Service(d), typeof (T)));
                            }
                        }
                        break;
                    case "folders":
                        var arr = jso[key] as IEnumerable;
                        if (arr != null) {
                            foreach (JObject o in arr)
                                _items.Add((T) Convert.ChangeType(new ContentFolder(o.ToObject<ApiDictionary>()), typeof (T)));
                        }
                        break;
                    case "medias":
                        var arr1 = jso[key] as IEnumerable;
                        if (arr1 != null) {
                            foreach (JObject o in arr1)
                                _items.Add((T) Convert.ChangeType(new ContentMedia(o.ToObject<ApiDictionary>()), typeof (T)));
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