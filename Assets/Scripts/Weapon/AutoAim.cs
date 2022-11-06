using UnityEngine;

namespace RogueLike
{
    public class AutoAim : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _aimPosition;

        private Camera _mainCamera;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void FixedUpdate()
        {
            if (IsAimValid())
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
            Vector3 difference = _aimPosition.position - transform.position; 
            float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        }

        private void Rotate()
        {
            Vector3 difference = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        }

        #endregion
    }
}