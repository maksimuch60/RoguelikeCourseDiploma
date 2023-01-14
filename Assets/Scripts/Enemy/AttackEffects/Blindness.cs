using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLike
{
    public class Blindness : SpecialEffectAttack
    {
        [SerializeField] private int _durationBeforeExit = 5; 
        
        private void OnEnable()
        {
            _blindZone.enabled = true;
            StartCoroutine(WaitBeforeExit());
        }

        private void OnDisable()
        {
            StopCoroutine(WaitBeforeExit());
        }

        IEnumerator WaitBeforeExit()
        {
            yield return new WaitForSeconds(_durationBeforeExit);
            _blindZone.enabled = false; 
        }
    }
}