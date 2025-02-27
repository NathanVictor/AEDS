class Program
{
    public static int Valor(int m, int n){

        int resp;

        if(m == n){
            resp = m;

        }else{
            resp = m + Valor(m + 1, n);
        }

        return resp;
    }
    public static void Main()
    {
        int valor = Valor(0,3);

        Console.WriteLine(valor);
    
    }
}
