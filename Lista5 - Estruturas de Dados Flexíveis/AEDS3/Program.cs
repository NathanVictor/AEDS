class Celula
{
    private int Elemento { get; set; }
    private Celula prox { get; set; }

    public Celula(int elemento)
    {
        this.Elemento = elemento;
        this.prox = null;
    }

    public Celula()
    {
        this.Elemento = 0;
        this.prox = null;
    }
}


class Fila
{

    private Celula primeiro, ultimo;
    public Fila() // Cria um Celula
    {
        primeiro = new Celula();
        ultimo = primeiro;
    }

    public void inserir(int x) // Cria uma Celula, porém com um "elemento" dentro.
    {
        ultimo.Prox = new Celula(x);
        ultimo = ultimo.Prox;
    }

    public int Remover() // Remove a ultima Celula da fila.
    {


    }

    public void Mostrar() // Mostra a fila completra.
    {
        if (primeiro == ultime)
        {
            throw new Exception("Erro!");

        }
        Celula tmp = primeiro; // Cria uma variável "temporaria" na primeira Celula e "tmp" é quem vai remover da Celula.
        primeiro = primeiro.prox;
        int elemento = primeiro.Elemento;
        tmp.prox = null;
        tmp = null;
        return elemento;
        
    }
}

class Program
{
    static void Main(string[] args)
    {

    }
}
