using UnityEngine;
using UnityEngine.UI;

namespace RogueLike
{
    public class StartScreen : BaseScreen
    {
        [SerializeField] public Button StartButton;
        
        [SerializeField] public Button ExitButton;

        private void Start() 
        {
            StartButton.onClick.AddListener(MoveToNextScene);
            ExitButton.onClick.AddListener(Exit);
        }
        
    }
}