using System;

namespace RogueLike
{
    public interface IDamageble : IHealth 
    { 
        void ApplyDamage(int damage);
    }
}