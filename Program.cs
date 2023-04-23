namespace ListaDobleEnlazada
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ListaDoblementeEnlazada<int> ld = new ListaDoblementeEnlazada<int>();
            ld.AñadeAlPrincipio(4);
            ld.AñadeAlPrincipio(3);
   
            foreach (var dato in ld)
            {
                Console.Write(dato + " ");
            }

            ld.AñadeAlFinal(6);
            ld.AñadeAlFinal(9);
            ld.AñadeAlPrincipio(3);
          

            foreach (var dato in ld)
            {
                Console.Write(dato + " ");
            }

            Console.ReadLine();
        }
    }
}
