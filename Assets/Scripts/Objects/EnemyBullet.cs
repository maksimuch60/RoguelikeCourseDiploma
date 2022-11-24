using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace RogueLike
{
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        private float _lifeTime = 2f;
        private Transform _player;
        private Vector2 _target;
        private Vector3 _playerPosition; 

        private void Start()
        {
            _player = FindObjectOfType<PlayerHp>().transform;

            _playerPosition = _player.position; 

            _target = new Vector2(_player.position.x, _player.position.y);
            
            StartCoroutine(LifeTimeTimer());
        }

        private void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
            Rotate();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                col.gameObject.GetComponent<PlayerHp>().ApplyDamage(_damage);
            }
        }
        IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);

            Destroy(gameObject);
        }

        private void Rotate()
        {
            Vector3 difference = _playerPosition - transform.position; 
            float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        }
    }
}