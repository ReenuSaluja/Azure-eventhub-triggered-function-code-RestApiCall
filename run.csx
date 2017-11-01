#r "Microsoft.ServiceBus"

using System;
using Microsoft.ServiceBus.Messaging;
using System.Text;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Dynamic;
using System.Collections.Generic;

public static void Run(EventData myEventHubMessage, TraceWriter log)
{
    string data = Encoding.UTF8.GetString(myEventHubMessage.GetBytes());
    string URL = "URL"+data;

    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri(URL);

     HttpResponseMessage response = client.GetAsync(" ").Result;
    
    log.Info("sent REST call to Data Router");
    log.Info(response.ToString());
   
}