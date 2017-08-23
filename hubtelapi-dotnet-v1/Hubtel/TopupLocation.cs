using System;

namespace hubtelapi_dotnet_v1.Hubtel
{
    /// <summary>
    /// </summary>
    public class TopupLocation
    {
        /// <summary>
        /// </summary>
        public TopupLocation() {}

        /// <summary>
        /// </summary>
        /// <param name="dix"></param>
        public TopupLocation(ApiDictionary dix)
        {
            foreach (string key in dix.Keys) {
                switch (key.ToLower()) {
                    case "id":
                        Id = Convert.ToInt64(dix[key]);
                        break;
                    case "city":
                        City = Convert.ToString(dix[key]);
                        break;
                    case "area":
                        Area = Convert.ToString(dix[key]);
                        break;
                    case "region":
                        Region = Convert.ToString(dix[key]);
                        break;
                    case "details":
                        Details = Convert.ToString(dix[key]);
                        break;
                    case "description":
                        Description = Convert.ToString(dix[key]);
                        break;
                    case "latitude":
                        Latitude = Convert.ToDouble(dix[key]);
                        break;
                    case "longitude":
                        Longitute = Convert.ToDouble(dix[key]);
                        break;
                }
            }
        }

        /// <summary>
        /// </summary>
        public long Id { private set; get; }

        /// <summary>
        /// </summary>
        public string City { set; get; }

        /// <summary>
        /// </summary>
        public string Area { set; get; }

        /// <summary>
        /// </summary>
        public string Region { set; get; }

        /// <summary>
        /// </summary>
        public string Details { set; get; }

        /// <summary>
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// </summary>
        public double Latitude { set; get; }

        /// <summary>
        /// </summary>
        public double Longitute { set; get; }
    }
}