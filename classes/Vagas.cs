namespace Estacionamento.classes;

public class Vagas
{
    public int numeroVaga { get; set; }
    public string placaCarro { get; set; }
    public string modeloCarro { get; set; }

    List<(int, string, string, double)> tupleList = new List<(int, string, string, double)>();
    Financeiro financeiro = new Financeiro();

    public void Lista()
    {
        foreach (var (numeroVaga, placaCarro, modeloCarro, horaInicial) in tupleList)
        {
            Console.WriteLine($"vaga: [{numeroVaga}]  -  Modelo do Veiculo: {modeloCarro}  -  Placa: {placaCarro} - Hora de Entrada: {horaInicial} ");
        }
            Console.WriteLine($" \n Aperte [Enter] para retornar ao menu.");
            Console.ReadKey();
    }

    public void AdicionarVeiculo()
    {
        Console.WriteLine("Digite o modelo do Carro: ");
        modeloCarro = Console.ReadLine();
        Console.WriteLine("Digite a placa do Carro: ");
        placaCarro = Console.ReadLine();
        Console.WriteLine("Vaga estacionado: ");
        numeroVaga = Convert.ToInt32(Console.ReadLine());

        financeiro.HoraDeEntrada();
        double horaInicial = financeiro.horaEntrada;

        tupleList.Add((numeroVaga, placaCarro, modeloCarro, horaInicial));
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Você quer remover o veiculo de qual Vaga? \n \n      [Vagas Estacionamento]");
        foreach (var (numeroVaga, placaCarro, modeloCarro, horaInicial) in tupleList)
        {
            Console.WriteLine($"vaga: [{numeroVaga}]  -  Modelo do Veiculo: {modeloCarro}  -  Placa: {placaCarro} - Hora de Entrada: {horaInicial} ");
        }
        var removerVeiculoVaga = Convert.ToInt32(Console.ReadLine());

        var vaga = tupleList.FirstOrDefault(tuple => tuple.Item1 == removerVeiculoVaga);

        if (vaga.Item1 != 0) 
        {
            financeiro.HoraDeRetirada();
            financeiro.horaEntrada = vaga.Item4; 
            financeiro.horaSaida = financeiro.horaSaida; 
            financeiro.HorasEstacionado();
            financeiro.CobrancaPorTempo();

            tupleList.Remove(vaga);

        }
        else
        {
            Console.WriteLine("Vaga não encontrada.");
        }
        Console.WriteLine($" \n Aperte [Enter] para retornar ao menu.");
        Console.ReadKey();
    }
}
