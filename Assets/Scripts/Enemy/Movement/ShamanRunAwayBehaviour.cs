﻿using System;
using System.Collections;
using UnityEngine;

namespace RogueLike
{
    public class ShamanRunAwayBehaviour : EnemyMovement
    {
        [SerializeField] private ComplexAttack _complexAttack;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                _complexAttack.ShootSpecialProjectile();
                Debug.Log("Instantiate one of three complex attacks");
                MovementRelativeToThePlayer();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _complexAttack.StopShoot();
        }

        internal override bool IsTargetValid()
        {
            return _target != null;
        }

        protected override void MovementRelativeToThePlayer()
        {
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            SetVelocity(-direction * _speed);
        }

        private IEnumerator WaitAfterExit()
        {
            yield return new WaitForSeconds(5); 
        }
    }
}