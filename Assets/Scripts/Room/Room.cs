using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Room
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints;
        [SerializeField] private List<Door> _doors;

        [Range(0, 3)]
        [SerializeField] private int _roomTier;

        [SerializeField] private Transform _startSpawnTransform;
        [SerializeField] private Transform _endSpawnTransform;

        public List<SpawnPoint> SpawnPoints => _spawnPoints;
        public int RoomTier => _roomTier;
        public float RoomOffsetX { get; set; }
        public float RoomOffsetY { get; set; }

        public void SetSpawnPointEngaged(SpawnPoint spawnPoint, Room room)
        {
            string oppositeTagName = GetOppositeSpawnPointTagName(spawnPoint);

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

        public void OpenDoors()
        {
            foreach (Door door in _doors)
            {
                door.OpenDoor();
            }
        }

        public void CloseDoors()
        {
            foreach (Door door in _doors)
            {
                door.CloseDoor();
            }
        }

        public void TransitToRoom(Door door, GameObject colGameObject)
        {
            string oppositeDoorTagName = GetOppositeDoorTagName(door);

            foreach (Door door1 in _doors)
            {
                if (door1.CompareTag(oppositeDoorTagName))
                {
                    door1.TransitToDoor(colGameObject);
                    break;
                }
            }
        }

        public void SetRoomToDoor(Room room, SpawnPoint spawnPoint, bool isSpawnPointRevert)
        {
            string spawnPointTagName = spawnPoint.SpawnPointTag;
            
            if (isSpawnPointRevert)
            {
                spawnPointTagName = GetOppositeSpawnPointTagName(spawnPoint);
            }

            Door door = GetDoorByTagName(spawnPointTagName);
            door.SetConnectedRoom(room);
        }

        private Door GetDoorByTagName(string spawnPointTagName)
        {
            switch (spawnPointTagName)
            {
                case "TopDot":
                    return _doors.Find(x => x.CompareTag("TopDoor"));
                case "BottomDot":
                    return _doors.Find(x => x.CompareTag("BottomDoor"));
                case "LeftDot":
                    return _doors.Find(x => x.CompareTag("LeftDoor"));
                case "RightDot":
                    return _doors.Find(x => x.CompareTag("RightDoor"));
            }

            return null;
        }

        private string GetOppositeSpawnPointTagName(SpawnPoint spawnPoint)
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

        private string GetOppositeDoorTagName(Door door)
        {
            string oppositeTag = null;
            switch (door.tag)
            {
                case "TopDoor":
                    oppositeTag = "BottomDoor";
                    break;
                case "BottomDoor":
                    oppositeTag = "TopDoor";
                    break;
                case "LeftDoor":
                    oppositeTag = "RightDoor";
                    break;
                case "RightDoor":
                    oppositeTag = "LeftDoor";
                    break;
            }

            return oppositeTag;
        }
    }
}