using UnityEngine;

namespace RogueLike.Animations
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Death = Animator.StringToHash("Death");
        
        public void PlayRun(float speed)
        {
            _animator.SetFloat(Speed, speed);
        }
        
        public void PlayDeath()
        {
            _animator.SetTrigger(Death);
        }
    }
}