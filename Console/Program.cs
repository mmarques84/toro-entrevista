using Business;
using Domain;
using Messaging;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var posicaoCliente = new CustodiaRepo().GetById(1);
            var json = JsonConvert.SerializeObject(posicaoCliente);
            System.Console.WriteLine($"POSIÇÃO INICIAL");
            System.Console.WriteLine($"{json}");

            var calculoService = new CalculoService();
            RabbitMQService rabbitMQService = null;

            try
            {
                rabbitMQService = new RabbitMQService();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Erro ao inicializar RabbitMQService: " + ex.Message);
                return;
            }

            var bo = new OrquestradorDeCalculo(calculoService, rabbitMQService); // Passando a instância de RabbitMQService
            await bo.Comprar(1, "PETR3", 2);

            System.Console.WriteLine("End!");
            System.Console.ReadLine();
        }
    }
}
