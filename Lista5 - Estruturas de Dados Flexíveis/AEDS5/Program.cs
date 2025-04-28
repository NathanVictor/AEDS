using System;

class Celula
{
    public double Elemento { get; set; }
    public Celula Prox { get; set; }

    public Celula(double elemento)
    {
        this.Elemento = elemento;
        this.Prox = null;
    }

    public Celula()
    {
        this.Elemento = 0;
        this.Prox = null;
    }
}

class Lista
{
    private Celula primeiro, ultimo;

    public Lista()
    {
        primeiro = new Celula();
        ultimo = primeiro;
    }

    public void InserirInicio(double x)
    {
        Celula tmp = new Celula(x);
        tmp.Prox = primeiro.Prox;
        primeiro.Prox = tmp;

        if (primeiro == ultimo)
        {
            ultimo = tmp;
        }
    }

    public void InserirFim(double x)
    {
        ultimo.Prox = new Celula(x);
        ultimo = ultimo.Prox;
    }

    public void Inserir(double x, int pos)
    {
        int tamanho = Tamanho();

        if (pos < 0 || pos > tamanho)
        {
            throw new Exception("Posição inválida!");
        }

        if (pos == 0)
        {
            InserirInicio(x);
        }
        else if (pos == tamanho)
        {
            InserirFim(x);
        }
        else
        {
            Celula i = primeiro;
            for (int j = 0; j < pos; j++, i = i.Prox);

            Celula tmp = new Celula(x);
            tmp.Prox = i.Prox;
            i.Prox = tmp;
        }
    }

    public double RemoverInicio()
    {
        if (primeiro == ultimo)
        {
            throw new Exception("Erro: lista vazia!");
        }

        Celula tmp = primeiro.Prox;
        primeiro.Prox = tmp.Prox;

        if (tmp == ultimo)
        {
            ultimo = primeiro;
        }

        double elemento = tmp.Elemento;
        tmp = null;
        return elemento;
    }

    public double RemoverFim()
    {
        if (primeiro == ultimo)
        {
            throw new Exception("Erro: lista vazia!");
        }

        Celula i;
        for (i = primeiro; i.Prox != ultimo; i = i.Prox);

        double elemento = ultimo.Elemento;
        ultimo = i;
        ultimo.Prox = null;
        return elemento;
    }

    public double Remover(int pos)
    {
        int tamanho = Tamanho();

        if (pos < 0 || pos >= tamanho)
        {
            throw new Exception("Posição inválida!");
        }

        if (pos == 0)
        {
            return RemoverInicio();
        }
        else if (pos == tamanho - 1)
        {
            return RemoverFim();
        }
        else
        {
            Celula i = primeiro;
            for (int j = 0; j < pos; j++, i = i.Prox);

            Celula tmp = i.Prox;
            i.Prox = tmp.Prox;

            double elemento = tmp.Elemento;
            tmp = null;
            return elemento;
        }
    }

    public void RemoverItem(double x)
    {
        Celula i = primeiro;
        while (i.Prox != null && i.Prox.Elemento != x)
        {
            i = i.Prox;
        }

        if (i.Prox != null)
        {
            Celula tmp = i.Prox;
            i.Prox = tmp.Prox;
            if (tmp == ultimo)
            {
                ultimo = i;
            }
            tmp = null;
        }
    }

    public int Contar(double x)
    {
        int cont = 0;
        for (Celula i = primeiro.Prox; i != null; i = i.Prox)
        {
            if (i.Elemento == x)
            {
                cont++;
            }
        }
        return cont;
    }

    public void Mostrar()
    {
        for (Celula i = primeiro.Prox; i != null; i = i.Prox)
        {
            Console.WriteLine(i.Elemento);
        }
    }

    private int Tamanho()
    {
        int cont = 0;
        for (Celula i = primeiro.Prox; i != null; i = i.Prox)
        {
            cont++;
        }
        return cont;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Lista lista = new Lista();
        int op = 0;

        do
        {
            Console.WriteLine("Op:");
            if (!int.TryParse(Console.ReadLine(), out op))
            {
                Console.WriteLine("Digite uma opção válida!");
                continue;
            }

            if (op == 1)
            {
                double tempo = double.Parse(Console.ReadLine());
                lista.InserirInicio(tempo);
            }
            else if (op == 2)
            {
                double tempo = double.Parse(Console.ReadLine());
                lista.InserirFim(tempo);
            }
            else if (op == 3)
            {
                double tempo = double.Parse(Console.ReadLine());
                int pos = int.Parse(Console.ReadLine());
                lista.Inserir(tempo, pos);
            }
            else if (op == 4)
            {
                double removido = lista.RemoverInicio();
                Console.WriteLine(removido);
            }
            else if (op == 5)
            {
                double removido = lista.RemoverFim();
                Console.WriteLine(removido);
            }
            else if (op == 6)
            {
                int pos = int.Parse(Console.ReadLine());
                double removido = lista.Remover(pos);
                Console.WriteLine(removido);
            }
            else if (op == 7)
            {
                double tempo = double.Parse(Console.ReadLine());
                lista.RemoverItem(tempo);
            }
            else if (op == 8)
            {
                double tempo = double.Parse(Console.ReadLine());
                int contagem = lista.Contar(tempo);
                Console.WriteLine(contagem);
            }
            else if (op == 9)
            {
                lista.Mostrar();
            }
            else if (op == 10)
            {
                // programa encerrado
            }
        } while (op != 10);
    }
}
