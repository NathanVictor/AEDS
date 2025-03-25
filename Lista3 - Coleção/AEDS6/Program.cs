using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        LinkedList<string> listaMusicas = new LinkedList<string>();
        
        string opcao;

        while (true)
        {
            Console.WriteLine("Op:");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    string musicaFinal = Console.ReadLine();
                    listaMusicas.AddLast(musicaFinal);
                    break;

                case "2":
                    string musicaInicio = Console.ReadLine();
                    listaMusicas.AddFirst(musicaInicio);
                    break;

                case "3":
                    string musicaNova = Console.ReadLine();
                    string musicaExistente = Console.ReadLine();
                    var nodeExistente = listaMusicas.Find(musicaExistente);

                    if (nodeExistente != null)
                    {
                        listaMusicas.AddAfter(nodeExistente, musicaNova);
                    }
                    break;

                case "4":
                    if (listaMusicas.First != null)
                    {
                        listaMusicas.RemoveFirst();
                    }
                    break;

                case "5":
                    if (listaMusicas.Last != null)
                    {
                        listaMusicas.RemoveLast();
                    }
                    break;

                case "6":
                    string musicaRemover = Console.ReadLine();
                    if (listaMusicas.Contains(musicaRemover))
                    {
                        listaMusicas.Remove(musicaRemover);
                    }
                    break;

                case "7":
                    foreach (var musica in listaMusicas)
                    {
                        Console.WriteLine(musica);
                    }
                    break;

                case "8":
                    string musicaPesquisar = Console.ReadLine();
                    if (listaMusicas.Contains(musicaPesquisar))
                    {
                        Console.WriteLine("sim");
                    }
                    else
                    {
                        Console.WriteLine("não");
                    }
                    break;

                case "9":
                    return;

                default:
                    break;
            }
        }
    }
}
