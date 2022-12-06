using System;
using UnityEngine;

namespace RogueLike
{
    public class RunAway : EnemyMovement
    {
        [SerializeField] private EnemyRangeAttack _enemyAttack;

        private void Update()
        {
            if (IsTargetValid())
            {
                MoveFromTarget();
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

        protected override void MoveFromTarget()
        {
            _enemyAttack.enabled = false; 
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            SetVelocity(-direction * _speed);
        }
    }
}