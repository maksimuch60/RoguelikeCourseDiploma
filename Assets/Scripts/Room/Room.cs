using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Room
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints;
        [Range(0, 3)]
        [SerializeField] private int _roomTier;
        
        [SerializeField] private Transform _startSpawnTransform;
        [SerializeField] private Transform _endSpawnTransform;

        public List<SpawnPoint> SpawnPoints => _spawnPoints;
        public int RoomTier => _roomTier;
        public float RoomOffsetX { get; set; }
        public float RoomOffsetY { get; set; }
        

        private string GetOppositeTagName(SpawnPoint spawnPoint)
        {
            string oppositeTag = null;
            switch (spawnPoint.SpawnPointTag)
            {
                case "TopDot":
                    oppositeTag = "BottomDot";
                    break;
                case "BottomDot":
                    oppositeTag = "TopDot";
                    break;
                case "LeftDot":
                    oppositeTag = "RightDot";
                    break;
                case "RightDot":
                    oppositeTag = "LeftDot";
                    break;
            }

            return oppositeTag;
        }

        public void SetSpawnPointEngaged(SpawnPoint spawnPoint, Room room)
        {
            string oppositeTagName = GetOppositeTagName(spawnPoint);

            foreach (SpawnPoint point in _spawnPoints)
            {
                if (point.SpawnPointTag == oppositeTagName)
                {
                    point.SetSpawnPointEngaged(true);
                    point.SetConnectedRoom(room);
                }
            }
        }

        public void ResetSpawnPoints()
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                spawnPoint.SetSpawnPointEngaged(false);
            }
        }

        public void ResetRoomOffset()
        {
            RoomOffsetX = 0;
            RoomOffsetY = 0;
        }
    }
}