﻿using RogueLike.Animations;
using UnityEngine;

namespace RogueLike
{
    public class ArcherDeath : EnemyDeath
    {
        [SerializeField] private EnemyAnimation _enemyAnimation; 
        protected override void OnHpChanged(int hp)
        {
            if (IsDead || hp > 0)
                return;
            _enemyAnimation.PlayDeath();
            _enemyAttack.enabled = false;
            _enemyHp.enabled = false;
            _enemyMovement.enabled = false;
        }
    }
}