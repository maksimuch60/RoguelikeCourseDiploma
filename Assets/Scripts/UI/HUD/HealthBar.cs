using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLike
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _hpValue;
        
        public void SetMaxHealth(int health)
        {
            _slider.maxValue = health; 
        }

        public void SetHealth(int health)
        {
            _hpValue.text = $"HP:{health}";
            _slider.value = health; 
        }
    }
}