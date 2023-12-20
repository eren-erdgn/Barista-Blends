using Interface;
using Player;
using UnityEngine;

namespace InteractableObjects
{
    public class Cup : MonoBehaviour , IInteractable
    {
        private bool _isFull;
        [SerializeField] private int maxFillAmount = 4;
        [SerializeField] private string[] ingredients = new string[4];
        [SerializeField] private GameObject[] ingredientVisuals = new GameObject[4];
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
        public void FillCup(string ingredient)
        {
            if (_isFull) return;
            if (_currentFillAmount >= maxFillAmount) return;
            ingredients[_currentFillAmount] = ingredient;
            ingredientVisuals[_currentFillAmount].SetActive(true);
            _currentFillAmount++;
            if (_currentFillAmount >= maxFillAmount)
            {
                _isFull = true;
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
