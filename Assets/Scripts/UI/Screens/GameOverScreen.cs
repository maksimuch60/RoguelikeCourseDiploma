using UnityEngine;
using UnityEngine.UI;

namespace RogueLike
{
    public class GameOverScreen : BaseScreen
    {
        [SerializeField] private Button _toMenuButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            _toMenuButton.onClick.AddListener(MoveToNextScene);
            _exitButton.onClick.AddListener(Exit);
            _restartButton.onClick.AddListener(Restart);
        }
    }
}