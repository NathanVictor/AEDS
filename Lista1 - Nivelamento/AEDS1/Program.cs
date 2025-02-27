
class Program
{
    static void Main()
    {
        int contagemAtual = 0;
        int maiorSequencia = 0;
        int numeroAnterior = -1;

        Console.WriteLine("Digite uma sequência de números inteiros positivos (digite -1 para terminar):");

        while (true)
        {

            string sc = Console.ReadLine(); int numeroAtual;

            try
            {
                numeroAtual = Convert.ToInt32(sc); 
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, insira um número válido.");
                continue;
            }

            if (numeroAtual == -1) 
            {
                break; 
            }
            if (numeroAtual > numeroAnterior && numeroAnterior != -1)
            {
                contagemAtual++;
            }
            else
            {
                if (contagemAtual > maiorSequencia)
                {

                    maiorSequencia = contagemAtual;
                }
                contagemAtual = 1;
            }
            numeroAnterior = numeroAtual;
        }
        if (contagemAtual > maiorSequencia)
        {
            maiorSequencia = contagemAtual;
        }

        Console.WriteLine($"O tamanho da maior sequência crescente é: {maiorSequencia}");
    }
}
