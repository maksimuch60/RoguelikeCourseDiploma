using System;
using RogueLike.Animations;
using UnityEngine;

namespace RogueLike
{
    public abstract class EnemyDeath : MonoBehaviour
    {
        #region Variables

        [SerializeField] public EnemyAnimation _enemyAnimation;
        [SerializeField] protected EnemyHp _enemyHp;
        [SerializeField] protected EnemyMovement _enemyMovement;
        [SerializeField] protected Collider2D _collider2D;
        

        #endregion


        public Action<EnemyDeath> OnDead;

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