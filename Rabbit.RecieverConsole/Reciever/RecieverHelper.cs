using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reciever
{
    public class RecieverHelper
    {
        public void Recieve()
        {
            try
            {
                // var factory = ConexFactory();
                var factory = new ConnectionFactory() { HostName = "10.0.0.10", Password = "Dan11Cy1", UserName = "danieli" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "task_queue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);

                        int dots = message.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);


                    };
                    channel.BasicConsume(queue: "task_queue",
                                         noAck: true,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
            catch(RabbitMQ.Client.Exceptions.BrokerUnreachableException bEx)
            {
                Console.WriteLine(" failed to recieve " + bEx.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(" failed to recieve " + ex.Message);
            }
          


        }

        ConnectionFactory ConexFactory()
        {
            ConnectionFactory factory = new ConnectionFactory();
            //factory.UserName = "Danieli";
            //factory.Password = "Dan11Cy1";
            //factory.HostName = ConfigurationManager.AppSettings["RabbitServer"];
            //return factory;
            factory.UserName = "sigal";
            factory.Password = "sigal";
            //factory.VirtualHost = "/";
           // factory.Protocol = Protocols.DefaultProtocol;
            factory.HostName = ConfigurationManager.AppSettings["RabbitServer"];
           // factory.Port = AmqpTcpEndpoint.DefaultAmqpSslPort;
           
            return factory;

           // IConnection conn = factory.CreateConnection();
        }

    }
}
