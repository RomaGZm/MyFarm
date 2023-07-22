
using UnityEngine;
using Core.Player.Tools;
using TMPro;
using UnityEngine.UI;
namespace Core.UI
{
    public class ButtonTool : MonoBehaviour
    {

        [Header("Components")]
        [SerializeField]
        private GameObject imageSelected;
        [SerializeField]
        private TMP_Text textPrice;
        [SerializeField]
        private Image imageIcon;

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
       /// <summary>
       /// Set text button price
       /// </summary>
       /// <param name="price"></param>
        public void SetPrice(int price)
        {
            textPrice.text = price.ToString();
        }
        /// <summary>
        /// Set text button icon
        /// </summary>
        /// <param name="sprite"></param>
        public void SetSprite(Sprite sprite)
        {
            imageIcon.sprite = sprite;
        }
    }

   
}

