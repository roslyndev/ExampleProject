namespace ConsoleExample.Game01.Entities
{
    internal class User
    {
        public bool IsDead { get; set; }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Attack { get; set; }

        public int Guard { get; set; }

        public int Level { get; set; }


        public User()
        {
            this.IsDead = false;
            this.Name = string.Empty;
            this.Health = 100;
            this.Attack = 10;
            this.Guard = 1;
            this.Level = 1;
        }

        public Damage MagicFireball()
        {
            Damage damage = new Damage();
            damage.Attack = this.Attack * 3;
            damage.Chance = 10;
            return damage;
        }

        public Damage MagicArrow()
        {
            Damage damage = new Damage();
            damage.Attack = this.Attack + 5;
            damage.Chance = 60;
            return damage;
        }

        public Damage StunAttack()
        {
            Damage damage = new Damage();
            damage.Attack = this.Attack * 2;
            damage.Chance = 40;
            return damage;
        }

        public Damage NormalAttack()
        {
            Damage damage = new Damage();
            damage.Attack = this.Attack;
            damage.Chance = 100;
            return damage;
        }

        public Damage GetDamage(string num)
        {
            switch (num)
            {
                case "0":
                    Console.WriteLine("파이어볼!");
                    return MagicFireball();
                case "1":
                    Console.WriteLine("매직애로우!");
                    return MagicArrow();
                case "2":
                    Console.WriteLine("스턴공격!");
                    return StunAttack();
                default:
                    Console.WriteLine("내검을 받아라!");
                    return NormalAttack();
            }
        }

        public void SetDamage(Damage damage)
        {
            Random random = new Random();
            int randomNumber = random.Next(100);
            if (randomNumber <= damage.Chance)
            {
                Console.WriteLine("가격당했습니다!");
                this.Health = this.Health - (damage.Attack - this.Guard);
                if (this.Health < 0)
                {
                    Console.WriteLine("\"으윽....\"  당신은 쓰러집니다.");
                    this.IsDead = true;
                    this.Health = 0;
                }
            }
            else
            {
                Console.WriteLine("공격을 회피했습니다.");
            }
        }

        public void LevelUp()
        {
            Console.WriteLine("레벨업했습니다!");
            this.Level += 1;
            this.Health = 100 + (this.Level * 10);
            this.Attack += 1;
            this.Guard = ((this.Level % 2) == 0) ? this.Guard + 1 : this.Guard;
            Console.WriteLine("=========================================================");
            Console.WriteLine($" 당신의 레벨은 {this.Level} 입니다");
            Console.WriteLine($" 공격력 : {this.Attack} / 방어력 {this.Guard} / 체력 : {this.Health}");
            Console.WriteLine("=========================================================");
        }
    }
}
