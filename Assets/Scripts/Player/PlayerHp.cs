using System;
using UnityEngine;

namespace RogueLike
{
    public class PlayerHp : MonoBehaviour, IHealth
    {
        public event Action<int> OnChanged;
        public int CurrentHp { get; set; }
        public int MaxHp { get; }
        public void ApplyDamage(int damage)
        {
            CurrentHp = Mathf.Max(0, CurrentHp - damage);
            OnChanged?.Invoke(CurrentHp);
        }
    }
}