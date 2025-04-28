using System;

class CelulaDupla
{
    public string elemento;
    public CelulaDupla anterior;
    public CelulaDupla proximo;

    public CelulaDupla(string elemento)
    {
        this.elemento = elemento;
        this.anterior = null;
        this.proximo = null;
    }
}

class ListaDupla
{
    private CelulaDupla primeiro;
    private CelulaDupla ultimo;

    public ListaDupla()
    {
        primeiro = null;
        ultimo = null;
    }

    public void InserirInicio(string musica)
    {
        CelulaDupla nova = new CelulaDupla(musica);
        if (primeiro == null)
        {
            primeiro = ultimo = nova;
        }
        else
        {
            nova.proximo = primeiro;
            primeiro.anterior = nova;
            primeiro = nova;
        }
    }

    public void InserirFim(string musica)
    {
        CelulaDupla nova = new CelulaDupla(musica);
        if (ultimo == null)
        {
            primeiro = ultimo = nova;
        }
        else
        {
            ultimo.proximo = nova;
            nova.anterior = ultimo;
            ultimo = nova;
        }
    }

    public void Inserir(int pos, string musica)
    {
        if (pos == 0)
        {
            InserirInicio(musica);
        }
        else
        {
            CelulaDupla atual = primeiro;
            for (int i = 0; i < pos - 1 && atual != null; i++)
            {
                atual = atual.proximo;
            }

            if (atual == null || atual == ultimo)
            {
                InserirFim(musica);
            }
            else
            {
                CelulaDupla nova = new CelulaDupla(musica);
                nova.proximo = atual.proximo;
                nova.anterior = atual;
                atual.proximo.anterior = nova;
                atual.proximo = nova;
            }
        }
    }

    public string RemoverInicio()
    {
        if (primeiro == null)
            return null;

        string musica = primeiro.elemento;
        if (primeiro == ultimo)
        {
            primeiro = ultimo = null;
        }
        else
        {
            primeiro = primeiro.proximo;
            primeiro.anterior = null;
        }
        return musica;
    }

    public string RemoverFim()
    {
        if (ultimo == null)
            return null;

        string musica = ultimo.elemento;
        if (primeiro == ultimo)
        {
            primeiro = ultimo = null;
        }
        else
        {
            ultimo = ultimo.anterior;
            ultimo.proximo = null;
        }
        return musica;
    }

    public string RemoverPosicao(int pos)
    {
        if (primeiro == null)
            return null;

        if (pos == 0)
        {
            return RemoverInicio();
        }
        else
        {
            CelulaDupla atual = primeiro;
            for (int i = 0; i < pos && atual != null; i++)
            {
                atual = atual.proximo;
            }

            if (atual == null)
                return null;

            if (atual == ultimo)
            {
                return RemoverFim();
            }
            else
            {
                string musica = atual.elemento;
                atual.anterior.proximo = atual.proximo;
                atual.proximo.anterior = atual.anterior;
                return musica;
            }
        }
    }

    public bool Remover(string musica)
    {
        CelulaDupla atual = primeiro;
        while (atual != null)
        {
            if (atual.elemento.Equals(musica))
            {
                if (atual == primeiro)
                    RemoverInicio();
                else if (atual == ultimo)
                    RemoverFim();
                else
                {
                    atual.anterior.proximo = atual.proximo;
                    atual.proximo.anterior = atual.anterior;
                }
                return true;
            }
            atual = atual.proximo;
        }
        return false;
    }

    public void Mostrar()
    {
        CelulaDupla atual = primeiro;
        while (atual != null)
        {
            Console.WriteLine(atual.elemento);
            atual = atual.proximo;
        }
    }

    public void MostrarInverso()
    {
        CelulaDupla atual = ultimo;
        while (atual != null)
        {
            Console.WriteLine(atual.elemento);
            atual = atual.anterior;
        }
    }

    public bool Pesquisar(string musica)
    {
        CelulaDupla atual = primeiro;
        while (atual != null)
        {
            if (atual.elemento.Equals(musica))
                return true;
            atual = atual.proximo;
        }
        return false;
    }

    public string PesquisarAnterior(string musica)
    {
        CelulaDupla atual = primeiro;
        while (atual != null)
        {
            if (atual.elemento.Equals(musica))
            {
                if (atual.anterior != null)
                    return atual.anterior.elemento;
                else
                    return null;
            }
            atual = atual.proximo;
        }
        return null;
    }

    public string PesquisarPosterior(string musica)
    {
        CelulaDupla atual = primeiro;
        while (atual != null)
        {
            if (atual.elemento.Equals(musica))
            {
                if (atual.proximo != null)
                    return atual.proximo.elemento;
                else
                    return null;
            }
            atual = atual.proximo;
        }
        return null;
    }
}

class GerenciadorMusica
{
    static void Main(string[] args)
    {
        ListaDupla lista = new ListaDupla();
        int op = 0;

        do
        {
            Console.WriteLine("Op:");
            op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    string musica1 = Console.ReadLine();
                    lista.InserirFim(musica1);
                    break;
                case 2:
                    string musica2 = Console.ReadLine();
                    lista.InserirInicio(musica2);
                    break;
                case 3:
                    int pos = int.Parse(Console.ReadLine());
                    string musica3 = Console.ReadLine();
                    lista.Inserir(pos, musica3);
                    break;
                case 4:
                    string removida4 = lista.RemoverInicio();
                    if (removida4 != null)
                        Console.WriteLine(removida4);
                    break;
                case 5:
                    string removida5 = lista.RemoverFim();
                    if (removida5 != null)
                        Console.WriteLine(removida5);
                    break;
                case 6:
                    int pos6 = int.Parse(Console.ReadLine());
                    string removida6 = lista.RemoverPosicao(pos6);
                    if (removida6 != null)
                        Console.WriteLine(removida6);
                    break;
                case 7:
                    string musica7 = Console.ReadLine();
                    bool removeu = lista.Remover(musica7);
                    Console.WriteLine(removeu ? "S" : "N");
                    break;
                case 8:
                    lista.Mostrar();
                    break;
                case 9:
                    lista.MostrarInverso();
                    break;
                case 10:
                    string musica10 = Console.ReadLine();
                    bool achou = lista.Pesquisar(musica10);
                    Console.WriteLine(achou ? "S" : "N");
                    break;
                case 11:
                    string musica11 = Console.ReadLine();
                    string anterior = lista.PesquisarAnterior(musica11);
                    Console.WriteLine(anterior != null ? anterior : "N");
                    break;
                case 12:
                    string musica12 = Console.ReadLine();
                    string posterior = lista.PesquisarPosterior(musica12);
                    Console.WriteLine(posterior != null ? posterior : "N");
                    break;
                case 13:
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

        } while (op != 13);
    }
}
