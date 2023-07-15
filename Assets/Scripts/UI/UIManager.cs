using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Tools")]
        public ToolsUI toolsUI;

        public static UIManager instance = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance == this)
            {
                Destroy(gameObject);
            }
        }



    }
}

