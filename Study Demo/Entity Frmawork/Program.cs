using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Frmawork
{
    class Program
    {
        static void Main(string[] args)
        {

            //学习entity frmawork，在新建数据库表的时候，一定要设置主键，否则edmx不会有数据！！！
            shuyunquanEntities my=new shuyunquanEntities();
            //linq查询语句
            //var list = from a in my.UserInfoes
            //           select a;
            //方法查询
            var list = my.UserInfoes.Select(i=>i);

            foreach (var item in list)
            {
                Console.WriteLine("ID:{0}  Name：{1}",item.userID,item.userName);
            }

            Console.ReadLine();

        }
    }
}
