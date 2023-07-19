using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;

namespace Core.UI
{
    public class PopupController : MonoBehaviour, Initialize
    {
        private List<GameObject> damagePullList = new List<GameObject>();
        [SerializeField]
        private GameObject damagePullPref;
        [SerializeField]
        private int pullSize = 10;

        public void Init()
        {
            for (int i = 0; i < pullSize; i++)
                damagePullList.Add(Instantiate(damagePullPref, transform));
        }

        public void ShowPopup(Transform target, string text, Popup.Direction direction, Color textColor, Vector2 randomMin, Vector2 randomMax)
        {
            GetPullObject().GetComponent<Popup>().Show(target, text, direction, textColor, randomMin, randomMax);
        }

        private GameObject GetPullObject()
        {
            foreach (GameObject popup in damagePullList)
                if (!popup.gameObject.activeSelf)
                    return popup;

            return Instantiate(damagePullPref, transform);

        }
    }
}

