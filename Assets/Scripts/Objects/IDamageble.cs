using System;

namespace RogueLike
{
    public interface IDamageble
    {
        event Action<int> OnChanged;

        int CurrentHp { get; }
        int MaxHp { get; }

        void ApplyDamage(int damage);
    }
}