using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<string> filaDeAviões = new Queue<string>();
        bool continuar = true;

        while (continuar)
        {
            // Exibe o prompt "Op:" antes de cada entrada
            Console.WriteLine("Op:");
            
            // Lê a opção do usuário
            int opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    // Exibe a quantidade de aviões na fila
                    Console.WriteLine(filaDeAviões.Count);
                    break;

                case 2:
                    // Autoriza a decolagem do primeiro avião da fila
                    if (filaDeAviões.Count > 0)
                    {
                        Console.WriteLine(filaDeAviões.Dequeue());
                    }
                    break;

                case 3:
                    // Adiciona um avião à fila
                    string avião = Console.ReadLine();
                    filaDeAviões.Enqueue(avião);
                    break;

                case 4:
                    // Lista todos os aviões na fila
                    foreach (var a in filaDeAviões)
                    {
                        Console.WriteLine(a);
                    }
                    break;

                case 5:
                    // Exibe o primeiro avião na fila
                    if (filaDeAviões.Count > 0)
                    {
                        Console.WriteLine(filaDeAviões.Peek());
                    }
                    break;

                case 6:
                    // Encerra o programa
                    continuar = false;
                    break;
            }
        }
    }
}
