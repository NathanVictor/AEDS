class Program
{
    public static int Maximo(int x, int y)
    {

        if (x >= y)
        {
            return = x;
        }
        else
        {
            return = Maximo(x - y, y);
        }
        else
        {
            return Maximo(y, x)
        }

    }


    static void Main(string[] args)
    {
        int valor1 = 10;
        int valor2 = 6;

        Console.WriteLine(Maximo(valor1, valor2));
    }
}
