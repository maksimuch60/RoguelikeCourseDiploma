using UnityEngine;

namespace RogueLike
{
    public class SpecialEffectAttack : MonoBehaviour
    {
        private float _startFireDelay;
        protected float Timer;

        protected bool CanAttack()
        {
            return Timer <= 0;
        }

        protected void TickTimer()
        {
            Timer -= Time.deltaTime;
        }
    }
}