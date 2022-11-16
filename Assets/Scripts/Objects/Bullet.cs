﻿using System.Collections;
using UnityEngine;

namespace RogueLike
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifeTime = 0.3f;
        [SerializeField] private int _damage = 3;

        private Rigidbody2D _rb;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = (transform.right * _speed);
            StartCoroutine(LifeTimeTimer());
        }

        IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);

            Destroy(gameObject);
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<EnemyHp>().ApplyDamage(_damage);
            }
        }

        #endregion
    }
}