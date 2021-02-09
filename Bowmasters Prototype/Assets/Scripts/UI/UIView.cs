using System;
using System.Collections.Generic;
using UnityEngine;

namespace UISystem
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private GameObject gamePanel;
        private List<GameObject> panelList = new List<GameObject>();

        private void Start()
        {
            
        }

        public void ShowPlayerUI(GameObject playerCard)
        {
            DeactivateOtherPanels();
        }

        private void DeactivateOtherPanels()
        {
            
        }
    }
}