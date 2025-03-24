using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string expressao = Console.ReadLine();

        Stack<double> pilha = new Stack<double>();

        foreach (char c in expressao)
        {
            if (char.IsDigit(c))
            {
                // Converte o caractere para número e empilha
                pilha.Push((int)char.GetNumericValue(c));
            }
            else if (c == '+' || c == '-' || c == '*' || c == '/')
            {
                // Desempilha os dois últimos operandos
                double b = pilha.Pop();
                double a = pilha.Pop();

                double resultado = 0;

                switch (c)
                {
                    case '+':
                        resultado = a + b;
                        break;
                    case '-':
                        resultado = a - b;
                        break;
                    case '*':
                        resultado = a * b;
                        break;
                    case '/':
                        if (b != 0) 
                            resultado = a / b;
                        else
                        {
                            Console.WriteLine("Erro: divisão por zero!");
                            return;
                        }
                        break;
                }

                // Empilha o resultado
                pilha.Push(resultado);
            }
        }

        // O valor final estará no topo da pilha
        if (pilha.Count == 1)
        {
            Console.WriteLine(""+ pilha.Pop());
        }
    }
}
