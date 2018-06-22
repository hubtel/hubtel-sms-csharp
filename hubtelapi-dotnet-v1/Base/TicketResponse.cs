using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     TicketResponse
    /// </summary>
    public class TicketResponse
    {
        private readonly string _attachment;
        private readonly long _id;


        /// <summary>
        ///     default constructor
        /// </summary>
        public TicketResponse() {}

        /// <summary>
        ///     initializer
        /// </summary>
        /// <param name="json">Data dictionary</param>
        public TicketResponse(ApiDictionary json) : this()
        {
            foreach (string key in json.Keys) {
                switch (key.ToLower()) {
                    case "id":
                        _id = Convert.ToInt64(json[key]);
                        break;
                    case "time":
                        DateTime timeParsed;
                        if (json[key].ToString() != "")
                            Time = DateTime.TryParseExact(json[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeParsed)
                                ? timeParsed
                                : (DateTime?) null;
                        break;
                    case "content":
                        Content = Convert.ToString(json[key]);
                        break;
                    case "attachment":
                        _attachment = Convert.ToString(json[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Time
        /// </summary>
        [JsonIgnore]
        public DateTime? Time { get; private set; }

        /// <summary>
        ///     Response Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     Response Id
        /// </summary>
        [JsonIgnore]
        public long Id
        {
            get { return _id; }
        }

        /// <summary>
        ///     Response Attachment
        /// </summary>
        [JsonIgnore]
        public string Attachment
        {
            get { return _attachment; }
        }
    }
}