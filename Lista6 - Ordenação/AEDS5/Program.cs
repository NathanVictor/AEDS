using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public class Pais
{
    public string Nome { get; set; }
    public int MedalhasOuro { get; set; }
    public int MedalhasPrata { get; set; }
    public int MedalhasBronze { get; set; }
    public int TotalMedalhas { get; set; }
}

public static class QuadroOlimpico
{

    public static List<Pais> LerArquivo(string caminhoArquivo)
    {
        var paises = new List<Pais>();
        // Lê todas as linhas do arquivo e remove as que estiverem em branco.
        var linhas = File.ReadAllLines(caminhoArquivo)
                         .Where(linha => !string.IsNullOrWhiteSpace(linha))
                         .ToList();

        // Itera sobre as linhas em blocos de 5 (Nome, Ouro, Prata, Bronze, Total)
        for (int i = 0; i < linhas.Count; i += 5)
        {
            if (i + 4 < linhas.Count)
            {
                var pais = new Pais
                {
                    Nome = linhas[i].Trim(),
                    MedalhasOuro = int.Parse(linhas[i + 1].Trim()),
                    MedalhasPrata = int.Parse(linhas[i + 2].Trim()),
                    MedalhasBronze = int.Parse(linhas[i + 3].Trim()),
                    TotalMedalhas = int.Parse(linhas[i + 4].Trim())
                };
                paises.Add(pais);
            }
        }
        return paises;
    }

    public static List<Pais> MergeSort(List<Pais> paises)
    {
        if (paises.Count <= 1)
            return paises;

        int meio = paises.Count / 2;
        var esquerda = new List<Pais>();
        var direita = new List<Pais>();

        for (int i = 0; i < meio; i++)
            esquerda.Add(paises[i]);
        
        for (int i = meio; i < paises.Count; i++)
            direita.Add(paises[i]);

        esquerda = MergeSort(esquerda);
        direita = MergeSort(direita);

        return Merge(esquerda, direita);
    }


    private static List<Pais> Merge(List<Pais> esquerda, List<Pais> direita)
    {
        var resultado = new List<Pais>();
        while (esquerda.Count > 0 || direita.Count > 0)
        {
            if (esquerda.Count > 0 && direita.Count > 0)
            {
                // Decide qual elemento adicionar ao resultado com base na comparação
                if (CompararPaises(esquerda[0], direita[0]) <= 0)
                {
                    resultado.Add(esquerda[0]);
                    esquerda.RemoveAt(0);
                }
                else
                {
                    resultado.Add(direita[0]);
                    direita.RemoveAt(0);
                }
            }
            else if (esquerda.Count > 0)
            {
                resultado.AddRange(esquerda);
                break;
            }
            else if (direita.Count > 0)
            {
                resultado.AddRange(direita);
                break;
            }
        }
        return resultado;
    }


    private static int CompararPaises(Pais a, Pais b)
    {
        // 1. Medalhas de Ouro (ordem decrescente)
        if (a.MedalhasOuro != b.MedalhasOuro)
            return b.MedalhasOuro.CompareTo(a.MedalhasOuro);

        // 2. Medalhas de Prata (ordem decrescente)
        if (a.MedalhasPrata != b.MedalhasPrata)
            return b.MedalhasPrata.CompareTo(a.MedalhasPrata);

        // 3. Medalhas de Bronze (ordem decrescente)
        if (a.MedalhasBronze != b.MedalhasBronze)
            return b.MedalhasBronze.CompareTo(a.MedalhasBronze);

        // 4. Nome do País (ordem alfabética/ascendente)
        return a.Nome.CompareTo(b.Nome);
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        // Define o encoding para UTF-8 para exibir caracteres especiais corretamente
        Console.OutputEncoding = Encoding.UTF8;
        string caminhoArquivo = "olimpiadas.txt";

        try
        {
            // 1. Ler os dados do arquivo
            List<Pais> paises = QuadroOlimpico.LerArquivo(caminhoArquivo);

            // 2. Ordenar os dados usando Merge Sort
            List<Pais> quadroClassificacao = QuadroOlimpico.MergeSort(paises);

            // 3. Exibir o quadro de classificação final
            Console.WriteLine(" quadro de Medalhas das Olimpíadas de 2024 ");
            Console.WriteLine(new string('=', 85));
            Console.WriteLine($"{"Pos.",-5} {"País",-35} | {"Ouro",-7} | {"Prata",-7} | {"Bronze",-7} | {"Total",-7}");
            Console.WriteLine(new string('-', 85));

            int posicao = 1;
            foreach (var pais in quadroClassificacao)
            {
                Console.WriteLine($"{posicao,-5} {pais.Nome,-35} | {pais.MedalhasOuro,-7} | {pais.MedalhasPrata,-7} | {pais.MedalhasBronze,-7} | {pais.TotalMedalhas,-7}");
                posicao++;
            }
            Console.WriteLine(new string('=', 85));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"ERRO: O arquivo '{caminhoArquivo}' não foi encontrado. Verifique se ele está na mesma pasta do executável.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
        }
    }
}