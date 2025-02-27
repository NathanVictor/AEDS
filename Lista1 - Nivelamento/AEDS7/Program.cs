using System;
class Estacionamento
{
    private string nome;
    private int numVagasLivres;
    private string[] vagas;

    
    public Estacionamento(string nome, int numTotalVagas)
    {
        this.nome = nome;
        this.numVagasLivres = numTotalVagas;
        vagas = new string[numTotalVagas]; 
    }

    public int Estacionar(string placa)
    {
        if (numVagasLivres > 0)
        {
            for (int i = 0; i < vagas.Length; i++)
            {
                if (vagas[i] == null) 
                {
                    vagas[i] = placa;
                    numVagasLivres--; 
                    return i; 
                }
            }
        }
        return -1; 
    }

    public int BuscarNumVaga(string placa)
    {
        for (int i = 0; i < vagas.Length; i++)
        {
            if (vagas[i] == placa)
            {
                return i; 
            }
        }
        return -1; 
    }

    public void Retirar(string placa)
    {
        int numVaga = BuscarNumVaga(placa);
        if (numVaga != -1)
        {
            vagas[numVaga] = null; 
            numVagasLivres++; 
        }
        else
        {
            Console.WriteLine("Veículo não encontrado.");
        }
    }
  
    public int NumVagasLivres
    {
        get { return numVagasLivres; }
    }

    public void ExibirOcupacao()
    {
        Console.WriteLine("Ocupação do estacionamento:");
        for (int i = 0; i < vagas.Length; i++)
        {
            if (vagas[i] != null)
            {
                Console.WriteLine($"Vaga {i + 1}: {vagas[i]}");
            }
            else
            {
                Console.WriteLine($"Vaga {i + 1}: Vazia");
            }
        }
    }
}

class Teste
{
    static void Main()
    {
        
        Estacionamento estacionamento = new Estacionamento("Estacionamento Central", 30);

     
        Console.WriteLine("Estacionando 5 carros...");
        estacionamento.Estacionar("ABC1234");
        estacionamento.Estacionar("XYZ5678");
        estacionamento.Estacionar("LMN3456");
        estacionamento.Estacionar("PQR6789");
        estacionamento.Estacionar("DEF1234");

        
        estacionamento.ExibirOcupacao();

        
        Console.WriteLine("\nBuscando a placa 'LMN3456'...");
        int vaga = estacionamento.BuscarNumVaga("LMN3456");
        if (vaga != -1)
        {
            Console.WriteLine($"A placa 'LMN3456' está na vaga {vaga + 1}.");
        }
        else
        {
            Console.WriteLine("Placa não encontrada.");
        }

       
        Console.WriteLine("\nRetirando o veículo com a placa 'XYZ5678'...");
        estacionamento.Retirar("XYZ5678");

        
        estacionamento.ExibirOcupacao();

        
        Console.WriteLine("\nEstacionando mais 3 carros...");
        estacionamento.Estacionar("GHI7890");
        estacionamento.Estacionar("JKL2345");
        estacionamento.Estacionar("MNO6789");

        
        estacionamento.ExibirOcupacao();

       
        Console.WriteLine($"\nQuantidade de vagas livres: {estacionamento.NumVagasLivres}");
    }
}
