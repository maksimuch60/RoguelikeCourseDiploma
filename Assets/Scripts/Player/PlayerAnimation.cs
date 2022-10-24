using UnityEngine;

namespace RogueLike.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int Death = Animator.StringToHash("Death");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Talk = Animator.StringToHash("Talk");

        public void PlayDeath()
        {
            _animator.SetTrigger(Death);
        }

        public void PlayRun(float speed)
        {
            _animator.SetFloat(Speed, speed);
        }

        public void StartPlayTalk()
        {
            _animator.SetBool(Talk, true);
        }

        public void StopPlayTalk()
        {
            _animator.SetBool(Talk, false);
        }
    }
}
