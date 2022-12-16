using UnityEngine;

namespace RogueLike
{
    public class EnemyDeath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyHp _enemyHp;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyAttack _enemyAttack; 

        #endregion


        #region Properties

        private bool IsDead { get; set; }

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _enemyHp.OnChanged += OnHpChanged; 
        }

        #endregion


        #region Private methods

        private void OnHpChanged(int hp)
        {
            if (IsDead || hp > 0)
                return;
            Debug.Log($"Enemy is dead: {IsDead}");
            _enemyAttack.enabled = false;
            _enemyHp.enabled = false;
            _enemyMovement.enabled = false;
        }

        #endregion
    }
}