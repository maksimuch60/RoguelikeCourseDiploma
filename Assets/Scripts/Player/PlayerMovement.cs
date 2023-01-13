using UnityEngine;

namespace RogueLike
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerAnimation _playerAnimation; 
        [SerializeField] public float Speed = 4f;
        private Rigidbody2D _rb;
        private bool _needToRotate;
        private float _minSpeed = 1f; 

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            SetMinSpeed();
            Move();
            Rotate();
        }

        #endregion


        #region Private methods

        private void Move()
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            Vector2 direction = new(horizontal, vertical);
            Vector3 moveDelta = direction * Speed;
            _rb.velocity = moveDelta;
            
            _playerAnimation.PlayRun(direction.magnitude);
        }

        private void Rotate()
        {
            Vector3 transformRight = transform.right;
            transformRight.x = _rb.velocity.normalized.x;
                
            if (transformRight.x == 0)
            {
                return;
            }
            
            transform.right = transformRight;
        }

        private void SetMinSpeed()
        {
            if (Speed < _minSpeed)
            {
                Speed = _minSpeed; 
            }
        }
        #endregion
    }
}