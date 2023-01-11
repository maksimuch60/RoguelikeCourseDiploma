using UnityEngine;

namespace RogueLike
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private PlayerHp _playerHp;
        [SerializeField] private GameObject _gameOverScreen;

        private void Awake()
        {
            _gameOverScreen.SetActive(false);
        }

        private void Update()
        {
            if (_playerHp.CurrentHp <= 0)
            {
                _gameOverScreen.SetActive(true);
            }
        }
    }
}