using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                QueueProducer.Publish(channel);
            }
        }
    }
}