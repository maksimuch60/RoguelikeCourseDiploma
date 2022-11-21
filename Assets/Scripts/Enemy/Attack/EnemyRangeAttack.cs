using UnityEngine;

namespace RogueLike
{
    public class EnemyRangeAttack : EnemyAttack
    {
        #region Variables
        
        [SerializeField] private GameObject _enemyBulletPrefab;
        [SerializeField] private Transform _bulletSpawnPositionTransform;
        [SerializeField] private float _fireDelay = 0.3f;

        [SerializeField] private RunAway _runAway; 
        private Transform _cachedTransform;
        private float _timer;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _cachedTransform = transform;
        }
        

        private void Update()
        {
            TickTimer();

            if (CanAttack())
            {
                Attack();
                Debug.Log("Attack");
            }
        }

        #endregion


        #region Private methods
        

        private void Attack()
        {
            _timer = _fireDelay;
            Instantiate(_enemyBulletPrefab, _bulletSpawnPositionTransform.position, _cachedTransform.rotation);
        }

        private bool CanAttack()
        {
            return _runAway.IsTargetValid() && _timer <= 0;
        }

        private void TickTimer()
        {
            _timer -= Time.deltaTime;
        }

        #endregion
    }
}