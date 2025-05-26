using System;
using System.Diagnostics;

class Validar
{
    public void QuickSort(int[] array, int esq, int dir)
    {
        int i = esq, j = dir;
        int pivo = array[(esq + dir) / 2];

        while (i <= j)
        {
            while (array[i] < pivo) i++;
            while (array[j] > pivo) j--;

            if (i <= j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }

        if (esq < j)
            QuickSort(array, esq, j);
        if (i < dir)
            QuickSort(array, i, dir);
    }

    public void CountingSort(int[] array, int n)
    {
        int GetMaior(int[] arr, int tam)
        {
            int maior = arr[0];
            for (int i = 1; i < tam; i++)
            {
                if (arr[i] > maior)
                    maior = arr[i];
            }
            return maior;
        }

        int maiorElemento = GetMaior(array, n);
        int[] count = new int[maiorElemento + 1];
        int[] ordenado = new int[n];

        for (int i = 0; i < n; i++)
        {
            count[array[i]]++;
        }

        for (int i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        for (int i = n - 1; i >= 0; i--)
        {
            ordenado[count[array[i]] - 1] = array[i];
            count[array[i]]--;
        }

        for (int i = 0; i < n; i++)
        {
            array[i] = ordenado[i];
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        const int tamanho = 1000000;
        int[] vetorOriginal = new int[tamanho];
        Random rand = new Random();

        for (int i = 0; i < tamanho; i++)
        {
            vetorOriginal[i] = rand.Next(0, 101); // valores entre 0 e 100
        }

        // Clonando vetores para manter os mesmos dados para ambos os testes
        int[] vetorQuickSort = (int[])vetorOriginal.Clone();
        int[] vetorCountingSort = (int[])vetorOriginal.Clone();

        Validar validar = new Validar();
        Stopwatch sw = new Stopwatch();

        // Testando QuickSort
        sw.Start();
        validar.QuickSort(vetorQuickSort, 0, vetorQuickSort.Length - 1);
        sw.Stop();
        Console.WriteLine($"Tempo de execução do QuickSort: {sw.ElapsedMilliseconds} ms");

        // Testando CountingSort
        sw.Restart();
        validar.CountingSort(vetorCountingSort, vetorCountingSort.Length);
        sw.Stop();
        Console.WriteLine($"Tempo de execução do CountingSort: {sw.ElapsedMilliseconds} ms");
    }
}
