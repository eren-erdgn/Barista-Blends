using Interface;
using Player;
using UnityEngine;

namespace InteractableObjects
{
    public class Cup : MonoBehaviour , IInteractable
    {
        private int espressoLevel = 0;
        private int milkLevel = 0;
        private int waterLevel = 0;
        private int filterCoffeeLevel = 0;
        private int MilkFoamLevel = 0;
    
        void Start()
        {
        
        }
        public bool Interact(Interactor interactor)
        {
            var inventory = interactor.GetComponent<Inventory>();
            if(inventory == null) return false;
            if (inventory.HasAnythingOnHand) return false;
            var objectToHandle = transform;
            objectToHandle.parent = interactor.Hand.transform;
            objectToHandle.localPosition = Vector3.zero;
            objectToHandle.localRotation = Quaternion.identity;
            inventory.HasAnythingOnHand = true;
            return true;
        }
        private void OnParticleCollision(GameObject other)
        {
            switch (other.tag)
            {
                case "Espresso":
                    espressoLevel++;
                    break;
                case "Milk":
                    milkLevel++;
                    break;
                case "Water":
                    waterLevel++;
                    break;
                case "FilterCoffee":
                    filterCoffeeLevel++;
                    break;
                case "MilkFoam":
                    MilkFoamLevel++;
                    break;
            }
        }

    
    }
}
