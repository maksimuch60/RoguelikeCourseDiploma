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
            Debug.Log($"Time scale is: {Time.timeScale}");
            if (_playerHp.CurrentHp <= 0 && _playerAnimation.IsAnimationPlayed)
            {
                _playerAnimation.IsAnimationPlayed = false; 
                _gameOverScreen.SetActive(true);
                Time.timeScale = 0; 
                
            }
        }
        
    }
}