using System.Collections;
using RogueLike.Player;
using UnityEngine;

namespace RogueLike
{
    public class ShamanFreezeAttack : EnemyAttack
    {
        [SerializeField] private PlayerMovement _playerMovement;

        [SerializeField] private float _defaultSpeed = 4;

        [SerializeField] private float _freezeSpeed;

        [SerializeField] private int _duration = 5;

        private void Start()
        {
            StartCoroutine(Freeze()); 
        }

        IEnumerator Freeze()
        {
            _playerMovement.Speed -= _freezeSpeed;
            Debug.Log($"Default speed is {_defaultSpeed}");
            yield return new WaitForSeconds(_duration);
            _playerMovement.Speed = _defaultSpeed;  
            Debug.Log($"Default speed AFTER FREEZE is {_defaultSpeed}");
            
        }
    }
}