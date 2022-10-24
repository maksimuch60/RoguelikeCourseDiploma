using UnityEngine;

namespace RogueLike.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _speed = 4f;
        private Rigidbody2D _rb;
        private bool _needToRotate;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
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
            Vector3 moveDelta = direction * _speed;
            _rb.velocity = moveDelta;
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

        #endregion
    }
}