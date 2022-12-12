using UnityEngine;

namespace RogueLike
{
    public class ArcherRunAwayBehaviour : EnemyMovement
    {
        [SerializeField] private EnemyRangeAttack _enemyAttack;

        private void Update()
        {
            if (IsTargetValid())
            {
                MovementRelativeToThePlayer();
            }
            else
            {
                _enemyAttack.enabled = true; 
            }
        }

        internal override bool IsTargetValid()  
        {
            return _target != null;
        }

        protected override void MovementRelativeToThePlayer()
        {
            _enemyAttack.enabled = false; 
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            SetVelocity(-direction * _speed);
        }
    }
}