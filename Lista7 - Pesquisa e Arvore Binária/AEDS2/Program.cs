class No
{
    private int elemento;
    private No esq;
    private No dir;


    public No(int elemento)
    {
        this.elemento = elemento;
        esq = null;
        dir = null;
    }

    public No(int elemento, No esq, No dir)
    {
        this.elemento = elemento;
        this.esq = esq;
        this.dir = dir;
    }
}

class Program
{

    private No raiz;

    public ArvoreBinaria()
    {
        raiz = null;
    }

    public void InserirBinario(int x)
    {
        raiz = Inserir(x, raiz);

    }

    private No Inserir(int x, No i)
    {

        if (i == null)
        {
            i = new No(x);
        }
        else if (x < i.Elemento)
        {
            i.esq = Inserir(x, i.esq);
        }
        else if (x > i.Elemento)
        {
            i.dir = Inserir(x, i.dir);
        }
        else
        {
            throw new Exception("Erro!");
        }
        return i;
    }

    public static RemoverBinario()
    {

    }

    public static MostrarMaiorElementoBinario()
    {

    }

    public static MostrarMenorElementoBinario()
    {

    }

    public static MostrarTodosElementosArvoreCentral()
    {

    }

    public static MostrarCaminhaPosOrdem()
    {

    }

    public static MostrarCaminhoPreOrdem()
    {

    }


}