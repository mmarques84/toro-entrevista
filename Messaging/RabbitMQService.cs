using RabbitMQ.Client;
using System.Text;
using System;
using RabbitMQ.Client.Events;
using System.Linq;

namespace Messaging
{
    public class RabbitMQService
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService()
        {
            try
            {
                _factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    Port = 5672,
                    UserName = "guest", // Substitua pelo seu nome de usuário
                    Password = "guest"   // Substitua pela sua senha
                };
                _connection = _factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.QueueDeclare(queue: "notificacaoQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inicializar RabbitMQ: " + ex.Message);
                throw;
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                var body = Encoding.UTF8.GetBytes(message);
                _channel.BasicPublish(exchange: "",
                                     routingKey: "notificacaoQueue",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Enviado {0}", message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao enviar mensagem: " + ex.Message);
            }
        }
        public void ConsumeMessages()
        {
            System.Console.WriteLine($"--------------------------------");
            System.Console.WriteLine($"Mensagem gravadas no RabbitMQ");
            System.Console.WriteLine($"--------------------------------");
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };


            _channel.BasicConsume(queue: "notificacaoQueue",
                                 autoAck: true,  
                                 consumer: consumer);
        }
        public void Close()
        {
            try
            {
                _channel.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao fechar conexões: " + ex.Message);
            }
        }
    }
}