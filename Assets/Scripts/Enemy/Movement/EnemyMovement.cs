using UnityEngine;

namespace RogueLike
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 4;
        [SerializeField] private Transform _target;
        
        private Transform _cachedTransform;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cachedTransform = transform;
        }

        private void FixedUpdate()
        {
            if (!IsTargetValid())
                return;

            MoveToTarget();
            RotateToTarget();
        }

        private void OnDisable()
        {
            SetVelocity(Vector2.zero);
        }

        public void SetTarget(Transform aim)
        {
            _target = aim;

            if (_target == null)
                SetVelocity(Vector2.zero);
        }

        private bool IsTargetValid()
        {
            return _target != null;
        }

        public void MoveToTarget()
        {
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            SetVelocity(direction * _speed);
        }

        public void RotateToTarget()
        {
            Vector3 transformRight = transform.right;
            transformRight.x = _rb.velocity.normalized.x;
                
            if (transformRight.x == 0)
            {
                return;
            }
            
            transform.right = transformRight;
        }

        private void SetVelocity(Vector2 velocity)
        {
            _rb.velocity = velocity;
            //SetAnimationSpeed(velocity.magnitude);
        }
    }
}