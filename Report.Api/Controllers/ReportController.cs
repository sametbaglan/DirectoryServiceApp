using Directory.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace Report.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReportController : BaseCustomController
    {
        [HttpGet]
        public IActionResult GetReportByLocationsss()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://cstibavg:3OZD6aHrJzXJIAgcXZi5v6gkA3PWw45W@whale.rmq.cloudamqp.com/cstibavg");
            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "Directory",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);



            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
               
            };
            channel.BasicConsume(queue: "Directory",
                autoAck: true,
                consumer: consumer);
            BasicDeliverEventArgs s = new BasicDeliverEventArgs();
            channel.BasicConsume("Directory", true, consumer);
            return Ok();

        }
    }
}

