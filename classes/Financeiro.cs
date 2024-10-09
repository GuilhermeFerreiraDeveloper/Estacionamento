using System;

namespace Estacionamento.classes
{
    internal class Financeiro
    {
        public double horaEntrada { get; set; }
        public double horaSaida { get; set; }
        public double taxaPorHora { get; set; } = 2.0;

        public void HoraDeEntrada()
        {
            Console.WriteLine("Digite a hora de entrada do Veículo (formato 24h): ");
            horaEntrada = Convert.ToDouble(Console.ReadLine());
        }

        public void HoraDeRetirada()
        {
            Console.WriteLine("Digite a hora de saída do Veículo (formato 24h): ");
            horaSaida = Convert.ToDouble(Console.ReadLine());
        }

        public void HorasEstacionado()
        {
            double tempoEstacionado = horaSaida - horaEntrada;

            if (tempoEstacionado < 0)
            {
                tempoEstacionado += 24;
            }

            Console.WriteLine($"O veículo ficou estacionado por {tempoEstacionado} horas.");
        }

        public void CobrancaPorTempo()
        {
            double tempoEstacionado = horaSaida - horaEntrada;

            if (tempoEstacionado < 0)
            {
                tempoEstacionado += 24;
            }

            double totalCobranca = tempoEstacionado * taxaPorHora;
            Console.WriteLine($"O valor total a ser cobrado é: R$ {totalCobranca:F2}");
        }
    }
}
