using System;
using RabbitMQ.Client;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("demo-queue", durable: true,
                exclusive: false, autoDelete: false, arguments: null);

                var message = "Hello World";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", routingKey: "demo-queue", null, body);

                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }

}