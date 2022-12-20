﻿using RogueLike.Player;
using UnityEngine;

namespace RogueLike
{
    public class PlayerDeath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerHp _playerHp;
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField] private PlayerMovement _playerMovement; 

        #endregion


        #region Properties

        public bool IsDead { get; private set; }

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _playerHp.OnChanged += OnHpChanged; 
        }

        #endregion


        #region Private methods

        private void OnHpChanged(int hp)
        {
            if (IsDead || hp > 0)
                return;

            IsDead = true;
            Debug.Log("Player died");
            _playerAnimation.PlayDeath();
            _playerMovement.enabled = false;
            _playerAttack.enabled = false; 
        }

        #endregion
    }
}