using UnityEngine;

namespace RogueLike.Animations
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Death = Animator.StringToHash("Death");
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");
        
        public void PlayRun(float speed)
        {
            _animator.SetFloat(Speed, speed);
        }
        
        public void PlayDeath()
        {
            _animator.SetTrigger(Death);
        }

        public void StopPlayAttack()
        {
            _animator.SetBool(IsAttack, false);
        } 
        public void StartPlayAttack()
        {
            _animator.SetBool(IsAttack, true);
        }
        
    }
}