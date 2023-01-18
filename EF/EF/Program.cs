using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAllWithDapper();
            Console.Write("name    :");
            var holder = Console.ReadLine();
            Console.Write("balance :");

            var balance =Convert.ToDecimal( Console.ReadLine());
            InsertWallet(holder, balance);
            PrintAll();


            Console.ReadKey();
        }
        static void PrintAll()
        {
            var configrtion = new ConfigurationBuilder().AddJsonFile("Appsetting.json").Build();
            SqlConnection conn = new SqlConnection(configrtion.GetSection("constr").Value);
            string sql = "select*from wallets";
            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            Wallet wallat;
            while (reader.Read())
            {
                wallat = new Wallet
                {
                    Id = reader.GetInt32(0),
                    Holder = reader.GetString(1),
                    Balance = reader.GetDecimal(2)
                };
                Console.WriteLine(wallat);
            }
            conn.Close();
        }
        static void InsertWallet(string holder, decimal balance)
        {
            Wallet wallet = new Wallet
            {
                Holder = holder,
                Balance = balance
            };
            var configrtion = new ConfigurationBuilder().AddJsonFile("Appsetting.json").Build();
            SqlConnection conn = new SqlConnection(configrtion.GetSection("constr").Value);
            var sql = "insert into wallets(holder,balance) values " 
                + $"(@holder,@balance);"
                +$"select cast(SCOPE_IDENTITY() as int)";
            SqlParameter holderParameter = new SqlParameter
            {
                ParameterName = "@holder",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = wallet.Holder
            };
            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@balance",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                Value = wallet.Balance
            };
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(holderParameter);
            command.Parameters.Add(balanceParameter);
            conn.Open();
            wallet.Id = (int)command.ExecuteScalar();
            Console.WriteLine("---------------------\nsuccessfully inserted\n---------------------");

            conn.Close();
            Console.WriteLine(wallet+ "\n---------------------");
    }
        static void InsertWalletByStoredProcedure(string holder, decimal balance)
        {
            Wallet wallet = new Wallet
            {
                Holder = holder,
                Balance = balance
            };
            var configrtion = new ConfigurationBuilder().AddJsonFile("Appsetting.json").Build();
            SqlConnection conn = new SqlConnection(configrtion.GetSection("constr").Value);
            SqlParameter holderParameter = new SqlParameter
            {
                ParameterName = "@holder",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = wallet.Holder
            };
            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@balance",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                Value = wallet.Balance
            };
            SqlCommand command = new SqlCommand("addwallet", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(holderParameter);
            command.Parameters.Add(balanceParameter);
            conn.Open();
            wallet.Id = (int)command.ExecuteScalar();
            Console.WriteLine("---------------------\nsuccessfully inserted\n---------------------");

            conn.Close();
            Console.WriteLine(wallet + "\n---------------------");
        }
        static void PrintAllWithDapper()
        {
            var configration = new ConfigurationBuilder().AddJsonFile("AppSetting.json").Build();
            IDbConnection db = new SqlConnection(configration.GetSection("constr").Value);
            string sql = "select*from wallets";
            var wallets = db.Query<Wallet>(sql);
            foreach(var wallet in wallets)
            {
                Console.WriteLine(wallet);
            }
        }
    }
}
