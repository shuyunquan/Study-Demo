using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 写日志
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = "蜀云泉帅?";
            string s = $"许嵩帅还是{name}";
            Console.WriteLine(s);




            Log.Save("大家好，我是Vae");
            Console.WriteLine("成功啦");
            Console.ReadLine();
        }
    }
}
