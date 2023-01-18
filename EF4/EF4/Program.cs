using System;

namespace EF4
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new AppDbContext())
            {
                foreach(var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }
            }
                Console.ReadKey();
        }
    }
}
