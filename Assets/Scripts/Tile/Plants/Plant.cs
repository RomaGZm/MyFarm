using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;
using UnityEngine.UI;

namespace Core.Plants
{
    public class Plant : MonoBehaviour, Initialize
    {
        [Header("Components")]
        [SerializeField]
        private SpriteRenderer spritePlant;
        public enum PlantType
        {
            Corn, Melon, Strawberry
        }

        private PlantType _currentPlantType = PlantType.Corn;
        public PlantType currentPlantType 
        {
            get { return _currentPlantType; }
            set 
            { 
                _currentPlantType = value;
                PlantsData data = GameManager.instance.tilesController.plantsData;
                spritePlant.sprite = data.GetPlantWithType(_currentPlantType).spritePlant;
                
                 switch (_currentPlantType)
                {
                    case PlantType.Corn:
                        break;
                    case PlantType.Melon:
                        break;
                    case PlantType.Strawberry:
                        break;
                }
            }
        }

        public void Enable(bool en)
        {
            gameObject.SetActive(true);
        }

        public void Init()
        {
          
        }
    }
}

