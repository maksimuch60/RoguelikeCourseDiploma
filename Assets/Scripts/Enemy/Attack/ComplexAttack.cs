using UnityEngine;

namespace RogueLike
{
    public class ComplexAttack : EnemyAttack
    {
        [SerializeField] private ComplexAttackInfo[] _attacksInfo;
        public void ShootSpecialProjectile()
        {
           _attacksInfo[0].Attack.enabled = true;
        }

        public void StopShoot()
        {
            _attacksInfo[0].Attack.enabled = false; 
        }
    }
}