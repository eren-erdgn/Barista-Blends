using System;
using EventSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Order
{
    public class Car : MonoBehaviour
    {
        
        [SerializeField] private string[]  drinkNames;
        private string  _order;
        public string Order
        {
            get => _order;
            private set => _order = value;
        }

        public void ChooseRandomDrink()
        {
            var randomDrink = Random.Range(0, drinkNames.Length);
            Order = drinkNames[randomDrink];
            Events.OnOrderChange.Invoke(Order);
        }
    }
}
