using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RogueLike.Room
{
    public class RoomGenerator : MonoBehaviour
    {
        [Header("Room Lists")]
        [SerializeField] private List<Room> _roomsWithLeftDoor;
        [SerializeField] private List<Room> _roomsWithRightDoor;
        [SerializeField] private List<Room> _roomsWithTopDoor;
        [SerializeField] private List<Room> _roomsWithBottomDoor;
        
        [Header("Offsets")]
        [SerializeField] private float _topOffset;
        [SerializeField] private float _bottomOffset;
        [SerializeField] private float _leftOffset;
        [SerializeField] private float _rightOffset;
        
        
        [Range(1, 7)]
        [SerializeField] private int _generationDeep;
        

        private readonly List<Room> _generatedDung = new();
        private readonly List<List<Room>> _allRooms = new();

        private Room _startRoom;
        private Room _endRoom;
        private int _roomTier;
        private int _roomsSpawned;

        public List<Room> GeneratedDung => _generatedDung;

        private void Awake()
        {
            _roomsWithBottomDoor.RandomSort();
            _roomsWithRightDoor.RandomSort();
            _roomsWithLeftDoor.RandomSort();
            _roomsWithTopDoor.RandomSort();
            
            _allRooms.Add(_roomsWithLeftDoor);
            _allRooms.Add(_roomsWithRightDoor);
            _allRooms.Add(_roomsWithTopDoor);
            _allRooms.Add(_roomsWithBottomDoor);
        }

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            float generationDeepIndex = (float) _generationDeep / 4;
            float generationDeepSum = 0;
            
            SetStartRoom();
            
            for (int i = 0; i < _generationDeep; i++)
            {
                SetRooms();
                if (i >= generationDeepSum)
                {
                    _roomTier++;
                    generationDeepSum += generationDeepIndex;
                }
            }
        }

        private void SetRooms()
        {
            Room[] generatedDungCopy = new Room[_generatedDung.Count];
            _generatedDung.CopyTo(generatedDungCopy);
            GenerateRoomLayer(generatedDungCopy);
        }

        private void GenerateRoomLayer(Room[] generatedDungCopy)
        {
            foreach (Room room in generatedDungCopy)
            {
                List<SpawnPoint> roomSpawnPoints = room.SpawnPoints;

                foreach (SpawnPoint spawnPoint in roomSpawnPoints)
                {
                    if (spawnPoint.IsSpawnPointEngaged)
                    {
                        continue;
                    }

                    RoomSideDetermination(spawnPoint, room);
                }
            }
        }

        private void RoomSideDetermination(SpawnPoint spawnPoint, Room room)
        {
            Room instantiateRoom = null;

            switch (spawnPoint.SpawnPointTag)
            {
                case "TopDot":
                    instantiateRoom = InstantiateRoom(spawnPoint, _roomsWithBottomDoor, room);
                    instantiateRoom.RoomOffsetY += room.RoomOffsetY + _topOffset;
                    instantiateRoom.RoomOffsetX += room.RoomOffsetX;
                    break;
                case "BottomDot":
                    instantiateRoom = InstantiateRoom(spawnPoint, _roomsWithTopDoor, room);
                    instantiateRoom.RoomOffsetY += room.RoomOffsetY + _bottomOffset;
                    instantiateRoom.RoomOffsetX += room.RoomOffsetX;
                    break;
                case "LeftDot":
                    instantiateRoom = InstantiateRoom(spawnPoint, _roomsWithRightDoor, room);
                    instantiateRoom.RoomOffsetX += room.RoomOffsetX + _leftOffset;
                    instantiateRoom.RoomOffsetY += room.RoomOffsetY;
                    break;
                case "RightDot":
                    instantiateRoom = InstantiateRoom(spawnPoint, _roomsWithLeftDoor, room);
                    instantiateRoom.RoomOffsetX += room.RoomOffsetX + _rightOffset;
                    instantiateRoom.RoomOffsetY += room.RoomOffsetY;
                    break;
            }

            if (instantiateRoom != null)
            {
                instantiateRoom.gameObject.transform.position =
                    new Vector3(instantiateRoom.RoomOffsetX, instantiateRoom.RoomOffsetY, 0);
                _generatedDung.Add(instantiateRoom);
            }
        }

        private Room InstantiateRoom(SpawnPoint spawnPoint, List<Room> rooms, Room room)
        {
            Room randomRoom = GetRandomRoom(rooms, _roomTier);
            
            GameObject roomInstance = 
                Instantiate(randomRoom.gameObject, spawnPoint.SpawnPointTransform.position, Quaternion.identity);
            Room connectedRoom = roomInstance.GetComponent<Room>();
            spawnPoint.SetConnectedRoom(connectedRoom);
            connectedRoom.SetSpawnPointEngaged(spawnPoint, room);
            _roomsSpawned++;
            return connectedRoom;
        }

        private Room GetRandomRoom(List<Room> rooms, int roomTier)
        {
            Room randomRoom = null;
            
            foreach (Room room in rooms)
            {
                if (room.RoomTier <= roomTier + 1 && room.RoomTier >= roomTier)
                {
                    room.ResetSpawnPoints();
                    randomRoom = room;
                    break;
                }
            }

            return randomRoom;
        }

        private void SetStartRoom()
        {
            List<Room> randomRoomList = _allRooms[GetRandomIndexFromZeroToThree()];
            foreach (Room room in randomRoomList)
            {
                if (room.gameObject.CompareTag("OneDoorRoom"))
                {
                    room.ResetSpawnPoints();
                    _startRoom = room;
                    _generatedDung.Add(room);
                    break;
                }
            }

            Instantiate(_startRoom.gameObject, Vector3.zero, Quaternion.identity);
        }

        private int GetRandomIndexFromZeroToThree()
        {
            return Random.Range(0, 4);
        }
    }
}