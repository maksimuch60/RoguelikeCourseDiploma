using UnityEngine;

namespace RogueLike
{
    public class DetectPlayer : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyMovement _movement;

        #endregion


        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                SetTarget(col.gameObject.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                SetTarget(null);
            }
        }

        #endregion


        private void SetTarget(Transform aim)
        {
            _movement.SetTarget(aim);
        }
    }
}