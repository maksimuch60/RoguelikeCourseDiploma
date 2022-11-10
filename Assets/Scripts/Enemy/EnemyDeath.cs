using UnityEngine;

namespace RogueLike
{
    public class EnemyDeath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyHp _enemyHp;

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
            //TODO: Off all enemy scripts and add enemy death animation;
        }

        #endregion
    }
}