using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite o valor desejado:");
        int n = int.Parse(Console.ReadLine());

        int num = 1; 

        for (int i = 1; i <= n; i++) 
        {
            for (int j = 1; j <= i; j++) 
            {
                Console.Write(num + " ");
                num++; 
            }
            Console.WriteLine();
        }
    }
}

