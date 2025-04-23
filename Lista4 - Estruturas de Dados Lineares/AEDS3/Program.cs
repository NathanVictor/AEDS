using System;

class Pilha
{
    private char[] array;
    private int topo;

    public Pilha()
    {
        array = new char[100];
        topo = 0;
    }

    public void Empilhar(char elemento)
    {
        if (topo < array.Length)
        {
            array[topo] = elemento;
            topo++;
        }
    }

    public char Desempilhar()
    {
        if (!Vazia())
        {
            topo--;
            return array[topo];
        }
        return '\0'; // caractere nulo caso a pilha esteja vazia
    }

    public bool Vazia()
    {
        return topo == 0;
    }

    public int ObterTamanho()
    {
        return topo;
    }

    public char Topo()
    {
        return topo > 0 ? array[topo - 1] : '\0';
    }
}

class Teste
{
    static void Main(string[] args)
    {
        string entrada = Console.ReadLine();
        Pilha pilha = new Pilha();
        bool correta = true;

        foreach (char c in entrada)
        {
            if (c == '(' || c == '[')
            {
                pilha.Empilhar(c);
            }
            else if (c == ')')
            {
                if (pilha.Vazia() || pilha.Desempilhar() != '(')
                {
                    correta = false;
                    break;
                }
            }
            else if (c == ']')
            {
                if (pilha.Vazia() || pilha.Desempilhar() != '[')
                {
                    correta = false;
                    break;
                }
            }
        }

        // Ao final, a pilha também deve estar vazia para ser correta
        if (!pilha.Vazia())
            correta = false;

        Console.WriteLine(correta ? "correta" : "errada");
    }
}
