using ConsoleExample.Game01.Abstracts;

namespace ConsoleExample.Game01.Entities
{
    internal class Skeleton : Monster, IMonsterAction
    {
        public Skeleton() 
        {
            this.Name = "스켈레톤";
            this.IsDead = false;
            this.Health = 80;
            this.Attack = 16;
            this.Guard = 0;
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
            damage.Attack = this.Attack * 3;
            damage.Chance = 5;
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
                Console.WriteLine("스켈레톤의 죽음의 일격이다!");
                return SkillAtack();
            }
            else
            {
                Console.WriteLine("스켈레톤이 공격합니다!");
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
