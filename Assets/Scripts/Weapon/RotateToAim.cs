using UnityEngine;

namespace RogueLike
{
    public class RotateToAim : MonoBehaviour
    {
        #region Variables

        [SerializeField] private AutoAim _autoAim;

        [SerializeField]private Transform _aim;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _aim = FindObjectOfType<Enemy>().transform;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
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