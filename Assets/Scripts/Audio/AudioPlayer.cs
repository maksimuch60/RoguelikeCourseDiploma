using UnityEngine;

namespace RogueLike
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public void PlaySound(AudioClip audioClip)
        {
            if (audioClip == null)
                return;
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
    }
}