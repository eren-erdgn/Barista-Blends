using System;
using Interface;
using Player;
using UnityEngine;

namespace InteractableObjects
{
    public class Cup : MonoBehaviour , IInteractable
    {
        [SerializeField] private string drinkName;
        private bool _isFull;
        [SerializeField] private int maxFillAmount = 4;
        [SerializeField] private string[] ingredients = new string[4];
        [SerializeField] private GameObject[] ingredientVisuals = new GameObject[4];
        [SerializeField] private Color espressoColor;
        [SerializeField] private Color milkColor;
        [SerializeField] private Color waterColor;
        [SerializeField] private Color latte;
        [SerializeField] private Color americano;
        [SerializeField] private Color cappuccino;
        [SerializeField] private Color filterCoffee;
        [SerializeField] private Color flatWhite;
        [SerializeField] private Color redEye;
        
        private int _currentFillAmount;

        public bool IsFull
        {
            get => _isFull;
            set => _isFull = value;
        }

        public string[] Ingredients
        {
            get => ingredients;
            set => ingredients = value;
        }

        public string DrinkName
        {
            get => drinkName;
            set => drinkName = value;
        }

        public void FillCup(string ingredient)
        {
            if (_isFull) return;
            if (_currentFillAmount >= maxFillAmount) return;
            ingredients[_currentFillAmount] = ingredient;
            
            ingredientVisuals[_currentFillAmount].SetActive(true);
            _currentFillAmount++;
            ChangeColorForOneIngredient(ingredient);
            if(_currentFillAmount == 1 && ingredient == "Espresso")
            {
                DrinkName = "Espresso";
            }
            else
            {
                DrinkName = "this coffee is not on the menu";
                if (_currentFillAmount >= maxFillAmount)
                {
                    SetColorBasedOnIngredients();
                    _isFull = true;
                }
            }
                
            
            
            
            
        }
        
        private Color GetColorForIngredient(string ingredient)
        {
            return ingredient switch
            {
                "Espresso" => espressoColor,
                "Milk" => milkColor,
                "Foam" => milkColor,
                "FilterCoffee" => filterCoffee,
                "HotWater" => waterColor,
                _ => Color.clear
            };
        }
        private void SetColorBasedOnIngredients()
        {
            Array.Sort(ingredients);
            string ingredientsString = string.Join("", ingredients);
            switch (ingredientsString)
            {
                case "EspressoMilkMilkMilk":
                    DrinkName = "Latte";
                    ChangeColor(latte);
                    break;
                case "EspressoHotWaterHotWaterHotWater":
                    DrinkName = "Americano";
                    ChangeColor(americano);
                    break;
                case "EspressoFoamMilkMilk":
                    DrinkName = "Cappuccino";
                    ChangeColor(cappuccino);
                    break;
                case "FilterCoffeeFilterCoffeeFilterCoffeeFilterCoffee":
                    DrinkName = "FilterCoffee";
                    ChangeColor(filterCoffee);
                    break;
                case "EspressoEspressoMilkMilk":
                    DrinkName = "FlatWhite";
                    ChangeColor(flatWhite);
                    break;
                case "EspressoFilterCoffeeFilterCoffeeFilterCoffee":
                    DrinkName = "RedEye";
                    ChangeColor(redEye);
                    break;
                default:
                    DrinkName = "this coffee is not on the menu";
                    break;
            }
        }
        private void ChangeColorForOneIngredient(string ingredient)
        {
            var color = GetColorForIngredient(ingredient);
            ChangeColor(color);
        }
        private void ChangeColor(Color color)
        {
            foreach (var ingredient in ingredientVisuals)
            {
                ingredient.GetComponent<MeshRenderer>().material.color = color;
            }
        }
        public bool Interact(Interactor interactor)
        {
            var inventory = interactor.GetComponent<Inventory>();
            if(inventory == null) return false;
            if (inventory.HasAnythingOnHand) return false;
            var objectToHandle = transform;
            objectToHandle.parent = interactor.Hand.transform;
            objectToHandle.GetComponent<Collider>().enabled = false;
            objectToHandle.localScale = Vector3.one;
            objectToHandle.localPosition = Vector3.zero;
            objectToHandle.localRotation = Quaternion.identity;
            objectToHandle.GetComponent<Collider>().enabled = true;
            inventory.HasAnythingOnHand = true;
            return true;
        }

        
    }
}
