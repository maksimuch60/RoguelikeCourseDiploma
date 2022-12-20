using UnityEngine;

namespace RogueLike
{
    public abstract class EnemyDeath : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected EnemyHp _enemyHp;
        [SerializeField] protected EnemyMovement _enemyMovement;
        [SerializeField] protected EnemyAttack _enemyAttack;
        
        #endregion


        #region Properties

        protected bool IsDead { get; set; }

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _enemyHp.OnChanged += OnHpChanged; 
        }

        #endregion


        #region Private methods

        protected abstract void OnHpChanged(int hp); 

        #endregion
    }
}