using System.Collections.Generic;
using RogueLike.Game;
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

        [Range(3, 6)]
        [SerializeField] private int _generationDeep;

        [SerializeField] private Level _level;

        private readonly List<Room> _generatedDung = new();
        private readonly List<List<Room>> _allRooms = new();

        private Room _startRoom;
        private Room _endRoom;
        private float _roomTier;
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
            
            Generate();
        }

        private void Start()
        {
            _level.Construct(_generatedDung);
        }

        private void Generate()
        {
            float generationDeepIndex = (float) 4 / _generationDeep;

            SetStartRoom();

            for (int i = 0; i < _generationDeep; i++)
            {
                _roomTier += generationDeepIndex;

                SetRooms();
            }

            FindWrongRooms();
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
                    break;
                }
            }

            GameObject instantiateRoom = Instantiate(_startRoom.gameObject, Vector3.zero, Quaternion.identity);
            Room roomComponent = instantiateRoom.GetComponent<Room>();
            _generatedDung.Add(roomComponent);
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
                    if (spawnPoint.IsSpawnPointEngaged || !spawnPoint.IsAbleToSpawn)
                    {
                        continue;
                    }

                    if (!CheckSpawnPointNeighbors(spawnPoint))
                    {
                        continue;
                    }

                    RoomSideDetermination(spawnPoint, room);
                }
            }
        }

        private bool CheckSpawnPointNeighbors(SpawnPoint spawnPoint)
        {
            Collider2D[] overlapCircleAll = Physics2D.OverlapCircleAll(spawnPoint.SpawnPointTransform.position, 1f);

            foreach (Collider2D collider2D1 in overlapCircleAll)
            {
                if (spawnPoint.SpawnPointGO.name == collider2D1.name)
                {
                    continue;
                }

                if (collider2D1.gameObject.layer.Equals(LayerMask.NameToLayer("Room")))
                {
                    return false;
                }
            }

            return true;
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

            room.SetRoomToDoor(connectedRoom, spawnPoint, false);
            connectedRoom.SetRoomToDoor(room, spawnPoint, true);
            
            _roomsSpawned++;
            return connectedRoom;
        }

        private Room GetRandomRoom(List<Room> rooms, float roomTier)
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

        private void FindWrongRooms()
        {
            List<Room> wrongRooms = new();
            foreach (Room room in _generatedDung)
            {
                foreach (SpawnPoint spawnPoint in room.SpawnPoints)
                {
                    if (!spawnPoint.IsSpawnPointEngaged && spawnPoint.IsAbleToSpawn)
                    {
                        wrongRooms.Add(room);
                        break;
                    }
                }
            }

            RespawnRoom(wrongRooms);
        }

        private void RespawnRoom(List<Room> wrongRooms)
        {
            foreach (Room wrongRoom in wrongRooms)
            {
                SpawnPoint spawnPoint = new();
                Room connectedRoom = null;

                foreach (SpawnPoint roomSpawnPoint in wrongRoom.SpawnPoints)
                {
                    if (roomSpawnPoint.IsAbleToSpawn && roomSpawnPoint.IsSpawnPointEngaged)
                    {
                        spawnPoint = roomSpawnPoint;
                        connectedRoom = spawnPoint.ConnectedRoom;
                        break;
                    }
                }

                Room oneDoorRoom = FindOneDoorRoom(spawnPoint);

                foreach (SpawnPoint roomSpawnPoint in oneDoorRoom.SpawnPoints)
                {
                    if (roomSpawnPoint.SpawnPointTag == spawnPoint.SpawnPointTag)
                    {
                        roomSpawnPoint.SetConnectedRoom(connectedRoom);
                        oneDoorRoom.SetRoomToDoor(connectedRoom, spawnPoint, false);
                        break;
                    }
                }

                int wrongRoomIndex = _generatedDung.IndexOf(wrongRoom);
                Vector2 wrongRoomPosition = wrongRoom.transform.position;
                _generatedDung.Remove(wrongRoom);
                Destroy(wrongRoom.gameObject);
                Room instantiate = Instantiate(oneDoorRoom, wrongRoomPosition, Quaternion.identity);
                if (connectedRoom != null)
                {
                    connectedRoom.SetSpawnPointEngaged(spawnPoint, instantiate);
                    connectedRoom.SetRoomToDoor(oneDoorRoom, spawnPoint, true);
                }
                _generatedDung.Insert(wrongRoomIndex, instantiate);
            }
        }

        private Room FindOneDoorRoom(SpawnPoint spawnPoint)
        {
            Room roomWithOneDoor = null;

            switch (spawnPoint.SpawnPointTag)
            {
                case "TopDot":
                    roomWithOneDoor = GetRoomWithOneDoor(_roomsWithTopDoor);
                    break;
                case "BottomDot":
                    roomWithOneDoor = GetRoomWithOneDoor(_roomsWithBottomDoor);
                    break;
                case "LeftDot":
                    roomWithOneDoor = GetRoomWithOneDoor(_roomsWithLeftDoor);
                    break;
                case "RightDot":
                    roomWithOneDoor = GetRoomWithOneDoor(_roomsWithRightDoor);
                    break;
            }

            return roomWithOneDoor;
        }

        private Room GetRoomWithOneDoor(List<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                if (room.tag.Equals("OneDoorRoom"))
                {
                    return room;
                }
            }

            return null;
        }

        private int GetRandomIndexFromZeroToThree()
        {
            return Random.Range(0, 4);
        }
    }
}