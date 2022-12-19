using UnityEngine;
using Random = UnityEngine.Random;

namespace RogueLike
{
    public class ComplexAttack : EnemyAttack
    {
        [SerializeField] private ComplexAttackInfo[] _attacksInfo;
        private int _randomAttackIndex;
        public void ShootSpecialProjectile()
        {
            _randomAttackIndex = Random.Range(0, _attacksInfo.Length);
            _attacksInfo[_randomAttackIndex].SpecialEffectAttack.enabled = true;
        }

        public void StopShoot()
        {
            _attacksInfo[_randomAttackIndex].SpecialEffectAttack.enabled = false;
        }
    }
}