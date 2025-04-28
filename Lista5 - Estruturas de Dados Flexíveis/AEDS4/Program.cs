using System;

class Celula
{
    public string Elemento { get; set; }
    public Celula Prox { get; set; }

    public Celula(string elemento)
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

    public void Inserir(string nome)
    {
        ultimo.Prox = new Celula(nome);
        ultimo = ultimo.Prox;
    }

    public string Remover()
    {
        if (primeiro == ultimo)
        {
            throw new Exception("Erro: fila vazia!");
        }

        Celula tmp = primeiro;
        primeiro = primeiro.Prox;
        string elemento = primeiro.Elemento;
        tmp.Prox = null;
        tmp = null;
        return elemento;
    }

    public void Mostrar()
    {
        for (Celula i = primeiro.Prox; i != null; i = i.Prox)
        {
            Console.WriteLine(i.Elemento);
        }
    }

    public bool Pesquisar(string nome)
    {
        for (Celula i = primeiro.Prox; i != null; i = i.Prox)
        {
            if (i.Elemento.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
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
        Fila filaIniciacao = new Fila();
        Fila filaMestrado = new Fila();
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
                filaIniciacao.Inserir(nome);
            }
            else if (op == 2)
            {
                string nome = Console.ReadLine();
                filaMestrado.Inserir(nome);
            }
            else if (op == 3)
            {
                if (!filaIniciacao.EstaVazia())
                {
                    string removido = filaIniciacao.Remover();
                    Console.WriteLine(removido);
                }
            }
            else if (op == 4)
            {
                if (!filaMestrado.EstaVazia())
                {
                    string removido = filaMestrado.Remover();
                    Console.WriteLine(removido);
                }
            }
            else if (op == 5)
            {
                filaIniciacao.Mostrar();
            }
            else if (op == 6)
            {
                filaMestrado.Mostrar();
            }
            else if (op == 7)
            {
                string nome = Console.ReadLine();
                Console.WriteLine(filaIniciacao.Pesquisar(nome) ? "S" : "N");
            }
            else if (op == 8)
            {
                string nome = Console.ReadLine();
                Console.WriteLine(filaMestrado.Pesquisar(nome) ? "S" : "N");
            }
            else if (op == 9)
            {
                // programa será encerrado
            }
        } while (op != 9);
    }
}
