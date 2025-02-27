using System;
class Jogador
{
    private int numero;
    string nome;
    string posicao;

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public int Numero
    {
        get { return numero; }
        set { numero = value; }
    }

    public string Posicao
    {
        get { return posicao; }
        set { posicao = value; }
    }

    public Jogador(int numero, string nome, string posicao)
    {
        this.numero = numero;
        this.nome = nome;
        this.posicao = posicao;
    }
}

class Time
{
    string nome;
    Jogador[] titulares = new Jogador[11];  
    int quantTitulares = 0;  
    Jogador[] reservas = new Jogador[12]; 
    int quantReservas = 0;  


    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public bool AdicionarTitular(Jogador jogador)
    {
        if (quantTitulares < 11)
        {
            titulares[quantTitulares] = jogador;
            quantTitulares++;
            return true;
        }
        return false;
    }

    public bool AdicionarReserva(Jogador jogador)
    {
        if (quantReservas < 12)
        {
            reservas[quantReservas] = jogador;
            quantReservas++;
            return true;
        }
        return false;
    }

    public bool SubstituirTitular(string nomeTitular, Jogador novoJogador)
    {
        for (int i = 0; i < quantTitulares; i++)
        {
            if (titulares[i].Nome == nomeTitular)
            {
                titulares[i] = novoJogador;
                return true;
            }
        }
        return false;
    }


    public bool SubstituirReserva(string nomeReserva, Jogador novoJogador)
    {
        for (int i = 0; i < quantReservas; i++)
        {
            if (reservas[i].Nome == nomeReserva)
            {
                reservas[i] = novoJogador;
                return true;
            }
        }
        return false;
    }

    public bool ConsultarTitular(string nomeTitular)
    {
        for (int i = 0; i < quantTitulares; i++)
        {
            if (titulares[i].Nome == nomeTitular)
            {
                return true;
            }
        }
        return false;
    }

    
    public bool ConsultarReserva(string nomeReserva)
    {
        for (int i = 0; i < quantReservas; i++)
        {
            if (reservas[i].Nome == nomeReserva)
            {
                return true;
            }
        }
        return false;
    }

 
    public bool ExcluirTitular(string nomeTitular)
    {
        for (int i = 0; i < quantTitulares; i++)
        {
            if (titulares[i].Nome == nomeTitular)
            {
                for (int j = i; j < quantTitulares - 1; j++)
                {
                    titulares[j] = titulares[j + 1];
                }
                titulares[quantTitulares - 1] = null;
                quantTitulares--;
                return true;
            }
        }
        return false;
    }

    
    public bool ExcluirReserva(string nomeReserva)
    {
        for (int i = 0; i < quantReservas; i++)
        {
            if (reservas[i].Nome == nomeReserva)
            {
                for (int j = i; j < quantReservas - 1; j++)
                {
                    reservas[j] = reservas[j + 1];
                }
                reservas[quantReservas - 1] = null;
                quantReservas--;
                return true;
            }
        }
        return false;
    }

  
    public void GerarArqTime(string nomeArquivo)
    {
       
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(nomeArquivo))
        {
            file.WriteLine($"Time: {nome}");
            file.WriteLine("Titulares:");
            foreach (var jogador in titulares)
            {
                if (jogador != null)
                    file.WriteLine($"{jogador.Numero} - {jogador.Nome} - {jogador.Posicao}");
            }
            file.WriteLine("Reservas:");
            foreach (var jogador in reservas)
            {
                if (jogador != null)
                    file.WriteLine($"{jogador.Numero} - {jogador.Nome} - {jogador.Posicao}");
            }
        }
    }
}

class Teste
{
    static void Main()
    {
        Jogador jogador1 = new Jogador(10, "Jogador 1", "atacante");
        Jogador jogador2 = new Jogador(5, "Jogador 2", "goleiro");

        Time time = new Time();
        time.Nome = "Time Exemplo";

        time.AdicionarTitular(jogador1);
        time.AdicionarReserva(jogador2);

        Console.WriteLine(time.ConsultarTitular("Jogador 1")); // true
        Console.WriteLine(time.ConsultarReserva("Jogador 2")); // true

        Jogador jogador3 = new Jogador(9, "Jogador 3", "meia");
        time.SubstituirTitular("Jogador 1", jogador3);

        time.ExcluirTitular("Jogador 3");

        time.GerarArqTime("time.txt");
    }
}
