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
                Debug.Log("Enemy Hp -- ");
                Destroy(gameObject);
            }
            else if (col.gameObject.CompareTag("EnemyShield"))
            {
                col.gameObject.GetComponentInParent<Shield>().ApplyDamage(Damage);
                Destroy(gameObject);
                Debug.Log("Shield HP --");
            }
        }
    }
}