﻿using System;
using System.Collections.Generic;
using RogueLike.Objects;
using RogueLike.Room;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RogueLike.Game
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private CameraMover _cameraMover;

        private List<Room.Room> _generatedDung;
        private Room.Room _currentRoom; 
        private bool _firstInit = true;
        private bool _isBattle;
        private bool _isPerform;

        public void Construct(List<Room.Room> generatedDung)
        {
            _generatedDung = generatedDung;
        }

        private void Awake()
        {
            _generatedDung = new List<Room.Room>();
        }

        private void Update()
        {
            if (_firstInit)
            {
                FirstInit();
            }

            if (_spawner.EnemyCounter == 0 && !_isPerform)
            {
                _isBattle = false;
            }

            if (!_isBattle)
            {
                _isPerform = true;
                _currentRoom.OpenDoors();
            }
        }

        private void OnDestroy()
        {
            foreach (Room.Room room in _generatedDung)
            {
                foreach (Door door in room.Doors)
                {
                    door.OnEnter -= ChangeCamera;
                }
            }
        }

        private void RoomInit(Room.Room room)
        {
            _currentRoom.CloseDoors();
            _spawner.EnemySpawn(room, Random.Range(3, 6));
            _isBattle = true;
            _isPerform = false;
        }

        private void FirstInit()
        {
            if (_generatedDung == null || _generatedDung.Count == 0)
                return;

            _currentRoom = _generatedDung[0];
            _cameraMover.SetTarget(_currentRoom);
            SpawnPlayer();
            OpenAllDoors();

            _firstInit = false;
        }

        private void OpenAllDoors()
        {
            foreach (Room.Room room in _generatedDung)
            {
                foreach (Door door in room.Doors)
                {
                    door.OnEnter += ChangeCamera;
                    door.OpenDoor();
                }
            }
        }

        private void SpawnPlayer()
        {
            _spawner.SpawnPlayer(_currentRoom);
        }

        private void ChangeCamera(Room.Room room)
        {
            _currentRoom = room;
            RoomInit(_currentRoom);
            _cameraMover.SetTarget(_currentRoom);
        }
    }
}