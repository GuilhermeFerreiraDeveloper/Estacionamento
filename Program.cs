using Estacionamento.classes;

namespace Estacionamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            Vagas vagas = new Vagas();


            do
            {
                Console.Clear();
            
                Console.WriteLine($"      Estacionamento do Gui\n \n [1] - Carros no estacionamento \n [2] - Para registrar um carro  \n [3] - Para remover um carro \n [4] - Sair do aplicativo. \n ");
           
                opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {

                    case 1:
                        vagas.Lista();
                        break;
                    case 2:
                        vagas.AdicionarVeiculo();                        
                        break;
                    case 3:
                        vagas.RemoverVeiculo();
                        break;
                    case 4:
                        Console.WriteLine("Aperte qualquer tecla para finalizar o aplicativo.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;

                }
            }while (opcao != 4);

            Console.ReadKey();
        }
    }
}

