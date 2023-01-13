using UnityEngine;

namespace RogueLike
{
    public class SetAimTransform : MonoBehaviour
    {
        #region Variables

        [SerializeField] private AutoAim _autoAim;

        [SerializeField] private Transform _aim;

        #endregion


        #region Private methods

        private void OnTriggerEnter2D(Collider2D col)
        {
            _aim = col.gameObject.transform;
            SetAim(_aim);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            SetAim(null);
        }

        private void SetAim(Transform aim)
        {
            _autoAim.SetAim(aim);
        }

        #endregion
    }
}