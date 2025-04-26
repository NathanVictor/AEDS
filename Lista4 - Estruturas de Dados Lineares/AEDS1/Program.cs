using System;

class Lista
{
    private double[] array = new double[100];
    private int tamanho = 0;

    public void InserirInicio(double x)
    {
        if (tamanho >= array.Length)
            throw new Exception("Lista cheia.");

        for (int i = tamanho; i > 0; i--)
        {
            array[i] = array[i - 1];
        }

        array[0] = x;
        tamanho++;
    }

    public void InserirFinal(double x)
    {
        if (tamanho >= array.Length)
            throw new Exception("Lista cheia.");

        array[tamanho] = x;
        tamanho++;
    }

    public void InserirPosicao(double x, int pos)
    {
        if (tamanho >= array.Length || pos < 0 || pos > tamanho)
            throw new Exception("Posição inválida ou lista cheia.");

        for (int i = tamanho; i > pos; i--)
        {
            array[i] = array[i - 1];
        }

        array[pos] = x;
        tamanho++;
    }

    public double RemoverInicio()
    {
        if (tamanho == 0)
            throw new Exception("Lista vazia.");

        double removido = array[0];

        for (int i = 0; i < tamanho - 1; i++)
        {
            array[i] = array[i + 1];
        }

        tamanho--;
        return removido;
    }

    public double RemoverFinal()
    {
        if (tamanho == 0)
            throw new Exception("Lista vazia.");

        double removido = array[tamanho - 1];
        tamanho--;
        return removido;
    }

    public double RemoverPosicao(int pos)
    {
        if (pos < 0 || pos >= tamanho)
            throw new Exception("Posição inválida.");

        double removido = array[pos];

        for (int i = pos; i < tamanho - 1; i++)
        {
            array[i] = array[i + 1];
        }

        tamanho--;
        return removido;
    }

    public void RemoverItem(double x)
    {
        for (int i = 0; i < tamanho; i++)
        {
            if (array[i] == x)
            {
                RemoverPosicao(i);
                return;
            }
        }

        Console.WriteLine("Tempo não encontrado.");
    }

    public int Contar(double x)
    {
        int count = 0;
        for (int i = 0; i < tamanho; i++)
        {
            if (array[i] == x)
                count++;
        }
        return count;
    }

    public void Mostrar()
    {
        for (int i = 0; i < tamanho; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
}

class Program
{
    static void Main()
    {
        Lista lista = new Lista();
        int opcao;

        do
        {
            Console.WriteLine("Op:");
            opcao = int.Parse(Console.ReadLine());

            try
            {
                switch (opcao)
                {
                    case 1:
                        double tempo1 = double.Parse(Console.ReadLine());
                        lista.InserirInicio(tempo1);
                        break;

                    case 2:
                        double tempo2 = double.Parse(Console.ReadLine());
                        lista.InserirFinal(tempo2);
                        break;

                    case 3:
                        double tempo3 = double.Parse(Console.ReadLine());
                        int pos3 = int.Parse(Console.ReadLine());
                        lista.InserirPosicao(tempo3, pos3);
                        break;

                    case 4:
                        Console.WriteLine(lista.RemoverInicio());
                        break;

                    case 5:
                        Console.WriteLine(lista.RemoverFinal());
                        break;

                    case 6:
                        int pos6 = int.Parse(Console.ReadLine());
                        Console.WriteLine(lista.RemoverPosicao(pos6));
                        break;

                    case 7:
                        double tempo7 = double.Parse(Console.ReadLine());
                        lista.RemoverItem(tempo7);
                        break;

                    case 8:
                        double tempo8 = double.Parse(Console.ReadLine());
                        Console.WriteLine(lista.Contar(tempo8));
                        break;

                    case 9:
                        lista.Mostrar();
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

        } while (opcao != 10);
    }
}
