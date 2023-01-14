using System;
using UnityEngine;

namespace RogueLike
{
    public class FireAttack : SpecialEffectAttack
    {
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
                _playerAnimation.Fire();
            }
        }
        
        private void ApplyDamage(int damage)
        {
            _playerHp.ApplyDamage(damage);
        }
    }
}