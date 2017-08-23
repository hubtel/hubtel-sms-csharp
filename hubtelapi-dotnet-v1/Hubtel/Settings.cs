// $Id: ApiSettings.cs 0 1970-01-01 00:00:00Z mkwayisi $

using System;
using Newtonsoft.Json;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    ///     Represents an API settings.
    /// </summary>
    public class Settings
    {
        // Data fields.
        private readonly string _accountId;

        /// <summary>
        ///     Used internally to initialize the properties of this class.
        /// </summary>
        public Settings(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "accountid":
                        _accountId = Convert.ToString(jso[key]);
                        break;
                    case "countrycode":
                        CountryCode = Convert.ToString(jso[key]);
                        break;
                    case "deliveryreportnotificationurl":
                        DeliveryReportNotificationUrl = Convert.ToString(jso[key]);
                        break;
                    case "emaildailysummary":
                        EmailDailySummary = Convert.ToBoolean(jso[key]);
                        break;
                    case "emailinvoicereminders":
                        EmailInvoiceReminders = Convert.ToBoolean(jso[key]);
                        break;
                    case "emailmaintenance":
                        EmailMaintenance = Convert.ToBoolean(jso[key]);
                        break;
                    case "emailnewinvoice":
                        EmailNewInvoice = Convert.ToBoolean(jso[key]);
                        break;
                    case "smsfortnightbalance":
                        SmsFortnightBalance = Convert.ToBoolean(jso[key]);
                        break;
                    case "smslowbalancenotification":
                        SmsLowBalanceNotification = Convert.ToBoolean(jso[key]);
                        break;
                    case "smsmaintenance":
                        SmsMaintenance = Convert.ToBoolean(jso[key]);
                        break;
                    case "smspromotionalmessages":
                        SmsPromotionalMessages = Convert.ToBoolean(jso[key]);
                        break;
                    case "smstopupnotification":
                        SmsTopUpNotification = Convert.ToBoolean(jso[key]);
                        break;
                    case "timezone":
                        TimeZone = Convert.ToString(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the account ID of this API settings.
        /// </summary>
        [JsonIgnore]
        public string AccountId
        {
            get { return _accountId; }
        }

        /// <summary>
        ///     Gets or sets the country code of this API settings.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        ///     Gets or sets the delivery report notification URL of this API settings.
        /// </summary>
        public string DeliveryReportNotificationUrl { get; set; }

        /// <summary>
        ///     Gets or sets the email daily summary of this API settings.
        /// </summary>
        public bool EmailDailySummary { get; set; }

        /// <summary>
        ///     Gets or sets the email invoice reminders of this API settings.
        /// </summary>
        public bool EmailInvoiceReminders { get; set; }

        /// <summary>
        ///     Gets or sets the email maintenance of this API settings.
        /// </summary>
        public bool EmailMaintenance { get; set; }

        /// <summary>
        ///     Gets or sets the email new invoice of this API settings.
        /// </summary>
        public bool EmailNewInvoice { get; set; }

        /// <summary>
        ///     Gets or sets the SMS fornight balance of this API settings.
        /// </summary>
        public bool SmsFortnightBalance { get; set; }

        /// <summary>
        ///     Gets or sets the SMS low balance notification of this API settings.
        /// </summary>
        public bool SmsLowBalanceNotification { get; set; }

        /// <summary>
        ///     Gets or sets the SMS maintenance of this API settings.
        /// </summary>
        public bool SmsMaintenance { get; set; }

        /// <summary>
        ///     Gets or sets the SMS promotional messages of this API settings.
        /// </summary>
        public bool SmsPromotionalMessages { get; set; }

        /// <summary>
        ///     Gets or sets the SMS top-up notification of this API settings.
        /// </summary>
        public bool SmsTopUpNotification { get; set; }

        /// <summary>
        ///     Gets or sets the time zone of this API settings.
        /// </summary>
        public string TimeZone { get; set; }
    }
}