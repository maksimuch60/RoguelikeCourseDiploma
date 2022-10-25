using UnityEngine;

namespace RogueLike
{
    public class Weapon : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _offset;

        private Camera _mainCamera; 

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _mainCamera = Camera.main; 
        }

        private void Update()
        {
            Rotate();
        }

        #endregion


        #region Private methods

        private void Rotate()
        {
            Vector3 difference = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; 
            transform.rotation = Quaternion.Euler(0f,0f,rotation + _offset);
        }

        #endregion
    }
}