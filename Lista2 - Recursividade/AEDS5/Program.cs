class Program
{
    public static int Menor(int[] x, int n)
    {
        
        if (n == 0)
        {
            return 0;
        }
        else
        {
            
            int count = (x[n - 1] < 0) * 1; 

           
            return count + Menor(x, n - 1);
        }
    }

    public static void Main(string[] args)
    {
        int[] array = {1, 2, 3, 4, 5};
        int n = array.Length;

        Console.WriteLine(Menor(array, n));  
    }
}
