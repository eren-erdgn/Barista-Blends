using InteractableObjects;
using Interface;
using Player;
using UnityEngine;

namespace PlaceHolder.CoffeePod
{
    public class CoffeePodStick : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform handleTransform;

        public bool Interact(Interactor interactor)
        {
            if (handleTransform == null) return false;
            var espressoHandle = handleTransform.GetComponentInChildren<EspressoHandle>();
            if (espressoHandle == null)
            {
                Debug.Log("No Handle found!");
                return false;
            }
            if (espressoHandle.IsFullWithCoffee == true)
            {
                Debug.Log("Handle is Already full with coffee");
                return false;
            }
            Debug.Log("Handle is filling up");
            espressoHandle.IsFullWithCoffee = true;
            return true;

        }
    }
}
