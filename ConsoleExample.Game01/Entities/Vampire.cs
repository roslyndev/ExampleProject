using ConsoleExample.Game01.Abstracts;

namespace ConsoleExample.Game01.Entities
{
    internal class Vampire : Monster, IMonsterAction
    {
        public Vampire()
        {
            this.Name = "뱀파이어";
            this.IsDead = false;
            this.Health = 400;
            this.Attack = 20;
            this.Guard = 5;
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

        public Damage AttackOfBats()
        {
            Damage damage = new Damage();
            damage.Attack = this.Attack * 3;
            damage.Chance = 20;
            return damage;
        }

        public Damage AttackTeeth()
        {
            Damage damage = new Damage();
            damage.Attack = this.Attack * 4;
            damage.Chance = 10;
            return damage;
        }

        public Damage ShadowStepping()
        {
            Damage damage = new Damage();
            damage.Attack = this.Attack * 2;
            damage.Chance = 30;
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
            int randomNumber = random.Next(4);
            switch (randomNumber)
            {
                case 0:
                    Console.WriteLine("박쥐들의 습격!");
                    return AttackOfBats();
                case 1:
                    Console.WriteLine("날카로운 이빨공격!");
                    return AttackTeeth();
                case 2:
                    Console.WriteLine("그립자밟기!");
                    return ShadowStepping();
                default:
                    Console.WriteLine("공격!");
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
