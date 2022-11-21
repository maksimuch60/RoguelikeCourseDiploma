using UnityEngine;

namespace RogueLike
{
    public class EnemyBullet : Bullet
    {
        protected void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                col.gameObject.GetComponent<PlayerHp>().ApplyDamage(Damage);
            }
        }
    }
}