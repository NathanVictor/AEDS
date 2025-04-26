using System;

class Celula
{
    public char Elemento { get; set; }
    public Celula Prox { get; set; }

    public Celula(char elemento)
    {
        this.Elemento = elemento;
        this.Prox = null;
    }

    public Celula()
    {
        this.Elemento = '\0';
        this.Prox = null;
    }
}

class Pilha
{
    private Celula topo;

    public Pilha()
    {
        topo = null;
    }

    public void Inserir(char x)
    {
        Celula tmp = new Celula(x);
        tmp.Prox = topo;
        topo = tmp;
    }

    public char Remover()
    {
        if (Vazia())
        {
            throw new Exception("Erro ao remover: pilha vazia!");
        }

        char elemento = topo.Elemento;
        topo = topo.Prox;
        return elemento;
    }

    public bool Vazia()
    {
        return topo == null;
    }

    public void Mostrar()
    {
        Console.Write("[ ");
        for (Celula i = topo; i != null; i = i.Prox)
        {
            Console.Write(i.Elemento + " ");
        }
        Console.WriteLine("]");
    }
}

class Program
{
    public static bool VerificarSequencia(string sequencia)
    {
        Pilha pilha = new Pilha();

        foreach (char c in sequencia)
        {
            if (c == '(' || c == '[')
            {
                pilha.Inserir(c);
            }
            else if (c == ')')
            {
                if (pilha.Vazia() || pilha.Remover() != '(')
                    return false;
            }
            else if (c == ']')
            {
                if (pilha.Vazia() || pilha.Remover() != '[')
                    return false;
            }
        }

        return pilha.Vazia();
    }

    public static void Main()
    {
        Console.WriteLine("Digite a sequência:");
        string entrada = Console.ReadLine();

        if (VerificarSequencia(entrada))
        {
            Console.WriteLine("Correta");
        }
        else
        {
            Console.WriteLine("Errada");
        }
    }
}
