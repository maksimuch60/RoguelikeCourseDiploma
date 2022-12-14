using UnityEngine;

namespace RogueLike
{
    public class ShamanRunAwayBehaviour : EnemyMovement
    {
        [SerializeField] private ComplexAttack _complexAttack; 
        private void Update()
        {
            if (IsTargetValid())
            {
                _complexAttack.ShootSpecialProjectile();
                Debug.Log("Instantiate one of three complex attacks");
                MovementRelativeToThePlayer();
            }
            else
            {
                _complexAttack.StopShoot();
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