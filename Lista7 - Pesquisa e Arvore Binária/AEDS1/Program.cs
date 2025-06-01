using System;

public class Aluno
{
    public string Nome { get; set; }
    public int Nota { get; set; }

    public Aluno(string nome, int nota)
    {
        Nome = nome;
        Nota = nota;
    }
}

public class Program
{
    // Função de busca binária
    public static int? BuscaBinariaAluno(Aluno[] alunos, string nomeAlvo)
    {
        int esq = 0;
        int dir = alunos.Length - 1;

        while (esq <= dir)
        {
            int meio = (esq + dir) / 2;
            int comparacao = nomeAlvo.CompareTo(alunos[meio].Nome);

            if (comparacao == 0)
            {
                return alunos[meio].Nota;
            }
            else if (comparacao > 0)
            {
                esq = meio + 1;
            }
            else
            {
                dir = meio - 1;
            }
        }

        return null; // Aluno não encontrado
    }

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Aluno[] alunos = new Aluno[n];

        for (int i = 0; i < n; i++)
        {
            string linha = Console.ReadLine();
            string[] partes = linha.Split(',');

            string nome = partes[0].Trim();
            int nota = int.Parse(partes[1].Trim());

            alunos[i] = new Aluno(nome, nota);
        }

        while (true)
        {
            string nomeParaPesquisar = Console.ReadLine();

            int? resultado = BuscaBinariaAluno(alunos, nomeParaPesquisar);

            if (resultado.HasValue)
            {
                Console.WriteLine(resultado.Value);
            }
            else
            {
                Console.WriteLine("nao");
            }

            string desejaContinuar = Console.ReadLine();

            if (desejaContinuar.Trim().ToUpper() == "N")
            {
                break;
            }
        }
    }
}
