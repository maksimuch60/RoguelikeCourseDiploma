using UnityEngine;

namespace RogueLike
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class EnemyMovement : MonoBehaviour
    {
        [SerializeField] protected float _speed = 4;
        [SerializeField] protected Transform _target;

        protected Transform _cachedTransform;
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

            MoveFromTarget();
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

        internal abstract bool IsTargetValid();
       

        protected abstract void MoveFromTarget();

        private void RotateToTarget()
        {
            Vector3 transformRight = transform.right;
            transformRight.x = _rb.velocity.normalized.x;

            if (transformRight.x == 0)
            {
                return;
            }

            transform.right = transformRight;
        }

        protected void SetVelocity(Vector2 velocity)
        {
            _rb.velocity = velocity;
            //SetAnimationSpeed(velocity.magnitude);
        }
    }
}