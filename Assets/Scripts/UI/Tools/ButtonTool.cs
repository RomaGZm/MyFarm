
using UnityEngine;
using Core.Player.Tools;
using TMPro;

namespace Core.UI
{
    public class ButtonTool : MonoBehaviour
    {

        [Header("Components")]
        [SerializeField]
        private GameObject imageSelected;
        [SerializeField]
        private TMP_Text textPrice;

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

        public void SetPrice(int price)
        {
            textPrice.text = price.ToString();
        }
    }

   
}

