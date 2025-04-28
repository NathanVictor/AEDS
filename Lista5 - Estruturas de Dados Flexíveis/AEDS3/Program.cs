using System;

class Arquivo
{
    public string Nome { get; set; }
    public int NumeroPaginas { get; set; }

    public Arquivo(string nome, int numeroPaginas)
    {
        Nome = nome;
        NumeroPaginas = numeroPaginas;
    }
}

class Celula
{
    public Arquivo Elemento { get; set; }
    public Celula Prox { get; set; }

    public Celula(Arquivo elemento)
    {
        this.Elemento = elemento;
        this.Prox = null;
    }

    public Celula()
    {
        this.Elemento = null;
        this.Prox = null;
    }
}

class Fila
{
    private Celula primeiro, ultimo;

    public Fila()
    {
        primeiro = new Celula();
        ultimo = primeiro;
    }

    public void Inserir(Arquivo arquivo)
    {
        ultimo.Prox = new Celula(arquivo);
        ultimo = ultimo.Prox;
    }

    public Arquivo Remover()
    {
        if (primeiro == ultimo)
        {
            throw new Exception("Erro: fila vazia!");
        }

        Celula tmp = primeiro;
        primeiro = primeiro.Prox;
        Arquivo elemento = primeiro.Elemento;
        tmp.Prox = null;
        tmp = null;
        return elemento;
    }

    public void Mostrar()
    {
        for (Celula i = primeiro.Prox; i != null; i = i.Prox)
        {
            Console.WriteLine($"{i.Elemento.Nome} {i.Elemento.NumeroPaginas}");
        }
    }

    public bool EstaVazia()
    {
        return primeiro == ultimo;
    }
}

class Program
{
    static void Main()
    {
        Fila fila = new Fila();
        int op = 0;

        do
        {
            Console.WriteLine("Op:");
            if (!int.TryParse(Console.ReadLine(), out op))
            {
                Console.WriteLine("Digite um número válido!");
                continue;
            }

            if (op == 1)
            {
                string nome = Console.ReadLine();
                int paginas = int.Parse(Console.ReadLine());
                Arquivo novoArquivo = new Arquivo(nome, paginas);
                fila.Inserir(novoArquivo);
            }
            else if (op == 2)
            {
                if (!fila.EstaVazia())
                {
                    Arquivo impresso = fila.Remover();
                    Console.WriteLine($"{impresso.Nome}");
                }
            }
            else if (op == 3)
            {
                fila.Mostrar();
            }
            else if (op == 4)
            {
                Console.WriteLine("");
            }
        } while (op != 4);
    }
}
