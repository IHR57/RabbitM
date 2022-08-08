using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    public static class QueueProducer
    {
        public static void Publish(IModel channel)
        {
            channel.QueueDeclare(
                queue: "demo-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var count = 0;
            while (true)
            {
                var message = $"Hello World: {count}";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "demo-queue", null, body);
                count++;
                Thread.Sleep(1000);
            }

        }
    }
}