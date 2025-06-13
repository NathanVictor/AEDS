using System;

public class Estudante
{
    public int matricula { get; set; }
    public string nome { get; set; }
    public string curso { get; set; }

    public Estudante(int matricula, string nome, string curso)
    {
        this.matricula = matricula;
        this.nome = nome;
        this.curso = curso;
    }

    public override string ToString()
    {
        return $"Matrícula: {matricula}, Nome: {nome}, Curso: {curso}";
    }
}

public class No
{
    public Estudante valor { get; set; }
    public No proximo { get; set; }

    public No(Estudante estudante)
    {
        this.valor = estudante;
        this.proximo = null;
    }
}

public class ListaEncadeada
{
    private No cabeca;

    public ListaEncadeada()
    {
        cabeca = null;
    }

    public void Inserir(Estudante estudante)
    {
        No novoNo = new No(estudante);
        novoNo.proximo = cabeca;
        cabeca = novoNo;
    }

    public Estudante Pesquisar(int matricula)
    {
        No atual = cabeca;
        while (atual != null)
        {
            if (atual.valor.matricula == matricula)
            {
                return atual.valor;
            }
            atual = atual.proximo;
        }
        return null;
    }

    public bool Remover(int matricula)
    {
        if (cabeca == null) return false;

        if (cabeca.valor.matricula == matricula)
        {
            cabeca = cabeca.proximo;
            return true;
        }

        No atual = cabeca;
        while (atual.proximo != null && atual.proximo.valor.matricula != matricula)
        {
            atual = atual.proximo;
        }

        if (atual.proximo != null)
        {
            atual.proximo = atual.proximo.proximo;
            return true;
        }

        return false;
    }
}

public class TabelaHash
{
    private readonly int m = 101;
    private ListaEncadeada[] tabela;

    public TabelaHash()
    {
        tabela = new ListaEncadeada[m];
        for (int i = 0; i < m; i++)
        {
            tabela[i] = new ListaEncadeada();
        }
    }

    private int FuncaoHash(int chave)
    {
        return chave % m;
    }

    public void Inserir(Estudante estudante)
    {
        int hash = FuncaoHash(estudante.matricula);

        if (tabela[hash].Pesquisar(estudante.matricula) != null)
        {
            Console.WriteLine($"=> ERRO: A matrícula {estudante.matricula} já está cadastrada.");
            return;
        }

        tabela[hash].Inserir(estudante);
        Console.WriteLine("=> Estudante inserido com sucesso!");
    }

    public Estudante Pesquisar(int matricula)
    {
        int hash = FuncaoHash(matricula);
        return tabela[hash].Pesquisar(matricula);
    }

    public void Remover(int matricula)
    {
        int hash = FuncaoHash(matricula);
        if (tabela[hash].Remover(matricula))
        {
            Console.WriteLine("=> Estudante removido com sucesso!");
        }
        else
        {
            Console.WriteLine("=> ERRO: Estudante não encontrado para remoção.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        TabelaHash sistema = new TabelaHash();
        int opcao = 0;

        do
        {
            Console.WriteLine("\n========== SISTEMA DE REGISTRO DE ESTUDANTES ==========");
            Console.WriteLine("1 - Inserir um estudante");
            Console.WriteLine("2 - Remover um estudante");
            Console.WriteLine("3 - Pesquisar um estudante");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("======================================================");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("=> Opção inválida! Por favor, digite um número.");
                opcao = 0;
                continue;
            }

            switch (opcao)
            {
                case 1:
                    try
                    {
                        Console.Write("Digite a matrícula: ");
                        int matricula = int.Parse(Console.ReadLine());
                        Console.Write("Digite o nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite o curso: ");
                        string curso = Console.ReadLine();

                        Estudante novoEstudante = new Estudante(matricula, nome, curso);
                        sistema.Inserir(novoEstudante);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("=> ERRO: Matrícula inválida. Por favor, insira um número.");
                    }
                    break;

                case 2:
                    try
                    {
                        Console.Write("Digite a matrícula do estudante a ser REMOVIDO: ");
                        int matriculaRemover = int.Parse(Console.ReadLine());
                        sistema.Remover(matriculaRemover);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("=> ERRO: Matrícula inválida. Por favor, insira um número.");
                    }
                    break;

                case 3:
                     try
                    {
                        Console.Write("Digite a matrícula do estudante a ser PESQUISADO: ");
                        int matriculaPesquisar = int.Parse(Console.ReadLine());
                        Estudante encontrado = sistema.Pesquisar(matriculaPesquisar);

                        if (encontrado != null)
                        {
                            Console.WriteLine("\n--- DADOS DO ESTUDANTE ---");
                            Console.WriteLine(encontrado);
                            Console.WriteLine("--------------------------");
                        }
                        else
                        {
                            Console.WriteLine("\n=> Estudante não cadastrado.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("=> ERRO: Matrícula inválida. Por favor, insira um número.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Saindo do sistema...");
                    break;

                default:
                    Console.WriteLine("=> Opção inválida! Tente novamente.");
                    break;
            }
             if (opcao != 4)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcao != 4);
    }
}