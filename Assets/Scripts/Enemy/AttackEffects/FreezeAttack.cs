using System.Collections;
using RogueLike.Player;
using UnityEngine;

namespace RogueLike
{
    public class FreezeAttack : SpecialEffectAttack
    {
        [SerializeField] private PlayerAnimation _playerAnimation; 
        
        [SerializeField] private PlayerMovement _playerMovement;

        [SerializeField] private float _defaultSpeed = 10;

        [SerializeField] private float _freezeSpeed;

        [SerializeField] private int _duration = 5;

        private int _fireDelay = 2;

        private void Update()
        {
            TickTimer();
        }

        private void OnEnable()
        {
            StartCoroutine(Freeze());
        }

        private void OnDisable()
        {
            StopCoroutine(Freeze());
        }

        private IEnumerator Freeze()
        {
            if (CanAttack())
            {
                Timer = _fireDelay;
                _playerMovement.Speed += _freezeSpeed;
                _playerAnimation.Freezed();
                Debug.Log($"Default speed is {_playerMovement.Speed}");
                yield return new WaitForSeconds(_duration);
                _playerMovement.Speed = _defaultSpeed; 
                Debug.Log($"Default speed AFTER FREEZE is {_playerMovement.Speed}");   
            }
        }
    }
}