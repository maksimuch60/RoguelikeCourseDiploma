using UnityEngine;

namespace RogueLike
{
    public class ShamanDeath : EnemyDeath
    {
        [SerializeField] private GameObject _unsafeZone;
        [SerializeField] private EnemyAttack _complexAttack;
        [SerializeField] private Collider2D _shamanModel; 
        
        protected override void OnHpChanged(int hp)
        {
            if (IsDead || hp > 0)
                return;
            _shamanModel.enabled = false; 
            _complexAttack.enabled = false; 
            _enemyAttack.enabled = false; 
            _enemyHp.enabled = false;
            _enemyMovement.enabled = false;
            _unsafeZone.SetActive(false);
        }
    }
}