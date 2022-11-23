using UnityEngine;

namespace RogueLike
{
    public class EnemyMeleeMovement : EnemyMovement
    {
        internal override bool IsTargetValid()
        {
            return _target != null;
        }

        protected override void MoveToTarget()
        {
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            SetVelocity(direction * _speed);
        }
    }
}