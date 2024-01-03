using System;
using InteractableObjects;
using Interface;
using Player;
using UnityEngine;

namespace PlaceHolder.EspressoMachine
{
    public class EspressoButton : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform buttonTransform;
        [SerializeField] private Transform cupHolderTransform;
        [SerializeField] private Transform handleHolderTransform;
        [SerializeField] private ParticleSystem espressoParticle;
        private Cup _cup;
        private EspressoHandle _espressoHandle;

        

        public bool Interact(Interactor interactor)
        {
            if (cupHolderTransform == null || handleHolderTransform == null) return false;
            _espressoHandle = handleHolderTransform.GetComponentInChildren<EspressoHandle>();
            _cup = cupHolderTransform.GetComponentInChildren<Cup>();
            if (_espressoHandle == null || _cup == null)
            {
                
                Debug.Log("Handle or Cup not found!");
                return false;
            }
            if (_espressoHandle.IsFullWithCoffee == false)
            {
                Debug.Log("Handle has no coffee in it!");
                return false;
            }
            if (_cup.IsFull == true)
            {
                Debug.Log("Cup is full");
                return false;
            }
            
            espressoParticle.Play();
            buttonTransform.position = new Vector3(buttonTransform.position.x, buttonTransform.position.y, buttonTransform.position.z + 0.06f);
            Invoke("StopParticleAfterDelay", 3f);
            Invoke("FillCupAfterDelay", 3f);
            _espressoHandle.IsFullWithCoffee = false;
            return true;

        }
        private void FillCupAfterDelay()
        {
            _cup = cupHolderTransform.GetComponentInChildren<Cup>();
            _espressoHandle = handleHolderTransform.GetComponentInChildren<EspressoHandle>();
            if (_espressoHandle == null || _cup == null)
            {
                Debug.Log("Cup is not in place!");
                return;
            }
            _cup.FillCup("Espresso");
            Debug.Log("espresso is filled up with espresso");
        }

        private void StopParticleAfterDelay()
        {
            buttonTransform.position = new Vector3(buttonTransform.position.x, buttonTransform.position.y, buttonTransform.position.z- 0.06f);
            Debug.Log("Stopping particle AFTER THREE SECONDS");
            espressoParticle.Stop();
        }
    }
}
