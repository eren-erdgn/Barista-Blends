using Interface;
using Player;
using UnityEngine;

namespace InteractableObjects
{
    public class CupPile : MonoBehaviour ,IInteractable
    {
        [SerializeField] private GameObject cupPrefab;
        

        public bool Interact(Interactor interactor)
        {
            var inventory = interactor.GetComponent<Inventory>();
            if(inventory == null) return false;
            if (inventory.HasAnythingOnHand == true) return false;
            var objectToHandle = Instantiate(cupPrefab, interactor.Hand.transform, true);
            objectToHandle.transform.localScale = Vector3.one;
            objectToHandle.transform.localPosition = Vector3.zero;
            objectToHandle.transform.localRotation = Quaternion.identity;
            inventory.HasAnythingOnHand = true;
            return true;
            
            
        }
    }
}
