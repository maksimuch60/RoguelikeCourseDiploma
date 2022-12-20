using UnityEngine;

namespace RogueLike
{
    public class FireAttack : SpecialEffectAttack

    {
        [SerializeField] private PlayerHp _playerHp;

        [SerializeField] private PlayerAnimation _playerAnimation; 

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