﻿using UnityEngine;

namespace RogueLike
{
    public class BlindZoneMover : MonoBehaviour
    {
        [SerializeField] private Transform _followPlayer;

        private Camera _camera;

        private Transform _cachedTransform;
        private bool _isPlayerFollowSet;

        private void Start()
        {
            _cachedTransform = transform;
            
            _camera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            if (!_isPlayerFollowSet && FindObjectOfType<PlayerHp>()!= null)
            {
                SetFollowPlayer();
                _isPlayerFollowSet = true;
            }
            
            Vector3 followPosition = _camera.WorldToScreenPoint(_followPlayer.position);
            followPosition.z = _cachedTransform.position.z;
            _cachedTransform.position = followPosition;
        }

        private void SetFollowPlayer()
        {
            _followPlayer = FindObjectOfType<PlayerHp>().transform;
        }
    }
}