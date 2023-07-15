using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Player.Tools;

namespace Core.UI
{
    public class ButtonTool : MonoBehaviour
    {

        [Header("Components")]
        [SerializeField]
        private GameObject imageSelected;

        public ToolsController.ToolType toolType;

        private bool _isSelected = false;
        public bool isSelected
        {
            get { return _isSelected; }
            set 
            { 
                _isSelected = value;
                imageSelected.SetActive(_isSelected);
            }
        }
    }

   
}

