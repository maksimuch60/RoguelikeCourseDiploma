using System;
using UnityEngine;

namespace RogueLike
{
    public class FireAttack : SpecialEffectAttack

    {
        [SerializeField] private PlayerHp _playerHp;

        private int _damage = 3;

        private void Update()
        {
            TickTimer();
        }

        private void OnEnable()
        {
            if (CanAttack())
            {
                ApplyDamage(_damage);   
            }
        }
        
        private void ApplyDamage(int damage)
        {
            _playerHp.ApplyDamage(damage);
        }
    }
}