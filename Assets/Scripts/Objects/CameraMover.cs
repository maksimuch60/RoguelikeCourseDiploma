using Cinemachine;
using UnityEngine;

namespace RogueLike.Objects
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        public void SetTarget(Room.Room room)
        {
            Transform roomTransform = room.transform;
            //_virtualCamera.LookAt = roomTransform;
            _virtualCamera.Follow = roomTransform;
        }
    }
}