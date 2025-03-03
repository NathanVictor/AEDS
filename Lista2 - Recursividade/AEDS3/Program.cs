using System;
class Program
{
    public static void converterBinario(int n)
    {

        if (n == 1)
        {
            Console.Write(1);
        }
        else
        {
            converterBinario(n / 2);
            Console.Write(n % 2);

        }
    }
    public static void Main()
    {
        int valor = 12;
        converterBinario(valor);

    }
}
