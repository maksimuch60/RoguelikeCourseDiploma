using System;
using UnityEngine;

namespace RogueLike
{
    public class PlayerHp : MonoBehaviour, IHeal
    {
        [SerializeField] private int _startHp;
        [SerializeField] private int _maxHp;
        [SerializeField] private HealthBar _healthBar; 
        public event Action<int> OnChanged;
        public int CurrentHp { get; private set; }
        public int MaxHp => _maxHp;

        private void Awake()
        {
            CurrentHp = _startHp;
            _healthBar.SetMaxHealth(MaxHp);
            OnChanged?.Invoke(CurrentHp);
        }

        public void ApplyDamage(int damage)
        {
            CurrentHp = Mathf.Max(0, CurrentHp - damage);
            _healthBar.SetHealth(CurrentHp);
            OnChanged?.Invoke(CurrentHp);
        }
    }
}