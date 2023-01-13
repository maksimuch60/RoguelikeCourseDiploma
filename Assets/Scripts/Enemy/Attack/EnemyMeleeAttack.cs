using RogueLike.Animations;
using UnityEngine;

namespace RogueLike
{
    public class EnemyMeleeAttack : EnemyAttack
    {
        [SerializeField] private EnemyAnimation _animation;
        private float _fireDelay = 0.7f;
        
        [SerializeField] protected Transform _attackPoint;
        [SerializeField] protected float _radius;
        [SerializeField] protected LayerMask _layerMask;

        private void Update()
        {
            TickTimer();

            if (CanAttack())
                PerformDamage();
        }

        private void PerformDamage()
        {
            Timer = _fireDelay;
            Collider2D col = Physics2D.OverlapCircle(_attackPoint.position, _radius, _layerMask);
            if (col == null)
            {
                _animation.StopPlayAttack();
                return;
            }

            if (_playerHp != null)
            {
                _playerHp.ApplyDamage(_damage);
                _animation.StartPlayAttack();
            }
        }
    }
}