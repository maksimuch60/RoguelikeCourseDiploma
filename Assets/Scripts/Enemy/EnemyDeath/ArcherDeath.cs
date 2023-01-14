using UnityEngine;

namespace RogueLike
{
    public class ArcherDeath : EnemyDeath
    {
        [SerializeField] private GameObject[] _archerCosmetics; 
        protected override void OnHpChanged(int hp)
        {
            if (IsDead || hp > 0)
                return;
            
            OnDead?.Invoke(this);
            IsDead = true;
            _enemyAnimation.PlayDeath();
            _enemyHp.enabled = false;
            _enemyMovement.enabled = false;
            foreach (GameObject archerCosmetic in _archerCosmetics)
                Destroy(archerCosmetic);
            _collider2D.enabled = false;
        }
    }
}