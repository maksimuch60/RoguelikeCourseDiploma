using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RogueLike
{
    public class BaseScreen : MonoBehaviour
    {
        [SerializeField] private int _sceneIndex;

        protected void MoveToNextScene()
        {
            SceneManager.LoadScene(_sceneIndex);
            Time.timeScale = 1; 
        }

        protected void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }

        protected void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1; 
        }
    }
}