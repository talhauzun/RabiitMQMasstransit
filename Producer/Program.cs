using MassTransit;
using Shared;
using System;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Producer
{
    public class Message : IMessage
    {
        public string Text { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            string rabbitMqUri = "rabbitmq://localhost";
            string queue = "test-queue";
            string userName = "guest";
            string password = "guest";

            var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(rabbitMqUri, configurator =>
                {
                    configurator.Username(userName);
                    configurator.Password(password);
                });
            });

            var sendToUri = new Uri($"{rabbitMqUri}/{queue}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            await Task.Run(async () =>
            {
                while (true)
                {
                    Console.Write("Mesaj yaz : ");
                    Message message = new Message
                    {
                        Text = Console.ReadLine()
                    };
                    if (message.Text.ToUpper() == "C")
                        break;
                    await endPoint.Send<IMessage>(message);
                    Console.WriteLine("");
                }
            });
        }
    }
}