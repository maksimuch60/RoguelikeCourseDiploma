using System;
using UnityEngine;

namespace RogueLike
{
    public class AutoAim : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _aimPosition;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _radius;
        [SerializeField] private float _offset;

        private Camera _mainCamera;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void FixedUpdate()
        {
            if (_aimPosition != null)
            {
                FollowEnemies();
                Debug.Log($"Follow enemies");
            }
            else
            {
                Rotate();
                Debug.Log("Rotate");
            }
        }

        #endregion


        #region Private methods

        private bool IsAimValid()
        {
            return _aimPosition != null;
        }

        public void SetAim(Transform aim)
        {
            _aimPosition = aim;
        }

        private void FollowEnemies()
        {
            Collider2D col = Physics2D.OverlapCircle(_aimPosition.position, _radius, _layerMask);
            if (col == null)
                return;
            Vector3 aimPos = _aimPosition.position;
            transform.rotation = Quaternion.Euler(aimPos.x, aimPos.y, 0f);
        }

        private void Rotate()
        {
            Vector3 difference = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation + _offset);
        }

        #endregion
    }
}