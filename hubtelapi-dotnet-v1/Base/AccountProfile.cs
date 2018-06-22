using System;
using System.Globalization;

namespace Bict.Hubtel.Base
{
    /// <summary>
    ///     Represents an API account profile.
    /// </summary>
    public class AccountProfile
    {
        // Data fields.
        private readonly string _accountId;
        private readonly string _accountManager;
        private readonly long _accountNumber;
        private readonly string _accountStatus;
        private readonly decimal _balance;
        private readonly string _company;
        private readonly decimal _credit;
        private readonly string _emailAddress;
        private readonly DateTime? _lastAccessed;
        private readonly string _mobileNumber;
        private readonly int _numberOfServices;
        private readonly string _primaryContact;
        private readonly decimal _unpostedBalance;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccountProfile" /> class.
        /// </summary>
        public AccountProfile(ApiDictionary jso)
        {
            foreach (string key in jso.Keys) {
                switch (key.ToLower()) {
                    case "accountid":
                        _accountId = Convert.ToString(jso[key]);
                        break;
                    case "accountmanager":
                        _accountManager = Convert.ToString(jso[key]);
                        break;
                    case "accountnumber":
                        _accountNumber = Convert.ToInt64(jso[key]);
                        break;
                    case "accountstatus":
                        _accountStatus = Convert.ToString(jso[key]);
                        break;
                    case "balance":
                        _balance = Convert.ToDecimal(jso[key]);
                        break;
                    case "company":
                        _company = Convert.ToString(jso[key]);
                        break;
                    case "credit":
                        _credit = Convert.ToDecimal(jso[key]);
                        break;
                    case "emailaddress":
                        _emailAddress = Convert.ToString(jso[key]);
                        break;
                    case "lastaccessed":
                        DateTime lastAccessedDate;
                        if (jso[key].ToString() != "") {
                            _lastAccessed = DateTime.TryParseExact(jso[key].ToString(), "yyyy-dd-MM hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastAccessedDate)
                                ? lastAccessedDate
                                : (DateTime?) null;
                        }
                        break;
                    case "mobilenumber":
                        _mobileNumber = Convert.ToString(jso[key]);
                        break;
                    case "numberofservices":
                        _numberOfServices = Convert.ToInt32(jso[key]);
                        break;
                    case "primarycontact":
                        _primaryContact = Convert.ToString(jso[key]);
                        break;
                    case "unpostedbalance":
                        _unpostedBalance = Convert.ToDecimal(jso[key]);
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets the ID of this account profile.
        /// </summary>
        public string AccountId
        {
            get { return _accountId; }
        }

        /// <summary>
        ///     Gets the account manager of this account profile.
        /// </summary>
        public string AccountManager
        {
            get { return _accountManager; }
        }

        /// <summary>
        ///     Gets the account number of this account profile.
        /// </summary>
        public long AccountNumber
        {
            get { return _accountNumber; }
        }

        /// <summary>
        ///     Gets the account status of this account profile.
        /// </summary>
        public string AccountStatus
        {
            get { return _accountStatus; }
        }

        /// <summary>
        ///     Gets the balance of this account profile.
        /// </summary>
        public decimal Balance
        {
            get { return _balance; }
        }

        /// <summary>
        ///     Gets the company of this account profile.
        /// </summary>
        public string Company
        {
            get { return _company; }
        }

        /// <summary>
        ///     Gets the credit of this account profile.
        /// </summary>
        public decimal Credit
        {
            get { return _credit; }
        }

        /// <summary>
        ///     Gets the email address of this account profile.
        /// </summary>
        public string EmailAddress
        {
            get { return _emailAddress; }
        }

        /// <summary>
        ///     Gets the last accessed date of this account profile.
        /// </summary>
        public DateTime? LastAccessed
        {
            get { return _lastAccessed; }
        }

        /// <summary>
        ///     Gets the mobile number of this account profile.
        /// </summary>
        public string MobileNumber
        {
            get { return _mobileNumber; }
        }

        /// <summary>
        ///     Gets the number of services on this account profile.
        /// </summary>
        public int NumberOfServices
        {
            get { return _numberOfServices; }
        }

        /// <summary>
        ///     Gets the primary contact of this account profile.
        /// </summary>
        public string PrimaryContact
        {
            get { return _primaryContact; }
        }

        /// <summary>
        ///     Gets the unposted balance of this account profile.
        /// </summary>
        public decimal UnpostedBalance
        {
            get { return _unpostedBalance; }
        }
    }
}