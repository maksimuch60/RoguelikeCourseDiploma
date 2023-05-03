using UnityEngine;
using UnityEngine.SceneManagement;

namespace RogueLike
{
    public class ChooseCharacter : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [HideInInspector]
        public GameObject _playerPrefab;
        [Header("Player Prefabs")]
        [SerializeField] private GameObject _firstPlayer;
        [SerializeField] private GameObject _secondPlayer;
        private int _sceneIndex = 2;

        public void TakeSoldier()
        {
            SetPlayerSO(_firstPlayer);
            MoveToNextScene();
        }

        public void TakeStormtrooper()
        {
            SetPlayerSO(_secondPlayer);
            MoveToNextScene();
        }

        private void SetPlayerSO(GameObject playerPrefab)
        {
            _playerData.PlayerPrefab = playerPrefab;
            _playerPrefab = _playerData.PlayerPrefab;
        }

        private void MoveToNextScene()
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}