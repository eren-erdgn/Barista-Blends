using System;
using Interface;
using Player;
using UnityEngine;

namespace InteractableObjects
{
    public class EspressoHandle : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject coffeeInsideHandle;
        [SerializeField] private bool isFullWithCoffee = false;

        public bool IsFullWithCoffee
        {
            get => isFullWithCoffee;
            set => isFullWithCoffee = value;
        }

        private void Update()
        {
            coffeeInsideHandle.SetActive(isFullWithCoffee == true);
        }

        public bool Interact(Interactor interactor)
        {
            var inventory = interactor.GetComponent<Inventory>();
            if(inventory == null) return false;
            if (inventory.HasAnythingOnHand) return false;
            var objectToHandle = transform;
            objectToHandle.parent = interactor.Hand.transform;
            objectToHandle.GetComponent<Collider>().enabled = false;
            objectToHandle.localPosition = Vector3.zero;
            objectToHandle.localRotation = Quaternion.identity;
            objectToHandle.GetComponent<Collider>().enabled = true;
            inventory.HasAnythingOnHand = true;
            return true;

        }
    }
}
