using System;

class Livro
{
    private string titulo;
    private string autores;
    private string editora;

    
    public Livro(string titulo, string autores, string editora)
    {
        this.titulo = titulo;
        this.autores = autores;
        this.editora = editora;
    }

    
    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string Autores
    {
        get { return autores; }
        set { autores = value; }
    }

    public string Editora
    {
        get { return editora; }
        set { editora = value; }
    }

    
    public string ExibirInfo()
    {
        return $"Título: {titulo}, Autores: {autores}, Editora: {editora}";
    }
}

class Biblioteca
{
    private Livro[] acervo;
    private int numLivros;
    private const int MAXLIV = 50;

    
    public Biblioteca()
    {
        acervo = new Livro[MAXLIV];
        numLivros = 0;
    }

    
    public bool AdicionarLivro(string titulo, string autores, string editora)
    {
        if (numLivros < MAXLIV)
        {
            acervo[numLivros] = new Livro(titulo, autores, editora);
            numLivros++;
            return true;
        }
        return false; 
    }

   
    public bool AdicionarLivro(Livro livro)
    {
        if (numLivros < MAXLIV)
        {
            acervo[numLivros] = livro;
            numLivros++;
            return true;
        }
        return false; 
    }

  
    public Livro RetornarLivroPorTitulo(string titulo)
    {
        foreach (var livro in acervo)
        {
            if (livro != null && livro.Titulo == titulo)
            {
                return livro;
            }
        }
        return null; 
    }

    
    public string ListarTodosLivros()
    {
        string listaLivros = "";
        foreach (var livro in acervo)
        {
            if (livro != null)
            {
                listaLivros += livro.Titulo + "\n";
            }
        }
        return listaLivros.Trim(); 
    }

   
    public int NumeroDeLivros()
    {
        return numLivros;
    }
}

class Teste
{
    static void Main()
    {
       
        Biblioteca biblioteca = new Biblioteca();

        // Adicionando livros à biblioteca
        biblioteca.AdicionarLivro("O Senhor dos Anéis", "J.R.R. Tolkien", "HarperCollins");
        biblioteca.AdicionarLivro("1984", "George Orwell", "Companhia das Letras");
        biblioteca.AdicionarLivro("Dom Casmurro", "Machado de Assis", "José Olympio");
        biblioteca.AdicionarLivro("O Pequeno Príncipe", "Antoine de Saint-Exupéry", "Editora Agir");

        
        string tituloParaBuscar = "1984";
        Livro livroEncontrado = biblioteca.RetornarLivroPorTitulo(tituloParaBuscar);
        if (livroEncontrado != null)
        {
            Console.WriteLine("Livro encontrado:");
            Console.WriteLine(livroEncontrado.ExibirInfo());
        }
        else
        {
            Console.WriteLine($"Livro com o título '{tituloParaBuscar}' não encontrado.");
        }

        Console.WriteLine("\nTodos os livros da biblioteca:");
        Console.WriteLine(biblioteca.ListarTodosLivros());

        
        Console.WriteLine($"\nNúmero de livros na biblioteca: {biblioteca.NumeroDeLivros()}");
    }
}
