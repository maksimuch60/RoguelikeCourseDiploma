using System;
using UnityEngine;

namespace RogueLike
{
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage; 

        private Transform _player;
        private Vector2 _target;

        private void Start()
        {
            _player = FindObjectOfType<PlayerHp>().transform;

            _target = new Vector2(_player.position.x, _player.position.y); 
        }

        private void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime); 
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                col.gameObject.GetComponent<PlayerHp>().ApplyDamage(_damage);
            }
        }
    }
}