using System.Linq;
using Interface;
using Player;
using UnityEngine;

namespace PlaceHolder
{
    public abstract class PlaceHolder : MonoBehaviour , IInteractable
    {
    
        [SerializeField] private string[] placeableTags;
        [SerializeField] private Transform holderTransform;
        public virtual bool Interact(Interactor interactor)
        {
            var inventory = interactor.GetComponent<Inventory>();
            if(inventory == null) return false;
            if (inventory.HasAnythingOnHand == false) return false;
            if(holderTransform.childCount != 0) return false;
            var playersHand = interactor.Hand.transform.GetChild(0);
            var itemHeld = playersHand.tag;
            if (placeableTags.All(tags => tags != itemHeld)) return false;
            playersHand.parent = holderTransform.transform;
            playersHand.GetComponent<Collider>().enabled = false;
            playersHand.transform.localScale = Vector3.one;
            playersHand.transform.localPosition = Vector3.zero;
            playersHand.transform.localRotation = Quaternion.identity;
            playersHand.GetComponent<Collider>().enabled = true;
            
            inventory.HasAnythingOnHand = false;
            return true;
        }
        
    }
}
