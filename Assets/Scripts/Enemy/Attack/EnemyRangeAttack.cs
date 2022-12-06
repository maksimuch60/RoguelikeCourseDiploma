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
            Instantiate(_enemyBulletPrefab, transform.position, RotateToPlayer(_player.position));
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

        private Quaternion RotateToPlayer(Vector3 playerPosition)
        {
            Vector3 difference = playerPosition - transform.position;
            float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0f, 0f, rotation);
        }
    }
}