using System;

public class Paciente
{
    public long cpf { get; set; }
    public string nome { get; set; }
    public string email { get; set; }
    public string telefone { get; set; }

    public Paciente(long cpf, string nome, string email, string telefone)
    {
        this.cpf = cpf;
        this.nome = nome;
        this.email = email;
        this.telefone = telefone;
    }

    public override string ToString()
    {
        return $"CPF: {cpf}\nNome: {nome}\nEmail: {email}\nTelefone: {telefone}";
    }
}

public class No
{
    public Paciente valor;
    public No esquerda, direita;
    public int altura;

    public No(Paciente paciente)
    {
        valor = paciente;
        altura = 1;
        esquerda = direita = null;
    }
}

public class ArvoreAVL
{
    private No raiz;

    private int Altura(No no) => no?.altura ?? 0;
    private int Max(int a, int b) => (a > b) ? a : b;
    private int FatorBalanceamento(No no) => (no == null) ? 0 : Altura(no.esquerda) - Altura(no.direita);

    private No RotacaoDireita(No y)
    {
        No x = y.esquerda;
        No T2 = x.direita;
        x.direita = y;
        y.esquerda = T2;
        y.altura = Max(Altura(y.esquerda), Altura(y.direita)) + 1;
        x.altura = Max(Altura(x.esquerda), Altura(x.direita)) + 1;
        return x;
    }

    private No RotacaoEsquerda(No x)
    {
        No y = x.direita;
        No T2 = y.esquerda;
        y.esquerda = x;
        x.direita = T2;
        x.altura = Max(Altura(x.esquerda), Altura(x.direita)) + 1;
        y.altura = Max(Altura(y.esquerda), Altura(y.direita)) + 1;
        return y;
    }

    public void Cadastrar(Paciente paciente)
    {
        raiz = Cadastrar(raiz, paciente);
        Console.WriteLine("=> Paciente cadastrado com sucesso!");
    }

    private No Cadastrar(No no, Paciente paciente)
    {
        if (no == null) return new No(paciente);

        if (paciente.cpf < no.valor.cpf)
            no.esquerda = Cadastrar(no.esquerda, paciente);
        else if (paciente.cpf > no.valor.cpf)
            no.direita = Cadastrar(no.direita, paciente);
        else {
            Console.WriteLine($"=> ERRO: CPF {paciente.cpf} já cadastrado.");
            return no;
        }

        no.altura = 1 + Max(Altura(no.esquerda), Altura(no.direita));
        int fb = FatorBalanceamento(no);

        if (fb > 1 && paciente.cpf < no.esquerda.valor.cpf) return RotacaoDireita(no);
        if (fb < -1 && paciente.cpf > no.direita.valor.cpf) return RotacaoEsquerda(no);
        if (fb > 1 && paciente.cpf > no.esquerda.valor.cpf)
        {
            no.esquerda = RotacaoEsquerda(no.esquerda);
            return RotacaoDireita(no);
        }
        if (fb < -1 && paciente.cpf < no.direita.valor.cpf)
        {
            no.direita = RotacaoDireita(no.direita);
            return RotacaoEsquerda(no);
        }
        return no;
    }

    private No NoComMenorValor(No no)
    {
        No atual = no;
        while (atual.esquerda != null)
            atual = atual.esquerda;
        return atual;
    }

    public void Remover(long cpf)
    {
        raiz = Remover(raiz, cpf);
    }

    private No Remover(No no, long cpf)
    {
        if (no == null) {
            Console.WriteLine("=> ERRO: Paciente não encontrado para remoção.");
            return no;
        }

        if (cpf < no.valor.cpf)
            no.esquerda = Remover(no.esquerda, cpf);
        else if (cpf > no.valor.cpf)
            no.direita = Remover(no.direita, cpf);
        else
        {
            if ((no.esquerda == null) || (no.direita == null))
            {
                No temp = (no.esquerda != null) ? no.esquerda : no.direita;
                if (temp == null) no = null; else no = temp;
            }
            else
            {
                No temp = NoComMenorValor(no.direita);
                no.valor = temp.valor;
                no.direita = Remover(no.direita, temp.valor.cpf);
            }
            Console.WriteLine("=> Paciente removido com sucesso!");
        }

        if (no == null) return no;

        no.altura = Max(Altura(no.esquerda), Altura(no.direita)) + 1;
        int fb = FatorBalanceamento(no);

        if (fb > 1 && FatorBalanceamento(no.esquerda) >= 0) return RotacaoDireita(no);
        if (fb > 1 && FatorBalanceamento(no.esquerda) < 0)
        {
            no.esquerda = RotacaoEsquerda(no.esquerda);
            return RotacaoDireita(no);
        }
        if (fb < -1 && FatorBalanceamento(no.direita) <= 0) return RotacaoEsquerda(no);
        if (fb < -1 && FatorBalanceamento(no.direita) > 0)
        {
            no.direita = RotacaoDireita(no.direita);
            return RotacaoEsquerda(no);
        }
        return no;
    }

    public Paciente Pesquisar(long cpf)
    {
        No no = raiz;
        while (no != null)
        {
            if (cpf < no.valor.cpf) no = no.esquerda;
            else if (cpf > no.valor.cpf) no = no.direita;
            else return no.valor;
        }
        return null;
    }

    public void MostrarNomesInOrder() => InOrder(raiz);
    private void InOrder(No no)
    {
        if (no != null)
        {
            InOrder(no.esquerda);
            Console.WriteLine(no.valor.nome);
            InOrder(no.direita);
        }
    }

    public void MostrarCPFsPostOrder() => PostOrder(raiz);
    private void PostOrder(No no)
    {
        if (no != null)
        {
            PostOrder(no.esquerda);
            PostOrder(no.direita);
            Console.WriteLine(no.valor.cpf);
        }
    }
    
    public void MostrarEmailsPreOrder() => PreOrder(raiz);
    private void PreOrder(No no)
    {
        if (no != null)
        {
            Console.WriteLine(no.valor.email);
            PreOrder(no.esquerda);
            PreOrder(no.direita);
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        ArvoreAVL sistema = new ArvoreAVL();
        int opcao = 0;

        do
        {
            Console.WriteLine("\n========== SISTEMA DE GERENCIAMENTO DE PACIENTES ==========");
            Console.WriteLine("1 - Cadastrar um paciente");
            Console.WriteLine("2 - Remover um paciente");
            Console.WriteLine("3 - Pesquisar um paciente pelo CPF");
            Console.WriteLine("4 - Mostrar os nomes de todos os pacientes (em ordem de CPF)");
            Console.WriteLine("5 - Mostrar os CPFs de todos pacientes (pós-ordem)");
            Console.WriteLine("6 - Mostrar os e-mails de todos pacientes (pré-ordem)");
            Console.WriteLine("7 - Sair");
            Console.WriteLine("=========================================================");
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
                        Console.Write("Digite o CPF (apenas números): ");
                        long cpf = long.Parse(Console.ReadLine());
                        Console.Write("Digite o nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite o e-mail: ");
                        string email = Console.ReadLine();
                        Console.Write("Digite o telefone: ");
                        string telefone = Console.ReadLine();
                        sistema.Cadastrar(new Paciente(cpf, nome, email, telefone));
                    }
                    catch (FormatException) { Console.WriteLine("=> ERRO: CPF inválido. Por favor, insira um número."); }
                    break;
                case 2:
                    try
                    {
                        Console.Write("Digite o CPF do paciente a ser REMOVIDO: ");
                        long cpfRemover = long.Parse(Console.ReadLine());
                        sistema.Remover(cpfRemover);
                    }
                    catch (FormatException) { Console.WriteLine("=> ERRO: CPF inválido. Por favor, insira um número."); }
                    break;
                case 3:
                    try
                    {
                        Console.Write("Digite o CPF do paciente a ser PESQUISADO: ");
                        long cpfPesquisar = long.Parse(Console.ReadLine());
                        Paciente encontrado = sistema.Pesquisar(cpfPesquisar);
                        if (encontrado != null)
                        {
                            Console.WriteLine("\n--- DADOS DO PACIENTE ---");
                            Console.WriteLine(encontrado);
                            Console.WriteLine("-------------------------");
                        }
                        else { Console.WriteLine("\n=> Paciente não cadastrado."); }
                    }
                    catch (FormatException) { Console.WriteLine("=> ERRO: CPF inválido. Por favor, insira um número."); }
                    break;
                case 4:
                    Console.WriteLine("\n--- NOMES DOS PACIENTES (EM ORDEM DE CPF) ---");
                    sistema.MostrarNomesInOrder();
                    Console.WriteLine("---------------------------------------------");
                    break;
                case 5:
                    Console.WriteLine("\n--- CPFS DOS PACIENTES (PÓS-ORDEM) ---");
                    sistema.MostrarCPFsPostOrder();
                    Console.WriteLine("--------------------------------------");
                    break;
                case 6:
                    Console.WriteLine("\n--- E-MAILS DOS PACIENTES (PRÉ-ORDEM) ---");
                    sistema.MostrarEmailsPreOrder();
                    Console.WriteLine("-----------------------------------------");
                    break;
                case 7:
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("=> Opção inválida! Tente novamente.");
                    break;
            }
             if (opcao != 7)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcao != 7);
    }
}