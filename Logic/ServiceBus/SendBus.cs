using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IoTPortal.Model;

namespace Logic.ServiceBus
{

    public class SendBus
    {
        public string ServiceBusConnectionString = "Endpoint=sb://iotportal.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=VE/2Es9YHbIvDYyQKl8r6uXCuTTqEFFFwFf4pCwfQMY=";
        public string TopicName = "iottopic";
        public async void SendMessage(Register reg)
        {

            TopicClient tc = new TopicClient(ServiceBusConnectionString, TopicName);
            dynamic data = new[]
            {
                new {devName = (string)reg.Dev.Name, userName = (string)reg.User.Username, email = (string)reg.User.Email},
               

            };

            var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data[0])))
            {
                ContentType = "application/json",
                Label = "Device",
                MessageId = "1",
                TimeToLive = TimeSpan.FromMinutes(2)
            };
          
         
            await tc.SendAsync(message);

            //var app = new RecvBus();
            //await app.ReceiveMessagesAsync();
        }
    }
}