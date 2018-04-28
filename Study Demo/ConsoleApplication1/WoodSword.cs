using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal sealed class WoodSword:IAttackStrategy
    {
        public void AttackTarget(Monster monster)
        {
            //木剑伤害值是20
            monster.Notify(20);
        }
    }
}
