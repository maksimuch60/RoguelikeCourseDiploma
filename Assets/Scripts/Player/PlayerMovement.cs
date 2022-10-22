using UnityEngine;

namespace RogueLike
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
            float horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal > 0 && !_needToRotate)
            {
                Rotate();
            }
            else if (horizontal < 0 && _needToRotate)
            {
                Rotate();
            }
        }

        #endregion


        #region Private methods

        private void Move()
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            Vector2 direction = new Vector2(horizontal, vertical);
            Vector3 moveDelta = direction * _speed;
            _rb.velocity = moveDelta;
        }

        private void Rotate()
        {
            _needToRotate = !_needToRotate;
            transform.Rotate(0f, 180f, 0f);
        }

        #endregion
    }
}