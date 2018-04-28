using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal sealed class IronSword:IAttackStrategy
    {
        public void AttackTarget(Monster monster)
        {
            //铁剑的伤害值是50
            monster.Notify(50);
        }
    }
}
