using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        List<double> maratonista = new List<double>();

        while (true)
        {
            Console.WriteLine("Op:");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    // Inserir um tempo no início da lista
                    double inicio = double.Parse(Console.ReadLine());
                    maratonista.Insert(0, inicio);
                    break;

                case 2:
                    // Inserir um tempo no final da lista
                    double final = double.Parse(Console.ReadLine());
                    maratonista.Add(final);
                    break;

                case 3:
                    // Inserir um tempo numa posição específica
                    double tempo = double.Parse(Console.ReadLine());
                    int index = int.Parse(Console.ReadLine());

                    if (index >= 0 && index <= maratonista.Count)
                    {
                        maratonista.Insert(index, tempo);
                    }
                    break;

                case 4:
                    // Remover o primeiro tempo da lista
                    if (maratonista.Count > 0)
                    {
                        double removidoInicio = maratonista[0];
                        maratonista.RemoveAt(0);
                        Console.WriteLine(removidoInicio);
                    }
                    break;

                case 5:
                    // Remover o último tempo da lista
                    if (maratonista.Count > 0)
                    {
                        double removidoFinal = maratonista[maratonista.Count - 1];
                        maratonista.RemoveAt(maratonista.Count - 1);
                        Console.WriteLine(removidoFinal);
                    }
                    break;

                case 6:
                    
                    break;

                case 7:
                 
                    break;

                case 8:
                  
                    break;

                case 9:
                 
                    break;

                case 10:
                
                    break;

                case 11:
               
                    break;

                case 12:
                    
                    return;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}
