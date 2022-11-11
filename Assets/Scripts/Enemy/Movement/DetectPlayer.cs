using RogueLike.Player;
using UnityEngine;

namespace RogueLike
{
    public class DetectPlayer : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyMovement _movement;

        [SerializeField] private Transform _target;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _target  = FindObjectOfType<PlayerMovement>().transform;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            SetTarget(_target);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            SetTarget(null);
        }

        #endregion


        private void SetTarget(Transform aim)
        {
            _movement.SetTarget(aim);
        }

    }
}