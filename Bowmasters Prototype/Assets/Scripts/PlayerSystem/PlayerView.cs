using System;
using PlayerSystem;
using TMPro;
using UnityEngine;

namespace PlayerSystem
{
	public class PlayerView : CharacterView
	{
		[SerializeField] protected GameObject displayHolder;
    	[SerializeField] protected TextMeshProUGUI powerValue, angleValue;

        private PlayerController _playerController;

        public void SetPlayerController(PlayerController playerController)
        {
	        _playerController = playerController;
        }

        public void SetShootInfo(float force, float angle, bool gettingInput)
        {
	        if (gettingInput)
	        {
		        powerValue.text = Mathf.FloorToInt(force) + " \n Power";
		        angleValue.text = Mathf.FloorToInt(angle) + " \n Angle";
		        displayHolder.SetActive(true);
	        }
        }

        public override Vector2 GetForwardDirection()
        {
	        return transform.right;
        }

        public override void DamageAmount(float value)
        {
	        _playerController.SetHealth(value);
        }
        
        public override void SetBarHealth(float value)
        {
	        healthBar.value -= value;
        }
	}
}
