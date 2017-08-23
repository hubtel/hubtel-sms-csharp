SMSGH HTTP API .NET SDK (Release 2)
===================================

## **Overview**

The SMSGH HTTP API .NET SDK is a wrapper built to assist .Net-driven applications developers to interact in a more friendly way with the HTTP API.
Its goal is also to provide an easy way for those who do not have much knowledge about the whole HTTP Restful technology to interact with the HTTP API.
In that direction there is no need to go and grab a knowledge about HTTP and REST technology. 
All one needs is to have the basic knowledge about the Microsoft C# language. We mean the basics not advanced knowledge.

## **Notice**
* This is the source code for the current release.
* The source code of the previous release can be found [here](https://github.com/smsgh/smsghapi-csharp/tree/release-1).

## **Installation**

The SDK can smoothly run on any .Net Platform if it is compiled in the right environment. There are two ways of using the SDK

* Clone the repo and run it in Visual Studio
* Download the binaries from the **binaries** folder. The folder is organized around the various .Net Platform supported. Each folder contains the required dlls to use. Download the appropriate folder and add it to your project library path or reference path.
* You can also get it from [Nuget](https://www.nuget.org/packages/Smsgh.Api.Sdk/1.0.0).
 
## **Usage**

The SDK currently is organized around four main classes:

* *MessagingApi.cs* : 
    It handles sending and receiving messages, NumberPlans, Campaigns, Keywords, Sender IDs and Message Templates management.(For more information about these terms refer to [Our developer site](http://developers.smsgh.com/).)
* *ContactApi.cs* : 
        It handles all contacts related tasks. 
* *AccountApi.cs* : 
        It handles the API Account Holder data.
* *SupportApi.cs* : 
        It helps any developer to interact with our support platform via his application.
* *ContentApi.cs* :
		It handles all content related tasks.

## **Some Quick Start**

* **How to Send a Message**

```c#
    public class Demo
    {
        public static void Main(string[] args)
        {
            const string clientId = "user233";
            const string clientSecret = "password23";

            try {
                var host = new ApiHost(new BasicAuth(clientId, clientSecret));

                var messageApi = new MessagingApi(host);
                MessageResponse msg = messageApi.SendQuickMessage("Wazza", "+233244675897", "Hello Big Bro!", true);
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

```

* **How to Schedule a Message**

```c#
    public class Demo
    {
        public static void Main(string[] args)
        {
            const string clientId = "user233";
            const string clientSecret = "password23";

            try {
                var host = new ApiHost(new BasicAuth(clientId, clientSecret));

                // scheduling message from 4 days from now.
                Message message = new Message {
                    From = "wazza",
                    To = "+233246876456",
                    Content = "I am scheduling this message",
                    Time = DateTime.UtcNow.AddDays(4)
                };
                messageApi.SendMessage(message);

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

```
*Please do explore the MessagingApi class for more functionalities.*

* **How to view Account Details**

```c#
    public class Demo
    {
        public static void Main(string[] args)
        {
            const string clientId = "user233";
            const string clientSecret = "password23";

            try {
                var host = new ApiHost(new BasicAuth(clientId, clientSecret));
                var accountApi = new AccountApi(host);
                AccountProfile profile = accountApi.GetAccountProfile();
                Console.WriteLine("Profile Account Id {0}", profile.AccountId);
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

```

*Please do explore the AccountApi class for more functionalities.*


* **Notes**

The ContactApi, SupportApi and ContentApi classes follow almost the same pattern of functionalities, please do explore them to grab their capabilities.
The methods in those classes are self explanatory.
