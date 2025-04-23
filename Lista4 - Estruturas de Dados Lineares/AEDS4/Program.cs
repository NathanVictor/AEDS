using System;

class Fila
{
    private string[] array;
    private int inicio;
    private int fim;
    private int tamanho;

    public Fila()
    {
        array = new string[5];
        inicio = 0;
        fim = 0;
        tamanho = 0;
    }

    public bool EstaCheia()
    {
        return tamanho == array.Length;
    }

    public bool EstaVazia()
    {
        return tamanho == 0;
    }

    public void Inserir(string identificador)
    {
        if (!EstaCheia())
        {
            array[fim] = identificador;
            fim = (fim + 1) % array.Length;
            tamanho++;
        }
    }

    public string Remover()
    {
        if (!EstaVazia())
        {
            string removido = array[inicio];
            inicio = (inicio + 1) % array.Length;
            tamanho--;
            return removido;
        }
        return null;
    }

    public int ObterTamanho()
    {
        return tamanho;
    }

    public string ObterPrimeiro()
    {
        if (!EstaVazia())
        {
            return array[inicio];
        }
        return null;
    }

    public void Listar()
    {
        int pos = inicio;
        for (int i = 0; i < tamanho; i++)
        {
            Console.WriteLine(array[pos]);
            pos = (pos + 1) % array.Length;
        }
    }
}

class Teste
{
    static void Main(string[] args)
    {
        Fila fila = new Fila();
        int opcao;

        do
        {
            Console.WriteLine("Op:");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine(fila.ObterTamanho());
                    break;

                case 2:
                    string removido = fila.Remover();
                    if (removido != null)
                        Console.WriteLine(removido);
                    break;

                case 3:
                    string identificador = Console.ReadLine();
                    fila.Inserir(identificador);
                    break;

                case 4:
                    fila.Listar();
                    break;

                case 5:
                    string primeiro = fila.ObterPrimeiro();
                    if (primeiro != null)
                        Console.WriteLine(primeiro);
                    else
                        Console.WriteLine("fila vazia");
                    break;

                case 6:
                    // Encerra sem imprimir mais nada
                    break;

                default:
                    break;
            }

        } while (opcao != 6);
    }
}
