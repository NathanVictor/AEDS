using System;

public class No
{
    public string Elemento { get; set; }
    public No esq { get; set; }
    public No dir { get; set; }

    public No(string elemento) 
    {
        this.Elemento = elemento;
        esq = null;
        dir = null;
    }

    public No(string elemento, No esq, No dir) 
    {
        this.Elemento = elemento;
        this.esq = esq;
        this.dir = dir;
    }
}

public class ArvoreBinaria
{
    private No raiz;

    public ArvoreBinaria()
    {
        raiz = null;
    }

    public void Inserir(string x) 
    {
        raiz = InserirRecursivo(x, raiz);
    }

    private No InserirRecursivo(string x, No i)
    {
        if (i == null)
        {
            i = new No(x);
        }
        else if (x.CompareTo(i.Elemento) < 0) 
        {
            i.esq = InserirRecursivo(x, i.esq); 
        }
        else if (x.CompareTo(i.Elemento) > 0) 
        {
            i.dir = InserirRecursivo(x, i.dir); 
        }
        
        return i;
    }

    public void Remover(string x) 
    {
        {
            raiz = RemoverRecursivo(raiz, x);
        }
    
    }

    private No RemoverRecursivo(No i, string x) 
    {
        if (i == null)
        {
            
            return null;
        }
        else if (x.CompareTo(i.Elemento) < 0) 
        {
            i.esq = RemoverRecursivo(i.esq, x);
        }
        else if (x.CompareTo(i.Elemento) > 0) 
        {
            i.dir = RemoverRecursivo(i.dir, x); 
        }
        else if (i.dir == null) 
        {
            i = i.esq;
        }
        else if (i.esq == null)
        {
            i = i.dir;
        }
        else 
        {
            i.esq = MaiorDaEsquerdaSubstitui(i, i.esq);
        }
        return i;
    }

    private No MaiorDaEsquerdaSubstitui(No noASerSubstituido, No noAtualSubarvoreEsq)
    {
        if (noAtualSubarvoreEsq.dir == null) 
        {
            noASerSubstituido.Elemento = noAtualSubarvoreEsq.Elemento; 
            noAtualSubarvoreEsq = noAtualSubarvoreEsq.esq; 
        }
        else
        {
            noAtualSubarvoreEsq.dir = MaiorDaEsquerdaSubstitui(noASerSubstituido, noAtualSubarvoreEsq.dir);
        }
        return noAtualSubarvoreEsq;
    }

    public bool Pesquisar(string x) 
    {
        return PesquisarRecursivo(x, raiz);
    }

    private bool PesquisarRecursivo(string x, No i) 
    {
        bool resp;
        if (i == null)
        {
            resp = false;
        }
        else if (x.CompareTo(i.Elemento) == 0) 
        {
            resp = true;
        }
        else if (x.CompareTo(i.Elemento) < 0) 
        {
            resp = PesquisarRecursivo(x, i.esq); 
        }
        else
        {
            resp = PesquisarRecursivo(x, i.dir); 
        }
        return resp;
    }

    public void MostrarTodosElementosCentral() 
    {
        CaminharCentral(raiz);
    }

    private void CaminharCentral(No i) 
    {
        if (i != null)
        {
            CaminharCentral(i.esq);
            Console.Write(i.Elemento + " ");
            CaminharCentral(i.dir);
        }
    }

    public void MostrarTodosElementosPosOrdem() 
    {
        CaminharPos(raiz);
    }

    private void CaminharPos(No i) 
    {
        if (i != null)
        {
            CaminharPos(i.esq);
            CaminharPos(i.dir);
            Console.Write(i.Elemento + " ");
        }
    }

    public void MostrarTodosElementosPreOrdem() 
    {
        CaminharPre(raiz);
    }

    private void CaminharPre(No i)
    {
        if (i != null)
        {
            Console.Write(i.Elemento + " ");
            CaminharPre(i.esq);
            CaminharPre(i.dir);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArvoreBinaria arvore = new ArvoreBinaria();
        int opcao;

        do
        {
            Console.WriteLine("Op:");
            string entradaOpcao = Console.ReadLine();
            opcao = int.Parse(entradaOpcao);

            string nome;

            switch (opcao)
            {
                case 1: // Inserir
                    nome = Console.ReadLine();
                    arvore.Inserir(nome);
                    break;
                case 2: // Remover
                    nome = Console.ReadLine();
                    arvore.Remover(nome);
                    break;
                case 3: // Pesquisar
                    nome = Console.ReadLine();
                    if (arvore.Pesquisar(nome))
                    {
                        Console.WriteLine("sim");
                    }
                    else
                    {
                        Console.WriteLine("nao");
                    }
                    break;
                case 4: // Mostrar Central
                    arvore.MostrarTodosElementosCentral();
                    Console.WriteLine(); // Nova linha após os elementos
                    break;
                case 5: // Mostrar Pós-ordem
                    arvore.MostrarTodosElementosPosOrdem();
                    Console.WriteLine(); // Nova linha após os elementos
                    break;
                case 6: // Mostrar Pré-ordem
                    arvore.MostrarTodosElementosPreOrdem();
                    Console.WriteLine(); // Nova linha após os elementos
                    break;
                case 7: // Sair
                    break;
                default:
                    break;
            }
        } while (opcao != 7);
    }
}