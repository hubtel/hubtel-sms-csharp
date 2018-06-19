using System;
using System.Configuration;
using System.Linq;
using hubtelapi_dotnet_v1.Hubtel;
using hubtelapi_dotnet_v1.Payments;

namespace hubtelapi_dotnet_v1
{
    internal class Demo
    {
        private static void Main(string[] args)
        {
            var clientId = ConfigurationManager.AppSettings["ClientId"];
            var clientSecret = ConfigurationManager.AppSettings["ClientSecret"];


            try {
                var host = new ApiHost(new BasicAuth(clientId, clientSecret));


                //Messaging Example
                //var messageApi = new MessagingApi(host);
                //MessageResponse msg = messageApi.SendQuickMessage("DevUniverse", "+233241952532", "Welcome to planet Hubtel!", true);
                //Console.WriteLine(msg.Status);       


                //  //Payment request example
                //var payments=  new PaymentsApi(host);
                //  var paymentResponse =
                //      payments.RequestPayment("233241952532", 0.1M, "Duho wise", "mtn-gh", "Hire Purchase", "http://requestb.in/1minotz1", "http://requestb.in/1minotz1");
                //  Console.WriteLine(paymentResponse.Data.Description);


                // Transaction Status Check
                //var payments = new PaymentsApi(host);
                //var statusResponse =
                //    payments.CheckPaymentStatus(new Transaction
                //    {
                //        HubtelTransactionId = "76dc69dea253404f9924c70a56e589c3"
                //    });
                // Console.WriteLine(statusResponse?.Data?.FirstOrDefault()?.TransactionStatus);

            }
            catch (Exception e) {
                if (e.GetType() == typeof (HttpRequestException)) {
                    var ex = e as HttpRequestException;
                    if (ex != null && ex.HttpResponse != null) {
                        Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
                    }
                }
                throw;
            }

            Console.ReadKey();
        }
    }
}