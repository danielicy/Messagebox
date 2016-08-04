using Reciever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.RecieverConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            RecieverHelper reciever = new RecieverHelper();
            reciever.Recieve();
        }
    }
}
