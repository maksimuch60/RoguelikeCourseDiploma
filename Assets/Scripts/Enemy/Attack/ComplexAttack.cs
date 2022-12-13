using UnityEngine;

namespace RogueLike
{
    public class ComplexAttack : EnemyAttack
    {
        [SerializeField] private ComplexAttackInfo[] _attacksInfo;

        private void ShootSpecialProjectile()
        {
            //TODO: Randomize attack
        }
    }
}