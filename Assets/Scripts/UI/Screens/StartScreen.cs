using UnityEngine;
using UnityEngine.UI;
namespace RogueLike.UI
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