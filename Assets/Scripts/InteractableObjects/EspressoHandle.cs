using Interface;
using Player;
using UnityEngine;

namespace InteractableObjects
{
    public class EspressoHandle : MonoBehaviour, IInteractable
    {
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
    }
}
