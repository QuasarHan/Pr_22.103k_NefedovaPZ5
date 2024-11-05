using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashPasswords;
namespace Pr_22._103k_NefedovaPZ5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите логин: ");
            string login = Console.ReadLine();
            Console.WriteLine("Напишите пароль");
            string password = Console.ReadLine();

            Helper helper = new Helper();
            helper.Users(login, password);

            Console.WriteLine("Логин: " + login);
        }
    }
}
