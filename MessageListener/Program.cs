using MassTransit;
using Shared;
using System;
using System.Threading.Tasks;

namespace MessageListener
{
    public class Message : IMessage
    {
        public string Text { get; set; }
    }
    public class MessageReceivedConsumer : IConsumer<IMessageReceived>
    {
        public async Task Consume(ConsumeContext<IMessageReceived> context)
            => Console.WriteLine($"test-queue-3 Gelen mesaj : {context.Message.OrderDate}");
    }
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
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

                factory.ReceiveEndpoint(queue, endpoint =>
                {
                   endpoint.Consumer<MessageReceivedConsumer>();
                });
            });
            await bus.StartAsync();
            Console.ReadLine();
            await bus.StopAsync();
        }
    }
}
