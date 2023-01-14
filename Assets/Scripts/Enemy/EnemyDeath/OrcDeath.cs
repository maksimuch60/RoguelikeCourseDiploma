using UnityEngine;

namespace RogueLike
{
    public class OrcDeath : EnemyDeath
    {
        [SerializeField] private GameObject[] _orcCosmetics;

        protected override void OnHpChanged(int hp)
        {
            if (IsDead || hp > 0)
                return;
            
            OnDead?.Invoke(this);
            IsDead = true;
            _enemyHp.enabled = false;
            _enemyMovement.enabled = false;
            _enemyAnimation.PlayDeath();
            foreach (GameObject orcCosmetic in _orcCosmetics)
                Destroy(orcCosmetic);
            _collider2D.enabled = false;
        }
    }
}