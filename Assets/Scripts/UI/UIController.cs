using UnityEngine;

namespace RogueLike.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseScreen;
        [SerializeField] private PauseManager _pause; 

        private void Awake()
        {
            _pauseScreen.SetActive(false);
        }

        private void Start()
        {
            _pause.OnPaused += Paused; 
        }

        private void OnDestroy()
        {
            _pause.OnPaused -= Paused; 
        }

        private void Paused(bool isPaused)
        {
            _pauseScreen.SetActive(isPaused);
        }
    }
}