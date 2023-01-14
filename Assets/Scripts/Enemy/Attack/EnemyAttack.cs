using System;
using UnityEngine;

namespace RogueLike
{
    public abstract class EnemyAttack : MonoBehaviour
    {
        private float _startFireDelay;
        protected float Timer;
        [SerializeField] protected PlayerHp _playerHp; 
        [SerializeField] protected int _damage;

        private void Start()
        {
            _playerHp = FindObjectOfType<PlayerHp>();
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