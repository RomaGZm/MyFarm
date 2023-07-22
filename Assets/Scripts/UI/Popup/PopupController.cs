using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;

namespace Core.UI
{
    public class PopupController : MonoBehaviour, Initialize
    {
        private List<GameObject> pullList = new List<GameObject>();

        [SerializeField]
        private GameObject pullPref;
        [SerializeField]
        private int pullSize = 10;

        public void Init()
        {
            for (int i = 0; i < pullSize; i++)
                pullList.Add(Instantiate(pullPref, transform));
        }
        /// <summary>
        /// Showing popup text animation
        /// </summary>
        /// <param name="target"></param>
        /// <param name="text"></param>
        /// <param name="direction"></param>
        /// <param name="textColor"></param>
        /// <param name="randomMin"></param>
        /// <param name="randomMax"></param>
        public void ShowPopup(Transform target, string text, Popup.Direction direction, Color textColor, Vector2 randomMin, Vector2 randomMax)
        {
            GetPullObject().GetComponent<Popup>().Show(target, text, direction, textColor, randomMin, randomMax);
        }

        private GameObject GetPullObject()
        {
            foreach (GameObject popup in pullList)
                if (!popup.gameObject.activeSelf)
                    return popup;

            return Instantiate(pullPref, transform);

        }
    }
}

