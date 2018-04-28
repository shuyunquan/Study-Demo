using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    class Log
    {
        public static void Save(string message)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("" + AppDomain.CurrentDomain.BaseDirectory + "\\log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + message + "\r");
                sw.Flush();
                sw.Close();  //数据写入log.txt
            }

        }
    }
}
