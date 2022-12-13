using UnityEngine;

namespace RogueLike
{
    public class ShamanRunAwayBehaviour : EnemyMovement
    {
        private void Update()
        {
            if (IsTargetValid())
            {
                Debug.Log("Instantiate one of three complex attacks");
                MovementRelativeToThePlayer();
            }
        }

        internal override bool IsTargetValid()
        {
            return _target != null;
        }

        protected override void MovementRelativeToThePlayer()
        {
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            SetVelocity(-direction * _speed);
        }
    }
}