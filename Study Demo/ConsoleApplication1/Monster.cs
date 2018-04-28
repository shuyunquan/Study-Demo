using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal sealed class Monster
    {
        public string Name { get; set; }
        public int HP { get; set; }

        public Monster(string name,int hp)
        {
            this.Name=name;
            this.HP=hp;
        }

        //掉血方法
        public void Notify(int loss)
        {
            if (this.HP<=0)
            {
                Console.WriteLine("此怪物已经死亡了");
                return;
            }
            this.HP -= loss;
            if (this.HP<=0)
            {
                Console.WriteLine("怪物{0}被打死了",this.Name);
            }
            else
            {
                Console.WriteLine("怪物{0}掉了{1}滴血",this.Name,loss);
            }
 
        }
    
    

    }
}
