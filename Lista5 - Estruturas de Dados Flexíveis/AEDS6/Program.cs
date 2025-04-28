using System;

class Site
{
    public string Nome { get; set; }
    public string Link { get; set; }

    public Site(string nome, string link)
    {
        Nome = nome;
        Link = link;
    }
}

class Celula
{
    public Site elemento;
    public Celula prox;

    public Celula(Site site)
    {
        elemento = site;
        prox = null;
    }
}

class Lista
{
    private Celula primeiro;
    private Celula ultimo;

    public Lista()
    {
        primeiro = ultimo = null;
    }

    public void InserirInicio(Site site)
    {
        Celula nova = new Celula(site);
        if (primeiro == null)
        {
            primeiro = ultimo = nova;
        }
        else
        {
            nova.prox = primeiro;
            primeiro = nova;
        }
    }

    public void InserirFim(Site site)
    {
        Celula nova = new Celula(site);
        if (primeiro == null)
        {
            primeiro = ultimo = nova;
        }
        else
        {
            ultimo.prox = nova;
            ultimo = nova;
        }
    }

    public void Inserir(Site site, int pos)
    {
        if (pos == 0)
        {
            InserirInicio(site);
        }
        else
        {
            Celula i = primeiro;
            for (int j = 0; j < pos - 1 && i != null; j++, i = i.prox) ;

            if (i == null)
            {
                InserirFim(site);
            }
            else
            {
                Celula nova = new Celula(site);
                nova.prox = i.prox;
                i.prox = nova;
                if (nova.prox == null)
                {
                    ultimo = nova;
                }
            }
        }
    }

    public void RemoverInicio()
    {
        if (primeiro != null)
        {
            Console.WriteLine(primeiro.elemento.Nome);
            primeiro = primeiro.prox;
            if (primeiro == null)
            {
                ultimo = null;
            }
        }
    }

    public void RemoverFim()
    {
        if (primeiro != null)
        {
            if (primeiro == ultimo)
            {
                Console.WriteLine(primeiro.elemento.Nome);
                primeiro = ultimo = null;
            }
            else
            {
                Celula i = primeiro;
                while (i.prox != ultimo)
                {
                    i = i.prox;
                }
                Console.WriteLine(ultimo.elemento.Nome);
                i.prox = null;
                ultimo = i;
            }
        }
    }

    public void Remover(int pos)
    {
        if (pos == 0)
        {
            RemoverInicio();
        }
        else
        {
            Celula i = primeiro;
            for (int j = 0; j < pos - 1 && i != null; j++, i = i.prox) ;

            if (i != null && i.prox != null)
            {
                Console.WriteLine(i.prox.elemento.Nome);
                i.prox = i.prox.prox;
                if (i.prox == null)
                {
                    ultimo = i;
                }
            }
        }
    }

    public void Mostrar()
    {
        Celula i = primeiro;
        while (i != null)
        {
            Console.WriteLine($"{i.elemento.Nome}: {i.elemento.Link}");
            i = i.prox;
        }
    }

    public string PesquisarLink(string nome)
    {
        Celula i = primeiro;
        while (i != null)
        {
            if (i.elemento.Nome == nome)
            {
                return i.elemento.Link;
            }
            i = i.prox;
        }
        return "N";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Lista lista = new Lista();
        int op = 0;

        while (op != 9)
        {
            Console.WriteLine("Op:");
            op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                string nome = Console.ReadLine();
                string link = Console.ReadLine();
                Site site = new Site(nome, link);
                lista.InserirInicio(site);
            }
            else if (op == 2)
            {
                string nome = Console.ReadLine();
                string link = Console.ReadLine();
                Site site = new Site(nome, link);
                lista.InserirFim(site);
            }
            else if (op == 3)
            {
                int pos = int.Parse(Console.ReadLine());
                string nome = Console.ReadLine();
                string link = Console.ReadLine();
                Site site = new Site(nome, link);
                lista.Inserir(site, pos);
            }
            else if (op == 4)
            {
                lista.RemoverInicio();
            }
            else if (op == 5)
            {
                lista.RemoverFim();
            }
            else if (op == 6)
            {
                int pos = int.Parse(Console.ReadLine());
                lista.Remover(pos);
            }
            else if (op == 7)
            {
                lista.Mostrar();
            }
            else if (op == 8)
            {
                string nome = Console.ReadLine();
                Console.WriteLine(lista.PesquisarLink(nome));
            }
        }
    }
}
