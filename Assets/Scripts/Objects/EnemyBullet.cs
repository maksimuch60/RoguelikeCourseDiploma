using UnityEngine;

namespace RogueLike
{
    public class EnemyBullet : Bullet
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                col.gameObject.GetComponentInParent<PlayerHp>().ApplyDamage(Damage);
            }
        }


    }
}