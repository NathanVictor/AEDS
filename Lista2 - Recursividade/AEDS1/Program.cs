class Program
{
    public static int Recursividade(int a, int n)
    {
        int resp;

        if (n == 0)
        {
            resp = 1;
        }
        else
        {
            resp = a * Recursividade(a, n - 1);
        }

        return resp;
    }

    public static void Main()
    {
        int valor = Recursividade(2, 3);
        Console.WriteLine(valor);
    }
}