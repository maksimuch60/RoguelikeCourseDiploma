using UnityEngine;
using UnityEngine.SceneManagement;

namespace RogueLike.Lobby
{
    public class ChooseCharacter : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [Header("Player Prefabs")]
        [SerializeField] private GameObject _firstPlayer;
        [SerializeField] private GameObject _secondPlayer;
        
        private int _sceneIndex = 2;

        public void TakeSoldier()
        {
            SetPlayerSettings(_firstPlayer);
            MoveToNextScene();
        }

        public void TakeStormtrooper()
        {
            SetPlayerSettings(_secondPlayer);
            MoveToNextScene();
        }

        private void SetPlayerSettings(GameObject playerPrefab)
        {
            _playerData.PlayerPrefab = playerPrefab;
        }

        private void MoveToNextScene()
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}