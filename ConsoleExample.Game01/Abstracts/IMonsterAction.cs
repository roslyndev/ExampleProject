using ConsoleExample.Game01.Entities;

namespace ConsoleExample.Game01.Abstracts
{
    internal interface IMonsterAction
    {
        Damage GetDamage();

        void SetDamage(Damage damage);

        string GetName();

        bool IsStatus();

        int GetHealth();
    }
}
