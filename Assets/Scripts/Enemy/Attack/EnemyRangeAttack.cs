using UnityEngine;

namespace RogueLike
{
    public class EnemyRangeAttack : EnemyAttack
    {
        private float _startFireDelay;
        private float _timer;
        [SerializeField] private float _fireDelay = 3f;
        [SerializeField] private GameObject _enemyBulletPrefab;
        [SerializeField] protected Transform _player;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerHp>().transform; 
        }

        private void Update()
        {
            TickTimer();

            if (CanAttack())
            {
                Attack();
                Debug.Log("Shoot1");
            }
        }

        private void Attack()
        {
            _timer = _fireDelay;
            Instantiate(_enemyBulletPrefab, transform.position, Quaternion.identity);
            Debug.Log("Shoot");
        }

        private bool CanAttack()
        {
            return _timer <= 0;
        }

        private void TickTimer()
        {
            _timer -= Time.deltaTime;
        }
    }
}