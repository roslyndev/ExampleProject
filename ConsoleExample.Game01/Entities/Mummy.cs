using ConsoleExample.Game01.Abstracts;

namespace ConsoleExample.Game01.Entities
{
    internal class Mummy : Monster, IMonsterAction
    {
        public Mummy()
        {
            this.Name = "미이라";
            this.IsDead = false;
            this.Health = 120;
            this.Attack = 10;
            this.Guard = 2;
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
            damage.Attack = this.Attack * 2;
            damage.Chance = 10;
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
                Console.WriteLine("미이라의 다중 붕대공격이다!");
                return SkillAtack();
            }
            else
            {
                Console.WriteLine("미이라가 공격합니다!");
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
