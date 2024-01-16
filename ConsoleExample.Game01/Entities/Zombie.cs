using ConsoleExample.Game01.Abstracts;

namespace ConsoleExample.Game01.Entities
{
    internal class Zombie : Monster, IMonsterAction
    {
        public Zombie()
        {
            this.Name = "좀비";
            this.IsDead = false;
            this.Health = 50;
            this.Attack = 8;
            this.Guard = 1;
        }

        public string GetName()
        {
            return this.Name;
        }


        public bool IsStatus()
        {
            return this.IsDead;
        }

        public int GetHealth()
        {
            return this.Health;
        }

        public Damage SkillAtack()
        {
            Damage damage = new Damage();
            damage.Attack = this.Attack + 5;
            damage.Chance = 20;
            return damage;
        }

        public Damage NormalAttack()
        {
            Damage damage = new Damage();
            damage.Attack = this.Attack;
            damage.Chance = 100;
            return damage;
        }

        public Damage GetDamage()
        {
            Random random = new Random();
            int randomNumber = random.Next(2);
            if (randomNumber == 0)
            {
                Console.WriteLine("좀비의 물어뜯기 공격이다!");
                return SkillAtack();
            }
            else
            {
                Console.WriteLine("좀비가 공격합니다!");
                return NormalAttack();
            }
        }

        public void SetDamage(Damage damage)
        {
            Random random = new Random();
            int randomNumber = random.Next(100);
            if (randomNumber <= damage.Chance)
            {
                Console.WriteLine("적중했습니다!");
                this.Health = this.Health - (damage.Attack - this.Guard);
                if (this.Health <= 0)
                {
                    Console.WriteLine("몬스터가 소멸됩니다.");
                    this.IsDead = true;
                    this.Health = 0;
                }
            }
            else
            {
                Console.WriteLine("공격이 빗나갔습니다.");
            }
        }
    }
}
