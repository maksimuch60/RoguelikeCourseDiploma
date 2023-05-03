using UnityEngine;

namespace RogueLike
{
    [CreateAssetMenu(fileName = "Player", menuName = "Configs/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public GameObject PlayerPrefab; 
    }
}