using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Lê a frase diretamente
        string frase = Console.ReadLine();

        // Converte a frase para minúsculas e divide em palavras
        string[] palavras = frase.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Dicionário para armazenar as ocorrências das palavras
        Dictionary<string, int> contagem = new Dictionary<string, int>();

        // Contagem das palavras
        foreach (var palavra in palavras)
        {
            if (contagem.ContainsKey(palavra))
            {
                contagem[palavra]++;  // Se a palavra já existe, incrementa o contador
            }
            else
            {
                contagem[palavra] = 1;  // Caso contrário, inicia a contagem com 1
            }
        }

        // Exibe o resultado no formato esperado
        foreach (var item in contagem)
        {
            Console.WriteLine($"{item.Key} {item.Value}");
        }
    }
}
