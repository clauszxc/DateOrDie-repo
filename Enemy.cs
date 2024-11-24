using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DateOrDie
{
    public class Enemy : Unit
    {
        Random rnd = new Random();

        public string Type { get; set; }
        public string ImmuneTo { get; set; }
        public string VulnerableTo { get; set; }

        //public Enemy(string name, int hitPoints, int attackPower, string type, string immuneTo, string vulnerableTo)
        //{
        //    Name = name;
        //    HitPoints = hitPoints;
        //    AttackPower = attackPower;
        //    Type = type;
        //    ImmuneTo = immuneTo;
        //    VulnerableTo = vulnerableTo;
        //}

        public Enemy(int level)
        {
            Name = GenerateEnemyName();
            Type = GenerateEnemyType();

            HitPoints = 25 + (level * 20);
            AttackPower = 3 + (level * 5);

            if (Type == "Goth Girl")
            {
                ImmuneTo = "Lover Boy Blast";
                VulnerableTo = "Bad Boy Beam";
            }
            else if (Type == "Basic Bitch")
            {
                ImmuneTo = "Lover Boy Blast";
                VulnerableTo = "Rizz Raygun";
            }
            else if (Type == "Sweetie")
            {
                ImmuneTo = "Bad Boy Beam";
                VulnerableTo = "Lover Boy Blast";
            }
        }

        private string GenerateEnemyName()
        {
            var names = new List<string> { "Amalie", "Stephanie", "Maja"};
            return names[rnd.Next(names.Count)];
        }
        private string GenerateEnemyType()
        {
            var names = new List<string> { "Goth Girl", "Basic Bitch", "Sweetie" };
            return names[rnd.Next(names.Count)];
        }
        public override void TakeDamage(int damageAmount)
        {
            HitPoints -= damageAmount;
        }
    }
}
