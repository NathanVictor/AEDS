using System;
using System.Diagnostics;

class Program
{
    // Método de ordenação por seleção
    static void Selecao(int[] array, int n)
    {
        for (int i = 0; i < (n - 1); i++)
        {
            int menor = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[menor] > array[j])
                {
                    menor = j;
                }
            }
            if (menor != i)
            {
                int temp = array[menor];
                array[menor] = array[i];
                array[i] = temp;
            }
        }
    }

    static void Main(string[] args)
    {
        int[] vet = { 1, 6, 0, 3, 7 };

        // Medir tempo da ordenação
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        Selecao(vet, vet.Length); // chamada da ordenação

        stopWatch.Stop();

        // Exibir vetor ordenado
        for (int i = 0; i < vet.Length; i++)
        {
            Console.Write(vet[i] + " ");
        }

        // Exibir tempo de execução
        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        Console.WriteLine("\nTempo: " + elapsedTime);
    }
}
