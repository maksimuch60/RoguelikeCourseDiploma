using UnityEngine;

namespace RogueLike
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public bool IsAnimationPlayed = false; 
        
        private static readonly int Death = Animator.StringToHash("Death");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Freeze = Animator.StringToHash("Freeze");
        private static readonly int InFire = Animator.StringToHash("InFire");

        private bool SetIsAnimationPlayed()
        {
            return IsAnimationPlayed = true; 
        }
        public void PlayDeath()
        {
            _animator.SetTrigger(Death);
        }

        public void PlayRun(float speed)
        {
            _animator.SetFloat(Speed, speed);
        }

        public void Freezed()
        {
            _animator.SetTrigger(Freeze);
        }

        public void Fire()
        {
            _animator.SetTrigger(InFire);
        }
    }
}