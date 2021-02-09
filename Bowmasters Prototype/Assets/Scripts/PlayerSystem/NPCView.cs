using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCView : CharacterView
{
    private NPCController _npcController;

    public void SetNpcController(NPCController npcController)
    {
        _npcController = npcController;
    }
    
    public override Vector2 GetForwardDirection()
    {
        return transform.right * -1;
    }
    
    public override void DamageAmount(float value)
    {
        _npcController.SetHealth(value);
    }

        public override void SetBarHealth(float value)
        {
            healthBar.value -= value;

            if (healthBar.value <= 0)
            {
                
            }
        }
}
