using System;
using System.Collections.Generic;

public class No
{
    public int Elemento { get; set; }
    public No Esq { get; set; }
    public No Dir { get; set; }

    public No(int elemento)
    {
        this.Elemento = elemento;
        Esq = null;
        Dir = null;
    }

    public No(int elemento, No esq, No dir)
    {
        this.Elemento = elemento;
        this.Esq = esq;
        this.Dir = dir;
    }
}

public class ArvoreBinaria
{
    private No raiz;

    public ArvoreBinaria()
    {
        raiz = null;
    }

    public void Inserir(int x)
    {
        raiz = InserirRecursivo(raiz, x);
    }

    private No InserirRecursivo(No i, int x)
    {
        if (i == null)
        {
            i = new No(x);
        }
        else if (x < i.Elemento)
        {
            i.Esq = InserirRecursivo(i.Esq, x);
        }
        else if (x > i.Elemento)
        {
            i.Dir = InserirRecursivo(i.Dir, x);
        }
        else
        {
            throw new Exception("ErroInterno: Elemento duplicado.");
        }
        return i;
    }

    public void Remover(int x)
    {
        raiz = RemoverRecursivo(raiz, x);
    }

    private No RemoverRecursivo(No i, int x)
    {
        if (i == null)
        {
            throw new Exception("ErroInterno: Elemento nao encontrado para remocao.");
        }
        else if (x < i.Elemento)
        {
            i.Esq = RemoverRecursivo(i.Esq, x);
        }
        else if (x > i.Elemento)
        {
            i.Dir = RemoverRecursivo(i.Dir, x);
        }
        else if (i.Dir == null)
        {
            i = i.Esq;
        }
        else if (i.Esq == null)
        {
            i = i.Dir;
        }
        else
        {
            i.Esq = MaiorDaEsquerdaSubstitui(i, i.Esq);
        }
        return i;
    }

    private No MaiorDaEsquerdaSubstitui(No noASerSubstituido, No noAtualSubarvoreEsq)
    {
        if (noAtualSubarvoreEsq.Dir == null)
        {
            noASerSubstituido.Elemento = noAtualSubarvoreEsq.Elemento;
            noAtualSubarvoreEsq = noAtualSubarvoreEsq.Esq;
        }
        else
        {
            noAtualSubarvoreEsq.Dir = MaiorDaEsquerdaSubstitui(noASerSubstituido, noAtualSubarvoreEsq.Dir);
        }
        return noAtualSubarvoreEsq;
    }

    public int GetMaior()
    {
        if (raiz == null)
        {
            throw new InvalidOperationException("ErroInterno: A arvore esta vazia!");
        }
        No i = raiz;
        while (i.Dir != null)
        {
            i = i.Dir;
        }
        return i.Elemento;
    }

    public int GetMenor()
    {
        if (raiz == null)
        {
            throw new InvalidOperationException("ErroInterno: A arvore esta vazia!");
        }
        No i = raiz;
        while (i.Esq != null)
        {
            i = i.Esq;
        }
        return i.Elemento;
    }

    private enum Caminho { CENTRAL, PRE, POS }

    private void ColetarParaMostrar(No i, Caminho ordem, List<int> elementos)
    {
        if (i != null)
        {
            if (ordem == Caminho.PRE) elementos.Add(i.Elemento);
            ColetarParaMostrar(i.Esq, ordem, elementos);
            if (ordem == Caminho.CENTRAL) elementos.Add(i.Elemento);
            ColetarParaMostrar(i.Dir, ordem, elementos);
            if (ordem == Caminho.POS) elementos.Add(i.Elemento);
        }
    }

    private void MostrarElementosColetados(List<int> elementos)
    {

        Console.WriteLine(string.Join(" ", elementos));
    }

    public void MostrarCentral()
    {
        List<int> elementos = new List<int>();
        ColetarParaMostrar(raiz, Caminho.CENTRAL, elementos);
        MostrarElementosColetados(elementos);
    }

    public void MostrarPosOrdem()
    {
        List<int> elementos = new List<int>();
        ColetarParaMostrar(raiz, Caminho.POS, elementos);
        MostrarElementosColetados(elementos);
    }

    public void MostrarPreOrdem()
    {
        List<int> elementos = new List<int>();
        ColetarParaMostrar(raiz, Caminho.PRE, elementos);
        MostrarElementosColetados(elementos);
    }

    public bool EstaVazia()
    {
        return raiz == null;
    }

    public bool Pesquisar(int x)
    {
        return PesquisarRecursivo(raiz, x);
    }

    private bool PesquisarRecursivo(No i, int x)
    {
        if (i == null) return false;
        if (x == i.Elemento) return true;
        return x < i.Elemento ? PesquisarRecursivo(i.Esq, x) : PesquisarRecursivo(i.Dir, x);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        ArvoreBinaria arvore = new ArvoreBinaria();
        int opcao = 0;
        int valor;

        do
        {
            Console.WriteLine("Op:");
            string inputOpcao = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputOpcao))
            {

                continue;
            }

            if (!int.TryParse(inputOpcao, out opcao))
            {
                if (inputOpcao?.Trim() == "9")
                {
                    opcao = 9;
                }
                else
                {

                    opcao = 0;


                }
            }



            if (opcao >= 1 && opcao <= 8)
            {
                try
                {
                    switch (opcao)
                    {
                        case 1: // Inserir
                            valor = int.Parse(Console.ReadLine());
                            arvore.Inserir(valor);
                            // NENHUMA SAÍDA DE CONFIRMAÇÃO
                            break;
                        case 2: // Remover
                            valor = int.Parse(Console.ReadLine());
                            arvore.Remover(valor);
                            // NENHUMA SAÍDA DE CONFIRMAÇÃO
                            break;
                        case 3: // Pesquisar
                            valor = int.Parse(Console.ReadLine());
                            bool encontrado = arvore.Pesquisar(valor);
                            Console.WriteLine(encontrado ? "sim" : "nao");
                            break;
                        case 4: // Mostrar Maior
                            Console.WriteLine(arvore.GetMaior());
                            break;
                        case 5: // Mostrar Menor
                            Console.WriteLine(arvore.GetMenor());
                            break;
                        case 6: // Mostrar Central
                            arvore.MostrarCentral();
                            break;
                        case 7: // Mostrar Pos-ordem
                            arvore.MostrarPosOrdem();
                            break;
                        case 8: // Mostrar Pre-ordem
                            arvore.MostrarPreOrdem();
                            break;
                    }
                }
                catch (Exception e) when (e.Message.StartsWith("ErroInterno:"))
                {

                }
                catch (FormatException)
                {

                }

            }
            else if (opcao == 9)
            {

            }
            else
            {
            }

        } while (opcao != 9);
    }
}