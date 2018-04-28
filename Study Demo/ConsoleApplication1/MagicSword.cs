using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal sealed class MagicSword:IAttackStrategy
    {
        private Random random = new Random();
        public void AttackTarget(Monster monster)
        {
            int loss = (random.NextDouble() < 0.5) ? 100 : 200;
            if (loss==200)
            {
                Console.WriteLine("出现了暴击！！");
            }
            monster.Notify(loss);
        }
    }
}
