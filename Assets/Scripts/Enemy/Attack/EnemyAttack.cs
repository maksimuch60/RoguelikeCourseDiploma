using UnityEngine;

namespace RogueLike
{
    public abstract class EnemyAttack : MonoBehaviour
    {
        private float _startFireDelay;
        protected float _timer;

        protected bool CanAttack()
        {
            return _timer <= 0;
        }

        protected void TickTimer()
        {
            _timer -= Time.deltaTime;
        }
    }
}