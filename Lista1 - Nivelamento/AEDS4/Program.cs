class Program
{
    static void Main()
    {
        Console.WriteLine("Quantidade de candidatos:");
        int Resultado = int.Parse(Console.ReadLine());

        string[] candidatos = new string[Resultado];
        int[] votos = new int[Resultado];

        for (int i = 0; i < Resultado; i++)
        {
            Console.WriteLine($"Informe o nome do {i}º candidato:");
            candidatos[i] = Console.ReadLine();
        }

        Console.WriteLine("Quantidade de eleitores:");
        int eleitores = int.Parse(Console.ReadLine());

        int votosNulos = 0;

        for (int i = 0; i < eleitores; i++)
        {

            Console.WriteLine($"Vote digitando o número do candidato (1 a {Resultado}), ou 0 para nulo:");
            int voto = int.Parse(Console.ReadLine());

            if (voto > 0 && voto <= Resultado)
            {
                votos[voto - 1]++;
            }
            else
            {
                votosNulos++;
            }
        }

        int minVotos = int.MaxValue;
        int maxVotos = 0;
        int indiceMax = 0;
        int indiceMin = 0;

        for (int i = 0; i < Resultado; i++)
        {
            if (votos[i] > maxVotos)
            {
               maxVotos = maxVotos = votos[i];
                indiceMax = i;
            }
            if (votos[i] < minVotos && votos[i] > 0)
            {
                minVotos = votos[i];
                indiceMin = i;
            }
        }
        
        Console.WriteLine($"Candidato mais votado: {candidatos[indiceMax]} com {maxVotos} votos.");
        Console.WriteLine($"Candidato menos votado: {candidatos[indiceMin]} com {minVotos} votos.");
        Console.WriteLine($"Votos nulos: {votosNulos}");
    }
}
