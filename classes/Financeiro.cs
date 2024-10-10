using System;

namespace Estacionamento.classes
{
    internal class Financeiro
    {
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSaida { get; set; }
        public double TaxaPorHora { get; set; } = 2.0;

        public void RegistrarHoraEntrada()
        {
            Console.WriteLine("Digite a hora de entrada do Veículo (formato HH:mm): ");
            HoraEntrada = TimeSpan.Parse(Console.ReadLine());
        }

        public void RegistrarHoraSaida()
        {
            Console.WriteLine("Digite a hora de saída do Veículo (formato HH:mm): ");
            HoraSaida = TimeSpan.Parse(Console.ReadLine());
        }

        public double CalcularHorasEstacionado()
        {
            TimeSpan tempoEstacionado;

            if (HoraSaida < HoraEntrada)
            {
                tempoEstacionado = (HoraSaida + new TimeSpan(24, 0, 0)) - HoraEntrada;
            }
            else
            {
                tempoEstacionado = HoraSaida - HoraEntrada;
            }

            double horasTotais = tempoEstacionado.TotalHours;
            return Math.Ceiling(horasTotais);
        }

        public void ExibirHorasEstacionadas()
        {
            double horasEstacionadas = CalcularHorasEstacionado();
            Console.WriteLine($"O veículo ficou estacionado por {horasEstacionadas} horas.");
        }

        public void CalcularCobranca()
        {
            double horasEstacionadas = CalcularHorasEstacionado();
            double totalCobranca = horasEstacionadas * TaxaPorHora;
            Console.WriteLine($"O valor total a ser cobrado é: R$ {totalCobranca:F2}");
        }
    }
}
