using UnityEngine;

namespace RogueLike
{
    public class EnemyMeleeAttack : EnemyAttack
    {
        [SerializeField] private int _damage; 
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;

        private void Update()
        {
            Attack();
        }

        private void PerformDamage()
        {
            Collider2D col = Physics2D.OverlapCircle(_attackPoint.position, _radius, _layerMask);
            if (col == null)
                return;

            PlayerHp playerHp = col.GetComponentInParent<PlayerHp>();
            if (playerHp != null)
                playerHp.ApplyDamage(_damage);
        }
        
        private void Attack()
        {
            if (CanAttack())
                PerformDamage();
            Debug.Log("Now attack");
        }

        private bool CanAttack()
        {
            return _timer <= 0;
        }

    }
}