using UnityEngine;

namespace RogueLike
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private PlayerHp _playerHp;
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private GameObject _gameOverScreen;
        private Animation _animation;

        private void Awake()
        {
            _gameOverScreen.SetActive(false);
        }

        private void Update()
        {
            if (_playerHp.CurrentHp <= 0 && _playerAnimation.IsAnimationPlayed)
            {
                _gameOverScreen.SetActive(true);
                StopTime();
            }
        }

        private void StopTime()
        {
            Time.timeScale = 0;
        }
    }
}