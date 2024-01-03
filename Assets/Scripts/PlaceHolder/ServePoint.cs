using System;
using EventSystem;
using InteractableObjects;
using Order;
using Unity.VisualScripting;
using UnityEngine;

namespace PlaceHolder
{
    public class ServePoint : PlaceHolder
    {
        [SerializeField] private Transform servePoint;
        private bool _isCarOrdered;
        private bool _isRightDrinkServed;
        [SerializeField] private string orderedDrinkName;

        public bool IsRightDrinkServed
        {
            get => _isRightDrinkServed;
            set => _isRightDrinkServed = value;
        }

        private void OnEnable()
        {
            Events.OnOrderChange.AddListener(OnCarGiveAnOrder);
        }

        

        private void OnDisable()
        {
            Events.OnOrderChange.RemoveListener(OnCarGiveAnOrder);
        }
        private void OnCarGiveAnOrder(string orderedDrink)
        {
            _isCarOrdered = true;
            orderedDrinkName = orderedDrink;
        }

        private void Update()
        {
            if (!_isCarOrdered) return;
            if(servePoint.childCount == 0) return;
            if (orderedDrinkName != servePoint.GetChild(0).GetComponent<Cup>().DrinkName) return;
            Destroy(servePoint.GetChild(0).gameObject);
            IsRightDrinkServed = true;
            _isCarOrdered = false;

        }
    }
}
