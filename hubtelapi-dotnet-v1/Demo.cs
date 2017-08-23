using System;
using hubtelapi_dotnet_v1.Hubtel;

namespace hubtelapi_dotnet_v1
{
    internal class Demo
    {
        private static void Main(string[] args)
        {
            const string clientId = "clientId";
            const string clientSecret = "clientSecret";


            try {
                var host = new ApiHost(new BasicAuth(clientId, clientSecret));
                var messageApi = new MessagingApi(host);
                MessageResponse msg = messageApi.SendQuickMessage("DevUniverse", "+233207110652", "Welcome to planet Hubtel!", true);
                Console.WriteLine(msg.Status);         
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