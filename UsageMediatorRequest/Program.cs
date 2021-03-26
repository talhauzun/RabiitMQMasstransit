using MassTransit;
using MassTransit.Mediator;
using System;
using UsageMediatorConsumer;

namespace UsageMediatorRequest
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            IMediator mediator = Bus.Factory.CreateMediator(cfg =>
            {
               // cfg.Consumer<SubmitOrderConsumer>();
                cfg.Consumer<OrderStatusConsumer>();
            });

            Guid orderId = NewId.NextGuid();

           // await mediator.Send<SubmitOrder>(new { OrderId = orderId });

            var client = mediator.CreateRequestClient<GetOrderStatus>();

            var response = await client.GetResponse<OrderStatus>(new { OrderId = orderId });

            Console.WriteLine("Order Status: {0}", response.Message.Status);
        }
    }

    class SubmitOrder
    {
        public Guid OrderId { get; set; }
    }
    
}
