using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMail
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMail a = new SendMail();
            a.SendMailUseGmail();

            Console.ReadLine();
        }



    }
}
