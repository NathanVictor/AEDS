using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string sequencia = Console.ReadLine();
        Stack <char> pilha = new Stack <char>();
        bool correta = true;

        foreach (char c in sequencia)
        {
            if (c == '(' || c == '[')
            {
                pilha.Push(c);
            }
            else if (c == ')')
            {
                if (pilha.Count == 0 || pilha.Pop() != '(')
                {
                    correta = false;
                    break;
                }
            }
            else if (c == ']')
            {
                if (pilha.Count == 0 || pilha.Pop() != '[')
                {
                    correta = false;
                    break;
                }
            }
        }

        if (pilha.Count > 0)
        {
            correta = false;
        }

        Console.WriteLine(correta ? "correta" : "errada");
    }
}
