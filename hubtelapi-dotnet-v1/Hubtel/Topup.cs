using System;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    /// </summary>
    public class Topup
    {
        /// <summary>
        /// </summary>
        public Topup() {}

        /// <summary>
        /// </summary>
        /// <param name="dix"></param>
        public Topup(ApiDictionary dix)
        {
            foreach (string key in dix.Keys) {
                switch (key.ToLower()) {
                    case "purchasedcredit":
                        PurchasedCredit = Convert.ToInt64(dix[key]);
                        break;
                    case "actualcredit":
                        ActualCredit = Convert.ToDouble(dix[key]);
                        break;
                }
            }
        }

        /// <summary>
        /// </summary>
        public long PurchasedCredit { set; get; }

        /// <summary>
        /// </summary>
        public double ActualCredit { set; get; }
    }
}