using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Linq;
using System;


namespace EF2
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAll();
            Console.Write("From ID : ");
            var idFrom = Convert.ToInt32(Console.ReadLine());
            Console.Write("To ID   : ");
            var idTo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Value   : ");
            var value = Convert.ToDecimal(Console.ReadLine());
            Transaction(idFrom, idTo, value);
            Console.WriteLine();
            PrintAll();

            Console.ReadKey();
        }
        static void PrintAll()
        {
            using (var context = new AppDbContext())
            {
                foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }

            }
        }
        static void UpdateById(int id,decimal balance)
        {
            using (var context = new AppDbContext())
            {
                var wallet = context.Wallets.Single(x => x.Id == id);
                wallet.Balance = balance;
                context.SaveChanges();
            }
        }
        static void DeleteById(int id)
        {
            using (var context = new AppDbContext())
            {
                var wallet = context.Wallets.Single(x => x.Id == id);
                context.Remove(wallet);
                context.SaveChanges();
                
                context.SaveChanges();
            }
        }
        static void SelectMoreThanBalance(decimal balance)
        {
            using (var context = new AppDbContext())
            {
                var wallets = context.Wallets.Where(x => x.Balance >= balance);
                foreach (var wallet in wallets)
                {
                    Console.WriteLine(wallet);
                }
            }
        }
        static void Transaction(int idFrom ,int idTo ,decimal value)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var wallet1 = context.Wallets.Single(x => x.Id == idFrom);
                    var wallet2 = context.Wallets.Single(x => x.Id == idTo);
                    wallet1.Balance -= value;
                    wallet2.Balance += value;
                    context.SaveChanges();
                    transaction.Commit();
                }
            }
        }

    }
}
