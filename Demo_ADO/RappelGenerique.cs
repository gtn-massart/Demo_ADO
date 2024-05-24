using Demo_ADO.Models;

namespace Demo_ADO
{
    internal class RappelGenerique<T> where T : Pokemon
    {
        public void execute(T truc)
        {
            Console.WriteLine(truc);
        }
    }
}
