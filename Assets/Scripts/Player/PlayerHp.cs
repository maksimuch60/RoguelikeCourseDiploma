using System;
using UnityEngine;

namespace RogueLike
{
    public class PlayerHp : MonoBehaviour, IHeal
    {
        [SerializeField] private int _startHp;
        [SerializeField] private int _maxHp; 
        public event Action<int> OnChanged;
        public int CurrentHp { get; private set; }
        public int MaxHp => _maxHp;

        private void Awake()
        {
            CurrentHp = _startHp;
            OnChanged?.Invoke(CurrentHp);
        }

        public void ApplyDamage(int damage)
        {
            CurrentHp = Mathf.Max(0, CurrentHp - damage);
            OnChanged?.Invoke(CurrentHp);
        }
    }
}