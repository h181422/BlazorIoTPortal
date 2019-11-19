using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;

namespace Logic.ServiceBus
{
    public class RecvBus
    {
        const string ServiceBusConnectionString = "Endpoint=sb://iotportal.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=VE/2Es9YHbIvDYyQKl8r6uXCuTTqEFFFwFf4pCwfQMY=";
        const string TopicName = "iottopic";
        const string SubscriptionName = "blazorSub";


        public async Task ReceiveMessagesAsync()
        {
            var cts = new CancellationTokenSource();
            var allReceives = Task.WhenAll(
                this.ReceiveMessagesAsync(ServiceBusConnectionString, TopicName, SubscriptionName, cts.Token, ConsoleColor.Cyan));
            var receiver = new SubscriptionClient(ServiceBusConnectionString, TopicName, SubscriptionName);

            await Task.WhenAll(
                Task.WhenAny(

                    Task.Delay(TimeSpan.FromMilliseconds(5000))
                ).ContinueWith((t) => cts.Cancel()),
                allReceives);

        }
        async Task ReceiveMessagesAsync(string connectionString, string topicName, string subscriptionName, CancellationToken cancellationToken, ConsoleColor color)
        {
            // var subscriptionPath = SubscriptionClient.FormatSubscriptionPath(topicName, subscriptionName);
            //var receiver = new MessageReceiver(connectionString,subscriptionPath, ReceiveMode.PeekLock);

            var receiver = new SubscriptionClient(connectionString, topicName, subscriptionName);

            System.Diagnostics.Debug.WriteLine("output1");
            var doneReceiving = new TaskCompletionSource<bool>();
            // close the receiver and factory when the CancellationToken fires 
            cancellationToken.Register(
                async () =>
                {
                    await receiver.CloseAsync();
                    doneReceiving.SetResult(true);
                });
            System.Diagnostics.Debug.WriteLine("output2");
            // register the RegisterMessageHandler callback
            receiver.RegisterMessageHandler(
                async (message, cancellationToken) =>
                {

                    if (message.Label != null &&
                        message.ContentType != null &&
                        message.Label.Equals("Scientist", StringComparison.InvariantCultureIgnoreCase) &&
                        message.ContentType.Equals("application/json", StringComparison.InvariantCultureIgnoreCase))

                    {
                        var body = message.Body;

                        dynamic scientist = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(body));

                        string name = scientist.test;
                     
                       

                        await receiver.CompleteAsync(message.SystemProperties.LockToken);
                    }
                    else
                    {
                        await receiver.DeadLetterAsync(message.SystemProperties.LockToken);//, "ProcessingError", "Don't know what to do with this message");
                    }
                },
                new MessageHandlerOptions((e) => LogMessageHandlerException(e)) { AutoComplete = false, MaxConcurrentCalls = 1 });

            await doneReceiving.Task;
        }

        private Task LogMessageHandlerException(ExceptionReceivedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Exception: \"{0}\" {0}", e.Exception.Message, e.ExceptionReceivedContext.EntityPath);
            return Task.CompletedTask;
        }
    }
}