using UnityEngine;

namespace RogueLike
{
    public class PlayerBullet : Bullet
    {
        protected void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.gameObject.GetComponentInParent<EnemyHp>().ApplyDamage(Damage);
            }
        }
    }
}