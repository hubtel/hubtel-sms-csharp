using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Support Ticket
    /// </summary>
    public class Ticket
    {
        private readonly string _accountId;
        private readonly string _assignedTo;
        private readonly string _attachment;
        private readonly int _id;
        private readonly DateTime? _lastUpdated;
        private readonly int? _rating;
        private readonly string _recipients;
        private readonly List<TicketResponse> _responses;
        private readonly int? _supporStatusId;
        private readonly DateTime? _timeAdded;
        private readonly DateTime? _timeAssigned;
        private readonly DateTime? _timeClosed;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public Ticket() {}

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="jso"></param>
        public Ticket(ApiDictionary jso)
        {
            _responses = new List<TicketResponse>();
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "id":
                        _id = Convert.ToInt32(jso[key]);
                        break;
                    case "accountid":
                        _accountId = Convert.ToString(jso[key]);
                        break;
                    case "assignedto":
                        _assignedTo = Convert.ToString(jso[key]);
                        break;
                    case "supportdepartmentid":
                        SupportDepartmentId = Convert.ToInt32(jso[key]);
                        break;
                    case "supportcategoryid":
                        SupportCategoryId = Convert.ToInt32(jso[key]);
                        break;
                    case "supportstatusid":
                        _supporStatusId = Convert.ToInt32(jso[key]);
                        break;
                    case "priority":
                        Priority = Convert.ToInt32(jso[key]);
                        break;
                    case "source":
                        Source = Convert.ToString(jso[key]);
                        break;
                    case "recipients":
                        _recipients = Convert.ToString(jso[key]);
                        break;
                    case "timeadded":

                        if (jso[key].ToString() != "") {
                            DateTime timeParsed;
                            _timeAdded = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeParsed)
                                ? timeParsed
                                : (DateTime?) null;
                        }
                        break;
                    case "timeclosed":

                        if (jso[key].ToString() != "") {
                            DateTime timeParsed;
                            _timeClosed = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeParsed)
                                ? timeParsed
                                : (DateTime?) null;
                        }
                        break;
                    case "timeassigned":

                        if (jso[key].ToString() != "") {
                            DateTime timeParsed;
                            _timeAssigned = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeParsed)
                                ? timeParsed
                                : (DateTime?) null;
                        }
                        break;
                    case "lastupdated":

                        if (jso[key].ToString() != "") {
                            DateTime timeParsed;
                            _lastUpdated = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeParsed)
                                ? timeParsed
                                : (DateTime?) null;
                        }
                        break;
                    case "subject":
                        Subject = Convert.ToString(jso[key]);
                        break;
                    case "content":
                        Content = Convert.ToString(jso[key]);
                        break;
                    case "attachment":
                        _attachment = Convert.ToString(jso[key]);
                        break;
                    case "rating":
                        _rating = Convert.ToInt32(jso[key]);
                        break;
                    case "responses":
                        var os = jso[key] as IEnumerable;
                        if (os != null) {
                            foreach (JObject o in os)
                                _responses.Add(new TicketResponse(o.ToObject<ApiDictionary>()));
                        }
                        break;
                }
            }
        }

        [JsonIgnore]
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        ///     Account Id
        /// </summary>
        [JsonIgnore]
        public string AccountId
        {
            get { return _accountId; }
        }

        /// <summary>
        ///     Department Id
        /// </summary>
        public int? SupportDepartmentId { get; set; }

        /// <summary>
        ///     Category Id
        /// </summary>
        public int? SupportCategoryId { get; set; }

        /// <summary>
        ///     Status Id
        /// </summary>
        [JsonIgnore]
        public int? SupportStatusId
        {
            get { return _supporStatusId; }
        }

        /// <summary>
        ///     Priority
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        ///     Source
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        ///     Recipients
        /// </summary>
        [JsonIgnore]
        public string Recipients
        {
            get { return _recipients; }
        }

        /// <summary>
        ///     Added Time
        /// </summary>
        [JsonIgnore]
        public DateTime? TimeAdded
        {
            get { return _timeAdded; }
        }

        /// <summary>
        ///     Closed Time
        /// </summary>
        [JsonIgnore]
        public DateTime? TimeClosed
        {
            get { return _timeClosed; }
        }

        /// <summary>
        ///     Assigned Time
        /// </summary>
        [JsonIgnore]
        public DateTime? TimeAssigned
        {
            get { return _timeAssigned; }
        }

        /// <summary>
        ///     Update Time
        /// </summary>
        [JsonIgnore]
        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
        }

        /// <summary>
        ///     Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        ///     Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     Attachment
        /// </summary>
        [JsonIgnore]
        public string Attachment
        {
            get { return _attachment; }
        }

        /// <summary>
        ///     Assignee
        /// </summary>
        [JsonIgnore]
        public string AssignedTo
        {
            get { return _assignedTo; }
        }

        /// <summary>
        ///     Rating
        /// </summary>
        [JsonIgnore]
        public int? Rating
        {
            get { return _rating; }
        }

        /// <summary>
        ///     Response
        /// </summary>
        [JsonIgnore]
        public List<TicketResponse> Responses
        {
            get { return _responses; }
        }
    }
}