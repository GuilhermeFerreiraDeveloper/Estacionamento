using Estacionamento.classes;

namespace Estacionamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0; 
            Vagas vagas = new Vagas();

            do
            {
                Console.Clear();
                Console.WriteLine("      Estacionamento do Gui\n");
                Console.WriteLine("[1] - Carros no estacionamento");
                Console.WriteLine("[2] - Registrar um carro");
                Console.WriteLine("[3] - Remover um carro");
                Console.WriteLine("[4] - Sair do aplicativo.\n");

                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());

                    if (opcao < 1 || opcao > 4)
                    {
                        throw new ArgumentOutOfRangeException(nameof(opcao), "A opção deve estar entre 1 e 4.");
                    }

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
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"            [ E R R O R ] \nPor favor, insira um número válido.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"            [ E R R O R ]\n" +ex.Message); // Mensagem do throw
                }
                Console.WriteLine("\nAperte [Enter] para retornar ao menu.");
                Console.ReadKey();
            } while (opcao != 4); 

            Console.ReadKey();
        }
    }
}
