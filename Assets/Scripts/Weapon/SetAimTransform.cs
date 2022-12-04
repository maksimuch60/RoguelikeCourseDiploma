﻿using UnityEngine;

namespace RogueLike
{
    public class SetAimTransform : MonoBehaviour
    {
        #region Variables

        [SerializeField] private AutoAim _autoAim;

        [SerializeField] private Transform _aim;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _aim = FindObjectOfType<EnemyHp>().transform;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            SetAim(_aim);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            SetAim(null);
        }

        #endregion


        #region Private methods

        private void SetAim(Transform aim)
        {
            _autoAim.SetAim(aim);
        }

        #endregion
    }
}