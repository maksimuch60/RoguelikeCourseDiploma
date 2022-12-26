using UnityEngine;

namespace RogueLike
{
    public class ShamanDeath : EnemyDeath
    {
        [SerializeField] private Collider2D _shamanModel;
        [SerializeField] private GameObject[] _shamanCosmetics;

        protected override void OnHpChanged(int hp)
        {
            if (IsDead || hp > 0)
                return;
            _shamanModel.enabled = false;
            _enemyHp.enabled = false;
            _enemyMovement.enabled = false;
            _enemyAnimation.PlayDeath();
            foreach (GameObject shamanCosmetic in _shamanCosmetics)
                Destroy(shamanCosmetic);
        }
    }
}