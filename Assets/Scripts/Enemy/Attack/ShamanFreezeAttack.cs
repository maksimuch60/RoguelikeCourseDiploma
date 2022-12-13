using System.Collections;
using RogueLike.Player;
using UnityEngine;

namespace RogueLike
{
    public class ShamanFreezeAttack : EnemyAttack
    {
        [SerializeField] private PlayerMovement _playerMovement;

        [SerializeField] private float _defaultSpeed;

        [SerializeField] private float _freezeSpeed;

        [SerializeField] private int _duration = 5;

        private void Start()
        {
            _defaultSpeed += _playerMovement._speed;
            StartCoroutine(Freeze()); 
        }

        IEnumerator Freeze()
        {
            _defaultSpeed += _freezeSpeed;
            Debug.Log($"Default speed is {_defaultSpeed}");
            yield return new WaitForSeconds(_duration);
            _defaultSpeed += _playerMovement._speed; 
            Debug.Log($"Default speed AFTER FREEZE is {_defaultSpeed}");
            
        }
    }
}