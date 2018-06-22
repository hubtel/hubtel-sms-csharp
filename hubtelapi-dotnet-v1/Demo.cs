using System;
using System.Configuration;
using hubtelapi_dotnet_v1.Hubtel;
using hubtelapi_dotnet_v1.Payments;

namespace hubtelapi_dotnet_v1
{
    internal class Demo
    {
        private static void Main(string[] args)
        {
            //Edit these with actual values before tests 
            Config("ClientId", "ClientSecret", "MerchantNumber");

            

            try
            {

                var clientId = ConfigurationManager.AppSettings["ClientId"];
                var clientSecret = ConfigurationManager.AppSettings["ClientSecret"];
                var merchant = ConfigurationManager.AppSettings["MerchantNumber"];
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



                //  //Payment request example using receive payment class
                //var payments = new PaymentsApi(host);
                //var paymentResponse =
                //    payments.RequestPayment(new RecievePayment{ Amount = 0.1M ,Channel = "mtn-gh",ClientReference = "",
                //        CustomerEmail = "",CustomerMsisdn = "233241952532", Description = "Hire Purchase",CustomerName = "Duho Wise",PrimaryCallbackUrl = "http://requestb.in/1minotz1",
                //        SecondaryCallbackUrl = ""});
                //Console.WriteLine(paymentResponse.Data.Description);


                // Transaction Status Check
                //var payments = new PaymentsApi(host);
                //var statusResponse =
                //    payments.CheckPaymentStatus(new Transaction
                //    {
                //        HubtelTransactionId = "76dc69dea253404f9924c70a56e589c3"
                //    });
                // Console.WriteLine(statusResponse?.Data?.FirstOrDefault()?.TransactionStatus);



                //Online Checkout status 

                //var payments = new PaymentsApi(host);
                //var statusResponse =
                //    payments.OnlineCheckoutStatusV1("755b8f0979f34d44");
                //Console.WriteLine(statusResponse); //Online Checkout status 

                //var payments = new PaymentsApi(host);
                //var statusResponse =
                //    payments.OnlineCheckoutStatusV1("755b8f0979f34d44");
                //Console.WriteLine(statusResponse);


                var payments = new PaymentsApi(host);
                var statusResponse =
                    payments.OnlineCheckoutV1(new CreatedInvoice
                    {
                        Invoice = new Payments.Invoice
                        {
                            Description = "Insurance purchase",
                            TotalAmount = 0.01
                        },
                        Actions = new Actions
                        {
                            CancelUrl = "",
                            ReturnUrl = ""
                        },
                        Store = new Store
                        {
                            LogoUrl = "",
                            Name = "Store Ghana",
                            Phone = "0255899654",
                            PostalAddress = "SOme Address",
                            Tagline = "We make things happen",
                            WebsiteUrl = "",
                        },
                        CustomData = new object()

                    });
                Console.WriteLine(statusResponse.Description);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(HttpRequestException))
                {
                    var ex = e as HttpRequestException;
                    if (ex != null && ex.HttpResponse != null)
                    {
                        Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
                    }
                }

                Console.WriteLine(e);
                
            }

            Console.ReadKey();
        }

        private static void Config(string clientId, string clientSecret, string merchantNumber)
        {
            var config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);
            // set api keys clientid and secret
            config.AppSettings.Settings.Remove("ClientId");
            config.AppSettings.Settings.Add("ClientId",clientId);


            config.AppSettings.Settings.Remove("ClientSecret");
            config.AppSettings.Settings.Add("ClientSecret",clientSecret);


            config.AppSettings.Settings.Remove("MerchantNumber");
            config.AppSettings.Settings.Add("MerchantNumber", merchantNumber);

            //save new values
            config.Save(ConfigurationSaveMode.Modified,true);
            Console.WriteLine(ConfigurationManager.AppSettings["MerchantNumber"]);
            Console.WriteLine(ConfigurationManager.AppSettings["ClientSecret"]);
            Console.WriteLine(ConfigurationManager.AppSettings["ClientId"]);
        }
    }
}