using System;
using System.Diagnostics;
using System.Linq;

class OrdenacaoEstatisticas {
    public long Comparacoes { get; set; }
    public long Movimentacoes { get; set; }
    public TimeSpan TempoExecucao { get; set; }
}

static class Ordenadores<T> where T : IComparable<T> {
    public static OrdenacaoEstatisticas Selecao(T[] array) {
        var stats = new OrdenacaoEstatisticas();
        Stopwatch sw = Stopwatch.StartNew();

        int n = array.Length;
        for (int i = 0; i < (n - 1); i++) {
            int menor = i;
            for (int j = (i + 1); j < n; j++) {
                stats.Comparacoes++;
                if (array[menor].CompareTo(array[j]) > 0) {
                    menor = j;
                }
            }
            if (menor != i) {
                Trocar(array, i, menor);
                stats.Movimentacoes += 3;
            }
        }

        sw.Stop();
        stats.TempoExecucao = sw.Elapsed;
        return stats;
    }

    public static OrdenacaoEstatisticas Bolha(T[] array) {
        var stats = new OrdenacaoEstatisticas();
        Stopwatch sw = Stopwatch.StartNew();

        int n = array.Length;
        for (int i = 0; i < n - 1; i++) {
            for (int j = n - 1; j > i; j--) {
                stats.Comparacoes++;
                if (array[j].CompareTo(array[j - 1]) < 0) {
                    Trocar(array, j, j - 1);
                    stats.Movimentacoes += 3;
                }
            }
        }

        sw.Stop();
        stats.TempoExecucao = sw.Elapsed;
        return stats;
    }

    public static OrdenacaoEstatisticas Insercao(T[] array) {
        var stats = new OrdenacaoEstatisticas();
        Stopwatch sw = Stopwatch.StartNew();

        int n = array.Length;
        for (int i = 1; i < n; i++) {
            T tmp = array[i];
            int j = i - 1;
            while ((j >= 0) && (array[j].CompareTo(tmp) > 0)) {
                stats.Comparacoes++;
                array[j + 1] = array[j];
                stats.Movimentacoes++;
                j--;
            }
            stats.Comparacoes++;
            array[j + 1] = tmp;
            stats.Movimentacoes++;
        }

        sw.Stop();
        stats.TempoExecucao = sw.Elapsed;
        return stats;
    }

    public static OrdenacaoEstatisticas Quicksort(T[] array) {
        var stats = new OrdenacaoEstatisticas();
        Stopwatch sw = Stopwatch.StartNew();
        Quicksort(array, 0, array.Length - 1, stats);
        sw.Stop();
        stats.TempoExecucao = sw.Elapsed;
        return stats;
    }

    private static void Quicksort(T[] array, int esq, int dir, OrdenacaoEstatisticas stats) {
        int i = esq, j = dir;
        T pivo = array[(esq + dir) / 2];
        while (i <= j) {
            while (array[i].CompareTo(pivo) < 0) { i++; stats.Comparacoes++; }
            while (array[j].CompareTo(pivo) > 0) { j--; stats.Comparacoes++; }
            stats.Comparacoes++;
            if (i <= j) {
                Trocar(array, i, j);
                stats.Movimentacoes += 3;
                i++; j--;
            }
        }
        if (esq < j) Quicksort(array, esq, j, stats);
        if (i < dir) Quicksort(array, i, dir, stats);
    }

    public static OrdenacaoEstatisticas Mergesort(T[] array) {
        var stats = new OrdenacaoEstatisticas();
        Stopwatch sw = Stopwatch.StartNew();
        Mergesort(array, 0, array.Length - 1, stats);
        sw.Stop();
        stats.TempoExecucao = sw.Elapsed;
        return stats;
    }

    private static void Mergesort(T[] array, int esq, int dir, OrdenacaoEstatisticas stats) {
        if (esq < dir) {
            int meio = (esq + dir) / 2;
            Mergesort(array, esq, meio, stats);
            Mergesort(array, meio + 1, dir, stats);

            int nEsq = meio - esq + 1;
            int nDir = dir - meio;
            T[] arrayEsq = new T[nEsq];
            T[] arrayDir = new T[nDir];

            for (int i = 0; i < nEsq; i++) arrayEsq[i] = array[esq + i];
            for (int i = 0; i < nDir; i++) arrayDir[i] = array[meio + 1 + i];

            int i1 = 0, i2 = 0, k = esq;
            while (i1 < nEsq && i2 < nDir) {
                stats.Comparacoes++;
                if (arrayEsq[i1].CompareTo(arrayDir[i2]) <= 0) {
                    array[k++] = arrayEsq[i1++];
                } else {
                    array[k++] = arrayDir[i2++];
                }
                stats.Movimentacoes++;
            }

            while (i1 < nEsq) {
                array[k++] = arrayEsq[i1++];
                stats.Movimentacoes++;
            }

            while (i2 < nDir) {
                array[k++] = arrayDir[i2++];
                stats.Movimentacoes++;
            }
        }
    }

    public static OrdenacaoEstatisticas Heapsort(T[] array) {
        var stats = new OrdenacaoEstatisticas();
        Stopwatch sw = Stopwatch.StartNew();
        int n = array.Length;

        for (int novo = 1; novo < n; novo++) {
            Construir(array, novo, stats);
        }

        while (n > 1) {
            Trocar(array, 0, n - 1);
            stats.Movimentacoes += 3;
            Reconstruir(array, --n, stats);
        }

        sw.Stop();
        stats.TempoExecucao = sw.Elapsed;
        return stats;
    }

    private static void Construir(T[] array, int novo, OrdenacaoEstatisticas stats) {
        while (novo > 0 && array[novo].CompareTo(array[(novo - 1) / 2]) > 0) {
            stats.Comparacoes++;
            Trocar(array, novo, (novo - 1) / 2);
            stats.Movimentacoes += 3;
            novo = (novo - 1) / 2;
        }
        if (novo > 0) stats.Comparacoes++;
    }

    private static void Reconstruir(T[] array, int tam, OrdenacaoEstatisticas stats) {
        int i = 0;
        while (2 * i + 1 < tam) {
            int filho = 2 * i + 1;
            if (filho + 1 < tam && array[filho + 1].CompareTo(array[filho]) > 0) {
                filho++;
                stats.Comparacoes++;
            }
            stats.Comparacoes++;
            if (array[i].CompareTo(array[filho]) < 0) {
                Trocar(array, i, filho);
                stats.Movimentacoes += 3;
                i = filho;
            } else {
                break;
            }
        }
    }

    private static void Trocar(T[] array, int i, int j) {
        T temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

class Program {
    static void Main() {
        Console.WriteLine("Testes de ordenação - int e decimal");

        int[] tamanhos = { 1000, 5000 };

        foreach (var tamanho in tamanhos) {
            Console.WriteLine($"\n--- Vetor INT com {tamanho} elementos ---");
            TestarTodos(tamanho, GerarVetor<int>);
            Console.WriteLine($"\n--- Vetor DECIMAL com {tamanho} elementos ---");
            TestarTodos(tamanho, GerarVetor<decimal>);
        }
    }

    static void TestarTodos<T>(int tamanho, Func<int, string, T[]> gerador) where T : IComparable<T> {
        var crescente = gerador(tamanho, "asc");
        var decrescente = gerador(tamanho, "desc");
        var aleatorio = gerador(tamanho, "rand");

        Console.WriteLine("\nOrdem Crescente:");
        TestarOrdenacao(crescente);
        Console.WriteLine("\nOrdem Decrescente:");
        TestarOrdenacao(decrescente);
        Console.WriteLine("\nOrdem Aleatória:");
        TestarOrdenacao(aleatorio);
    }

    static void TestarOrdenacao<T>(T[] vetorOriginal) where T : IComparable<T> {
        Testar("Seleção", Ordenadores<T>.Selecao, vetorOriginal);
        Testar("Bolha", Ordenadores<T>.Bolha, vetorOriginal);
        Testar("Inserção", Ordenadores<T>.Insercao, vetorOriginal);
        Testar("Quicksort", Ordenadores<T>.Quicksort, vetorOriginal);
        Testar("Mergesort", Ordenadores<T>.Mergesort, vetorOriginal);
        Testar("Heapsort", Ordenadores<T>.Heapsort, vetorOriginal);
    }

    static void Testar<T>(string nome, Func<T[], OrdenacaoEstatisticas> metodo, T[] vetorOriginal) {
        const int repeticoes = 5;
        long totalComparacoes = 0;
        long totalMovimentacoes = 0;
        double totalMs = 0;

        for (int i = 0; i < repeticoes; i++) {
            T[] copia = new T[vetorOriginal.Length];
            vetorOriginal.CopyTo(copia, 0);

            var stats = metodo(copia);
            totalComparacoes += stats.Comparacoes;
            totalMovimentacoes += stats.Movimentacoes;
            totalMs += stats.TempoExecucao.TotalMilliseconds;
        }

        double mediaComparacoes = totalComparacoes / (double)repeticoes;
        double mediaMovimentacoes = totalMovimentacoes / (double)repeticoes;
        double mediaTempoMs = totalMs / repeticoes;

        Console.WriteLine($"{nome,-10} | Comp: {mediaComparacoes,10:0} | Mov: {mediaMovimentacoes,10:0} | Tempo: {mediaTempoMs,8:0.00} ms");
    }

    static T[] GerarVetor<T>(int tamanho, string tipo) {
        Random rand = new Random();
        if (typeof(T) == typeof(int)) {
            return tipo switch {
                "asc" => Enumerable.Range(0, tamanho).Cast<T>().ToArray(),
                "desc" => Enumerable.Range(0, tamanho).Reverse().Cast<T>().ToArray(),
                _ => Enumerable.Range(0, tamanho).Select(_ => (T)(object)rand.Next(10000)).ToArray()
            };
        } else if (typeof(T) == typeof(decimal)) {
            return tipo switch {
                "asc" => Enumerable.Range(0, tamanho).Select(i => (T)(object)(decimal)i).ToArray(),
                "desc" => Enumerable.Range(0, tamanho).Reverse().Select(i => (T)(object)(decimal)i).ToArray(),
                _ => Enumerable.Range(0, tamanho).Select(_ => (T)(object)(decimal)(rand.NextDouble() * 10000)).ToArray()
            };
        } else {
            throw new NotSupportedException("Tipo não suportado.");
        }
    }
}
