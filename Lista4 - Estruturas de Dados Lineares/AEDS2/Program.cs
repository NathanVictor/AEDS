using System;

class Produto
{
    private string nome;
    private int quant;
    private double preco;

    public Produto(string nome, int quant, double preco)
    {
        this.nome = nome;
        this.quant = quant;
        this.preco = preco;
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public int Quant
    {
        get { return quant; }
        set { quant = value; }
    }

    public double Preco
    {
        get { return preco; }
        set { preco = value; }
    }

    public override string ToString()
    {
        return $"{nome} {quant} {(preco % 1 == 0 ? preco.ToString("0") : preco.ToString("0.##"))}";
    }
}

class Lista
{
    private Produto[] array;
    private int n;

    public Lista()
    {
        array = new Produto[100];
        n = 0;
    }

    public void InserirFinal(Produto p)
    {
        if (n < array.Length)
        {
            array[n] = p;
            n++;
        }
    }

    public Produto RemoverItem(string nome)
    {
        for (int i = 0; i < n; i++)
        {
            if (array[i].Nome == nome)
            {
                Produto removido = array[i];
                for (int j = i; j < n - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                n--;
                return removido;
            }
        }
        return null;
    }

    public void Listar()
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    public bool Pesquisar(string nome)
    {
        for (int i = 0; i < n; i++)
        {
            if (array[i].Nome == nome)
                return true;
        }
        return false;
    }
}

class Teste
{
    static void Main(string[] args)
    {
        Lista lista = new Lista();
        int op;

        do
        {
            Console.WriteLine("Op:");
            op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                string nome = Console.ReadLine();
                int quant = int.Parse(Console.ReadLine());
                double preco = double.Parse(Console.ReadLine());

                Produto p = new Produto(nome, quant, preco);
                lista.InserirFinal(p);
            }
            else if (op == 2)
            {
                string nome = Console.ReadLine();
                Produto removido = lista.RemoverItem(nome);

                if (removido != null)
                    Console.WriteLine(removido);
                else
                    Console.WriteLine("produto não encontrado");
            }
            else if (op == 3)
            {
                lista.Listar();
            }
            else if (op == 4)
            {
                string nome = Console.ReadLine();
                if (lista.Pesquisar(nome))
                    Console.WriteLine("produto cadastrado");
                else
                    Console.WriteLine("produto não cadastrado");
            }
            else if (op == 5)
            {
            }

        } while (op != 5);
    }
}
