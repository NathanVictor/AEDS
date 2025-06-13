using System;

public class Program
{
    public class TabelaHash
    {
        private int[] tabela;
        private readonly int m = 13;
        private const int VAZIO = int.MinValue;
        private const int REMOVIDO = int.MaxValue;

        public TabelaHash()
        {
            tabela = new int[m];
            for (int i = 0; i < m; i++)
            {
                tabela[i] = VAZIO;
            }
        }

        private int FuncaoHash(int chave)
        {
            return chave % m;
        }

        public void Inserir(int numero)
        {
            int hash = FuncaoHash(numero);
            
            for (int i = 0; i < m; i++)
            {
                int pos = (hash + i) % m;

                if (tabela[pos] == VAZIO || tabela[pos] == REMOVIDO)
                {
                    tabela[pos] = numero;
                    Console.WriteLine($"=> Número {numero} inserido na posição {pos}.");
                    return;
                }

                if (tabela[pos] == numero)
                {
                    Console.WriteLine($"=> Erro: O número {numero} já existe na tabela.");
                    return;
                }
            }
            
            Console.WriteLine("=> Erro: A tabela está cheia! Não foi possível inserir.");
        }

        public int Pesquisar(int numero)
        {
            int hash = FuncaoHash(numero);
            
            for (int i = 0; i < m; i++)
            {
                int pos = (hash + i) % m;

                if (tabela[pos] == numero)
                {
                    return pos;
                }

                if (tabela[pos] == VAZIO)
                {
                    return -1;
                }
            }

            return -1;
        }

        public void Remover(int numero)
        {
            int pos = Pesquisar(numero);

            if (pos != -1)
            {
                tabela[pos] = REMOVIDO;
                Console.WriteLine($"=> Número {numero} removido da posição {pos}.");
            }
            else
            {
                Console.WriteLine($"=> Erro: Número {numero} não encontrado para remoção.");
            }
        }

        public void Imprimir()
        {
            Console.WriteLine("\n----- Estado Atual da Tabela Hash -----");
            for(int i = 0; i < m; i++)
            {
                Console.Write($"Posição [{i.ToString("D2")}]: ");
                if (tabela[i] == VAZIO)
                {
                    Console.WriteLine("[ Vazio ]");
                }
                else if (tabela[i] == REMOVIDO)
                {
                    Console.WriteLine("[ Removido ]");
                }
                else
                {
                    Console.WriteLine(tabela[i]);
                }
            }
            Console.WriteLine("---------------------------------------\n");
        }
    }

    public static void Main(string[] args)
    {
        TabelaHash hash = new TabelaHash();
        int opcao = 0;

        do
        {
            Console.WriteLine("1 - Inserir um número");
            Console.WriteLine("2 - Remover um número");
            Console.WriteLine("3 - Pesquisar um número");
            Console.WriteLine("4 - Sair");
            hash.Imprimir();
            Console.Write("Escolha uma opção: ");

  

            int numero;

            switch (opcao)
            {
                case 1:
                    Console.Write("Digite o número para INSERIR: ");
                    if (int.TryParse(Console.ReadLine(), out numero))
                    {
                        hash.Inserir(numero);
                    }
                    else
                    {
                        Console.WriteLine("=> Entrada inválida. Por favor, insira um número inteiro.");
                    }
                    break;

                case 2:
                    Console.Write("Digite o número para REMOVER: ");
                     if (int.TryParse(Console.ReadLine(), out numero))
                    {
                        hash.Remover(numero);
                    }
                    else
                    {
                        Console.WriteLine("=> Entrada inválida. Por favor, insira um número inteiro.");
                    }
                    break;

                case 3:
                    Console.Write("Digite o número para PESQUISAR: ");
                     if (int.TryParse(Console.ReadLine(), out numero))
                    {
                        int posicao = hash.Pesquisar(numero);
                        if (posicao != -1)
                        {
                            Console.WriteLine($"=> Número {numero} encontrado na posição {posicao}.");
                        }
                        else
                        {
                            Console.WriteLine($"=> Número {numero} NÃO encontrado na tabela.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("=> Entrada inválida. Por favor, insira um número inteiro.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Saindo do programa...");
                    break;

                default:
                    Console.WriteLine("=> Opção inválida! Tente novamente.");
                    break;
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        } while (opcao != 4);
    }
}