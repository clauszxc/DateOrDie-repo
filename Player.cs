using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOrDie
{
    public class Player : Unit
    {
        public int Level { get; set; }
        public string SpecialAttack { get; set; }
        public int XPToLevel { get; set; }
        public Player(string name, int level, int hitPoints, int attackPower, string specialAttack, int xPToLevel)
        {
            Name = name;
            Level = level;
            HitPoints = hitPoints;
            AttackPower = attackPower;
            SpecialAttack = specialAttack;
            XPToLevel = xPToLevel;
        }
        public void PlayerLevelUp()
        {
            Level += 1;
            HitPoints += 25;
            AttackPower += 10;
            XPToLevel -= 100;
        }

        public override void TakeDamage(int damageAmount)
        {
            HitPoints -= damageAmount;
        }
    }
}
