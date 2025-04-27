using System;

class Celula
{
    public int Elemento { get; set; }
    public Celula Prox { get; set; }

    public Celula(int elemento)
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
class Pilha
{

    private Celula topo;

    public Pilha()
    {
        topo = null;
    }

    public void inserir(int x)
    {
        Celula tmp = new Celula(x);
        tmp.Prox = topo;
        topo = tmp;
    }

    public int Remover()
    {
        if (Vazia())
        {
            throw new Exception("Erro ao remover: pilha vazia!");
        }

        int elemento = topo.Elemento;
        Celula tmp = topo;
        topo = topo.Prox;
        tmp.Prox = null;
        tmp = null;
        return elemento;

    }

    public bool Vazia()
    {
        return topo == null;
    }

    public void mostra()
    {
        Console.Write("[");

        for (Celula i = topo; i != null; i = i.Prox)
        {
            Console.Write(i.Elemento);
        }
        Console.Write("]");
    }
}

class Program
{
    public static void VerificarOctal(int valor)
    {
        Pilha pilha = new Pilha();

        if (valor == 0)
        {
            pilha.inserir(0);
        }

        while (valor > 0)
        {
            int resto = valor % 8;
            pilha.inserir(resto);
            valor = valor / 8;
        }

        while (!pilha.Vazia())
        {
            Console.Write(pilha.Remover());
        }

        Console.WriteLine();
    }


    public static void Main()
    {
        int numero = int.Parse(Console.ReadLine());
        VerificarOctal(numero);



    }


}