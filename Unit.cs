using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOrDie
{
    public class Unit
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int AttackPower { get; set; }

        public virtual void TakeDamage(int damageAmount)
        {
            HitPoints -= damageAmount;
        }
    }

}
