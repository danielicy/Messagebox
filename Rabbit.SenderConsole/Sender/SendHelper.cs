using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    public class SendHelper
    {
        public void SendMessage(string msg)
        {

            var factory = new ConnectionFactory() { HostName = "10.0.0.10", Password = "Dan11Cy1", UserName = "danieli" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);


                var properties = channel.CreateBasicProperties();

                properties.Persistent = true;


                string message = msg;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "task_queue",
                                     basicProperties: properties,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();



        }
    }
}
