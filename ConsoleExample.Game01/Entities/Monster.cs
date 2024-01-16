namespace ConsoleExample.Game01.Entities
{
    internal class Monster
    {
        public bool IsDead { get; set; }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Attack { get; set; }

        public int Guard { get; set; }

        public Monster()
        {
            this.IsDead = false;
            this.Name = string.Empty;
            this.Health = 100;
            this.Attack = 0;
            this.Guard = 0;
        }
    }
}
