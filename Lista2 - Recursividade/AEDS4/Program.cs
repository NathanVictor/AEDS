using System;

class Program
{
    public static int MDC(int x, int y)
    {

        if (x == y)
        {
            return x;
        }
        else if (x > y)
        {
            return MDC(x - y, y);
        }
        else
        {
            return MDC(y, x);
        }

    }


    static void Main(string[] args)
    {
        int valor1 = 10;
        int valor2 = 6;

        Console.WriteLine("O MDC de " + valor1 + " e " + valor2 + " é: " + MDC(valor1, valor2));
    }
}
