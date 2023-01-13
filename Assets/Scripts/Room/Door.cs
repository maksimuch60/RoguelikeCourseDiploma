using System;
using UnityEngine;

namespace RogueLike.Room
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private GameObject _door;
        [SerializeField] private Room _connectedRoom;

        private Vector3 _topSpawnOffset = new(0, -2, 0);
        private Vector3 _bottomSpawnOffset = new(0, 2, 0);
        private Vector3 _leftSpawnOffset = new(2, 0, 0);
        private Vector3 _rightSpawnOffset = new(-2, 0, 0);

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _connectedRoom.TransitToRoom(this, col.gameObject);
            }
        }

        public void SetConnectedRoom(Room connectedRoom)
        {
            _connectedRoom = connectedRoom;
        }

        public void OpenDoor()
        {
            _door.SetActive(false);
        }

        public void CloseDoor()
        {
            _door.SetActive(true);
        }

        public void TransitToDoor(GameObject colGameObject)
        {
            switch (gameObject.tag)
            {
                case "LeftDoor":
                    colGameObject.transform.position = transform.position + _leftSpawnOffset;
                    break;
                case "TopDoor":
                    colGameObject.transform.position = transform.position + _topSpawnOffset;
                    break;
                case "BottomDoor":
                    colGameObject.transform.position = transform.position + _bottomSpawnOffset;
                    break;
                case "RightDoor":
                    colGameObject.transform.position = transform.position + _rightSpawnOffset;
                    break;
            }
        }
    }
}