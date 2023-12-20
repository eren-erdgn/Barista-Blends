using InteractableObjects;
using Interface;
using Player;
using UnityEngine;

namespace PlaceHolder.EspressoMachine
{
    public class EspressoButton : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform cupHolderTransform;
        [SerializeField] private Transform handleHolderTransform;

        public bool Interact(Interactor interactor)
        {
            if (cupHolderTransform == null || handleHolderTransform == null) return false;
            var espressoHandle = handleHolderTransform.GetComponentInChildren<EspressoHandle>();
            var cup = cupHolderTransform.GetComponentInChildren<Cup>();
            if (espressoHandle == null || cup == null)
            {
                Debug.Log("Handle or Cup not found!");
                return false;
            }
            if (espressoHandle.IsFullWithCoffee == false)
            {
                Debug.Log("Handle has no coffee in it!");
                return false;
            }
            if (cup.IsFull == true)
            {
                Debug.Log("Cup is full");
                return false;
            }
            Debug.Log("espresso is filling up with espresso");
            cup.FillCup("Espresso");
            espressoHandle.IsFullWithCoffee = false;
            return true;

        }
    }
}
