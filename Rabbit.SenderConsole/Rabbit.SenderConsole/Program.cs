using Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.SenderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SendHelper sender = new SendHelper();
            do
            {
                Console.WriteLine("Enter something:\n");

                sender.SendMessage(Console.ReadLine());
            }
            while (Console.ReadLine() != "0");
        }
    }
}
