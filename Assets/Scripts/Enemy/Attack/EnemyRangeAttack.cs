using UnityEngine;

namespace RogueLike
{
    public class EnemyRangeAttack : EnemyAttack
    {
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
            Timer = _fireDelay;
            Instantiate(_enemyBulletPrefab, transform.position, RotateToPlayer(_player.position));
        }
        
        private Quaternion RotateToPlayer(Vector3 playerPosition)
        {
            Vector3 difference = playerPosition - transform.position;
            float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0f, 0f, rotation);
        }
    }
}