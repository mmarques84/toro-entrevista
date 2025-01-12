using Domain;
using Messaging;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class OrquestradorDeCalculo
    {
        private readonly RabbitMQService _rabbitMQService;
        private readonly ICalculoService _calculoService;
        public OrquestradorDeCalculo(ICalculoService calculoService, RabbitMQService rabbitMQService)
        {
            _calculoService = calculoService;
            _rabbitMQService = rabbitMQService;
        }

        public async Task Comprar(int cliente, string ticker, int qdte)
        {
            try
            {
                //mudanca de Marcus marques
                //criei os services
                //CalculoServices
                //criei um servidor de mensageiria RabbitMQ


                _calculoService.CalcularFinanceiro(cliente, ticker, qdte);
                _calculoService.CalcularCustodia(cliente, ticker, qdte);


                var posicaoCliente = new CustodiaRepo().GetById(cliente);
                await NotificarCliente(posicaoCliente);
                await NotificarToro(posicaoCliente);
                //consumir as msg no rabitmq
                _rabbitMQService.ConsumeMessages();
            }
            catch (Exception ex)
            {
                Monitoramento(ex);
            }
        }

        //private void CalculoFinanceiro(int cliente, string ticker, int qdte)
        //{
        //    var entidade = new CustodiaRepo().GetById(cliente);
        //    var ativo = entidade.Custodia.FirstOrDefault(o => o.Ticker == ticker);
        //    var vlCompra = ativo.CotacaoHoje * qdte;

        //    entidade.Financeiro -= vlCompra;
        //}

        //private void CalculoCustodia(int cliente, string ticker, int qdte)
        //{
        //    var entidade = new CustodiaRepo().GetById(cliente);
        //    var ativo = entidade.Custodia.FirstOrDefault(o => o.Ticker == ticker);
        //    ativo.Quantidade += qdte;
        //}

        private void Monitoramento(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        private async Task NotificarCliente(PosicaoConsolidada posicaoConsolidada)
        {
            var json = JsonConvert.SerializeObject(posicaoConsolidada);
            _rabbitMQService.SendMessage($"Notificação CLIENTE: {json}");
            Console.WriteLine();
            Console.WriteLine("Notificação CLIENTE");
            Console.WriteLine($"{json}");
        }

        private async Task NotificarToro(PosicaoConsolidada posicaoConsolidada)
        {
            var json = JsonConvert.SerializeObject(posicaoConsolidada);
            _rabbitMQService.SendMessage($"Notificação TORO: {json}");
            Console.WriteLine();
            Console.WriteLine("Notificação TORO");
            Console.WriteLine($"{json}");
        }
    }
}
