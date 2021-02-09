using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PlayerSystem
{
    public class CharacterView : MonoBehaviour, ITakeDamage
    {
        [SerializeField] protected Slider healthBar;
        [SerializeField] protected GameObject shootPos;
        
        public Vector2 ShootPos => shootPos.transform.position;
        
        public virtual Vector2 GetForwardDirection()
        {
            return this.transform.right;
        }

        public virtual void DamageAmount(float value)
        {
           
        }

        public void SetHealthBarLimits(float min, float max)
        {
            healthBar.minValue = min;
            healthBar.maxValue = max;
            healthBar.value = max;
        }

        public virtual void SetBarHealth(float value)
        {
           
        }
    }
}