using System;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamento.classes
{
    public class Vagas
    {
        public int NumeroVaga { get; set; }
        public string PlacaCarro { get; set; }
        public string ModeloCarro { get; set; }

        // Agora usamos TimeSpan para a hora de entrada
        List<(int, string, string, TimeSpan)> tupleList = new List<(int, string, string, TimeSpan)>();
        Financeiro financeiro = new Financeiro();

        public void Lista()
        {
            if (!tupleList.Any())
            {
                Console.WriteLine("Não há carros estacionados.");
            }
            else
            {
                foreach (var (numeroVaga, placaCarro, modeloCarro, horaInicial) in tupleList)
                {
                    Console.WriteLine($"Vaga: [{numeroVaga}] - Modelo: {modeloCarro} - Placa: {placaCarro} - Hora de Entrada: {horaInicial}");
                }
            }

            Console.WriteLine("\nAperte [Enter] para retornar ao menu.");
            Console.ReadKey();
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite o modelo do carro: ");
            ModeloCarro = Console.ReadLine();
            Console.WriteLine("Digite a placa do carro: ");
            PlacaCarro = Console.ReadLine();
            Console.WriteLine("Digite o número da vaga: ");
            NumeroVaga = Convert.ToInt32(Console.ReadLine());

            financeiro.RegistrarHoraEntrada();
            TimeSpan horaInicial = financeiro.HoraEntrada;

            tupleList.Add((NumeroVaga, PlacaCarro, ModeloCarro, horaInicial));
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Você quer remover o veículo de qual vaga?\n\n[Vagas Estacionamento]");
            foreach (var (numeroVaga, placaCarro, modeloCarro, horaInicial) in tupleList)
            {
                Console.WriteLine($"Vaga: [{numeroVaga}] - Modelo: {modeloCarro} - Placa: {placaCarro} - Hora de Entrada: {horaInicial}");
            }

            var removerVeiculoVaga = Convert.ToInt32(Console.ReadLine());
            var vaga = tupleList.FirstOrDefault(tuple => tuple.Item1 == removerVeiculoVaga);

            if (vaga != default)
            {
                financeiro.RegistrarHoraSaida();
                financeiro.HoraEntrada = vaga.Item4;
                financeiro.HoraSaida = financeiro.HoraSaida;

                financeiro.ExibirHorasEstacionadas();
                financeiro.CalcularCobranca();

                tupleList.Remove(vaga);
            }
            else
            {
                Console.WriteLine("Vaga não encontrada.");
            }

        }
    }
}
