using UnityEngine;

namespace RogueLike
{
    public class Weapon : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _aimPosition;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _radius;
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private float _offset;

        private Camera _mainCamera;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Start()
        {
            _triggerObserver.OnEntered += OnAimEntered;
            _triggerObserver.OnExited += OnAimExited;
        }

        private void Update()
        {
            Rotate();
        }

        #endregion


        #region Private methods

        private void OnAimExited(Collider2D col)
        {
            Rotate();
        }

        private void OnAimEntered(Collider2D col)
        {
            FollowEnemies();
        }

        private void FollowEnemies()
        {
            Collider2D col = Physics2D.OverlapCircle(_aimPosition.position, _radius, _layerMask);
            if (col == null)
                return;
            transform.rotation = Quaternion.Euler(0f, 0f, _aimPosition.position.x);
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