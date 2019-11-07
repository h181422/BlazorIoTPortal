using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IoTPortal.UI.Server.Data;
using IoTPortal.Model;

namespace IoTPortal.Api.Service
{

    public class Bus
    {
        public string ServiceBusConnectionString = "Endpoint=sb://iotportal.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=VE/2Es9YHbIvDYyQKl8r6uXCuTTqEFFFwFf4pCwfQMY=";
        public string TopicName = "iottopic";
        public async void SendMessage(Device device)
        {
           
            TopicClient tc = new TopicClient(ServiceBusConnectionString, TopicName);
            dynamic data = new[]
            {
                new {name = "Einstein", firstName = "Albert", test = (string)device.Name},
                new {name = "Heisenberg", firstName = "Werner", test = "1"},
               
            };
            
            var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data[0])))
            {
                ContentType = "application/json",
                Label = "Scientist",
                MessageId = "1",
                TimeToLive = TimeSpan.FromMinutes(2)
            };
            //string messageBody = "foff";
            //var message = new Message(Encoding.UTF8.GetBytes(messageBody));
            System.Diagnostics.Debug.WriteLine("Sending" + device.Name);
            await tc.SendAsync(message);
            
            var app = new RecvBus();
            await app.ReceiveMessagesAsync();
        }
    }
}
