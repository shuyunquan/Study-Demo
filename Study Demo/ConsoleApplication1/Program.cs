using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //生成怪物
            #region MyRegion
            //Monster monster1 = new Monster("小怪1",50);
            //Monster monster2 = new Monster("小怪2", 50);
            //Monster monster3 = new Monster("门主", 200);
            //Monster monster4 = new Monster("Boss", 1000);

            ////生成角色
            //Role role = new Role();

            ////木剑攻击
            //role.Weapon = new WoodSword();
            //role.Attack(monster1);

            ////铁剑攻击
            //role.Weapon = new IronSword();
            //role.Attack(monster2);
            //role.Attack(monster3);

            ////魔剑攻击
            //role.Weapon = new MagicSword();
            //role.Attack(monster3);
            //role.Attack(monster4);
            //role.Attack(monster4);
            //role.Attack(monster4);
            //role.Attack(monster4);
            //role.Attack(monster4); 
            #endregion


            IKernel IOC = new StandardKernel();



            Console.ReadLine();
        }
    }
}
 