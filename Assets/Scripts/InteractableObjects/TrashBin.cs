using Interface;
using Player;
using UnityEngine;

namespace InteractableObjects
{
    public class TrashBin : MonoBehaviour, IInteractable
    {
        public bool Interact(Interactor interactor)
        {
            var inventory = interactor.GetComponent<Inventory>();
            if(inventory == null) return false;
            if (inventory.HasAnythingOnHand == false) return false;
            var objectToDestroy = interactor.Hand.transform.GetChild(0);
            if(objectToDestroy.CompareTag("Cup") == false) return false;
            objectToDestroy.parent = null;
            Destroy(objectToDestroy.gameObject);
            inventory.HasAnythingOnHand = false;
            return true;
        }
    }
}
