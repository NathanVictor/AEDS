using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
class Program
{
    public static void Main()
    {

        Console.WriteLine("Digite o tamanho dos vetores:");
        int j = int.Parse(Console.ReadLine());

        int[] valor1 = new int[j];
        int[] valor2 = new int[j];

        Console.WriteLine("Informe os valores da Primeira variável:");
        
        for (int i = 0; i < valor1.Length; i++)
        {
            valor1[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Informe os valores da Segunda variável:");
        
        for (int i = 0; i < valor2.Length; i++)
        {
            valor2[i] = int.Parse(Console.ReadLine());
        }

        Soma(valor1, valor2);
        Produto(valor1, valor2);
        Diferenca(valor1, valor2);
        Intersecao(valor1, valor2);
        Uniao(valor1, valor2);

    }

    public static void Soma(int[] valor1, int[] valor2)
    {
        Console.WriteLine("Soma das posições:");

        for (int i = 0; i < valor1.Length; i++)
        {
            Console.WriteLine($"Posição {i}: {valor1[i]} + {valor2[i]} = {valor1[i] + valor2[i]}");
        }
    }
    public static void Produto(int[] valor1, int[] valor2)
    {

        Console.WriteLine("Produto das posições:");

        for (int i = 0; i < valor1.Length; i++)
        {

            Console.WriteLine($"Posição {i}: {valor1[i]} * {valor2[i]} = {valor1[i] * valor2[i]}");
        }
    }

    public static void Diferenca(int[] valor1, int[] valor2)
    {

        Console.WriteLine("Diferença das posições:");

        for (int i = 0; i < valor1.Length; i++)
        {

            if (valor1[i] != valor2[i])
            {

                Console.WriteLine($"Posição {i}: {valor1[i]} != {valor2[i]}");
            }
        }
    }

    public static void Intersecao(int[] valor1, int[] valor2)
    {

        Console.WriteLine("Interseção das posições:");

        for (int i = 0; i < valor1.Length; i++)
        {
            if (valor1[i] == valor2[i])
            {
                int resultado = valor1[i];
                Console.WriteLine($"São os mesmo valores: {valor1[i]} = {resultado}");
            }
        }
    }

    public static void Uniao(int[] valor1, int[] valor2)
    {

        for (int i = 0; i < valor1.Length; i++)
        {

            if (valor1[i] == valor2[i] && valor2[i] != valor1[i])
            {
                Console.WriteLine("Todos de " + valor1[i] + valor2[i]);

            }

        }
    }
}
