using System;
using UnityEngine;

namespace RogueLike.Room
{
    [Serializable]
    public class SpawnPoint
    {
        [SerializeField] private GameObject _spawnPoint;
        [SerializeField] private Room _connectedRoom;
        [SerializeField] private bool _isAbleToSpawn;
        
        private bool _isSpawnPointEngaged;

        public string SpawnPointTag => _spawnPoint.tag;
        public GameObject SpawnPointGO => _spawnPoint;
        public Transform SpawnPointTransform => _spawnPoint.transform;
        public bool IsSpawnPointEngaged => _isSpawnPointEngaged;
        public bool IsAbleToSpawn => _isAbleToSpawn;
        public Room ConnectedRoom => _connectedRoom;
        
        public void SetConnectedRoom(Room connectedRoom)
        {
            _connectedRoom = connectedRoom;
            _isSpawnPointEngaged = true;
        }

        public void SetSpawnPointEngaged(bool engaged)
        {
            _isSpawnPointEngaged = engaged;
        }
    }
}