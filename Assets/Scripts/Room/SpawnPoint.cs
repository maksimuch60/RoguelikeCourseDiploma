using System;
using UnityEngine;

namespace RogueLike.Room
{
    [Serializable]
    public class SpawnPoint
    {
        [SerializeField] private Transform _spawnPointTransform;
        [SerializeField] private Room _connectedRoom;

        private bool _isSpawnPointEngaged;
        
        public string SpawnPointTag => _spawnPointTransform.tag;
        public Transform SpawnPointTransform => _spawnPointTransform;
        public bool IsSpawnPointEngaged => _isSpawnPointEngaged;
        
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