using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Напишите хеш: ");
            var hash = Console.ReadLine();
            HashKiller_API.HashKiller HashKiller = new HashKiller_API.HashKiller();
            var result = HashKiller.Get(hash);
            Console.WriteLine("Пароль: " + result.Password);
            Console.ReadLine();
        }
    }
}
