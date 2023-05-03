using RogueLike.Game;
using UnityEngine;

namespace RogueLike
{
    public class ChooseCharacter : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData; 
        public GameObject _playerPrefab;
        [Header("Player Prefabs")]
        [SerializeField] private GameObject _firstPlayer;
        [SerializeField] private GameObject _secondPlayer;

        public void TakeSoldier()
        {
            SetPlayerSO(_firstPlayer);
        }

        public void TakeStormtrooper()
        {
            SetPlayerSO(_secondPlayer);
        }

        private void SetPlayerSO(GameObject playerPrefab)
        {
            _playerData.PlayerPrefab = playerPrefab;
            _playerPrefab = _playerData.PlayerPrefab;
        }
    }
}