using RogueLike.Animations;
using UnityEngine;

namespace RogueLike
{
    public class EnemyMeleeAttack : EnemyAttack
    {
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private int _damage;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;
        private float _fireDelay = 0.7f;

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
            
            PlayerHp playerHp = col.GetComponentInParent<PlayerHp>();
            if (playerHp != null)
            {
                playerHp.ApplyDamage(_damage);
                _animation.StartPlayAttack();
            }
        }
    }
}