using System;
using RogueLike.Player;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLike
{
    public class SpecialEffectAttack : MonoBehaviour
    {
        [SerializeField] protected PlayerHp _playerHp;
        [SerializeField] protected Image _blindZone;
        [SerializeField] protected PlayerAnimation _playerAnimation;
        [SerializeField] protected PlayerMovement _playerMovement;
        
        private float _startFireDelay;
        protected float Timer;

        private void Awake()
        {
            BlindZoneMover blindZoneMover = FindObjectOfType<BlindZoneMover>();
            _blindZone = blindZoneMover.gameObject.GetComponent<Image>();
            _playerHp = FindObjectOfType<PlayerHp>();
            _playerAnimation = FindObjectOfType<PlayerAnimation>();
            _playerMovement = FindObjectOfType<PlayerMovement>();
        }

        protected bool CanAttack()
        {
            return Timer <= 0;
        }

        protected void TickTimer()
        {
            Timer -= Time.deltaTime;
        }
    }
}