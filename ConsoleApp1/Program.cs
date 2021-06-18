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
            HashKiller_API.HashKiller HashKiller = new HashKiller_API.HashKiller();
            var result = HashKiller.Get("$SHA$1881e3a008fafebc$b172d621b71cb6b2858043b6d83b231c43df65009326722afae1431a0a6e3022");
            Console.WriteLine("Пароль: " + result.Password);
            Console.ReadLine();
        }
    }
}
