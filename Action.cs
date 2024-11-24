using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOrDie
{
    public static class Action
    {
        public static int PlayerRegularAttack(Player player, Enemy enemy)
        {
            enemy.HitPoints -= player.AttackPower;

            return enemy.HitPoints;
        }

        public static (string result, int updatedHitPoints) PlayerSpecialAttack(Player player, Enemy enemy)
        {
            int damageMultiplier = 1;

            string result;

            if (enemy.VulnerableTo == player.SpecialAttack)
            {
                damageMultiplier = 2; // double damage
                result = "Critical hit!";
            }
            else if (enemy.ImmuneTo == player.SpecialAttack)
            {
                damageMultiplier = 0;
                result = "The enemy is immune!";
            }
            else
            {
                result = "Regular hit!";
            }

            int specialAttackDamage = player.AttackPower * damageMultiplier;

            enemy.HitPoints -= specialAttackDamage;

            //return enemy.HitPoints;
            return (result, enemy.HitPoints);
        }
    }
}
