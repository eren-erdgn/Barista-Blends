using DG.Tweening;
using InteractableObjects;
using Interface;
using Player;
using UnityEngine;

namespace PlaceHolder.FilterCoffee
{
    public class FilterCoffeeValve : MonoBehaviour,IInteractable
    {
        [SerializeField] private Transform valveRotationPoint;
        [SerializeField] private Transform cupHolderTransform;
        [SerializeField] private ParticleSystem filterCoffeeParticle;
        private Quaternion _originalRotation;
        private Cup _cup;

        private void Start()
        {
            _originalRotation = valveRotationPoint.rotation;
        }

        public bool Interact(Interactor interactor)
        {
            if (cupHolderTransform == null) return false;
            _cup = cupHolderTransform.GetComponentInChildren<Cup>();
            if (_cup == null)
            {
                
                Debug.Log("Cup not found!");
                return false;
            }
            if (_cup.IsFull == true)
            {
                Debug.Log("Cup is full");
                return false;
            }
            RotateHandle();
            filterCoffeeParticle.Play();
            Invoke("StopParticleAfterDelay", 2f);
            Invoke("FillCupAfterDelay", 2f);
            return true;

        }
        private void FillCupAfterDelay()
        {
            _cup = cupHolderTransform.GetComponentInChildren<Cup>();
            if (_cup == null)
            {
                Debug.Log("Cup is not in place!");
                return;
            }
            _cup.FillCup("FilterCoffee");
            Debug.Log("Cup is filled up with FilterCoffee");
        }

        private void StopParticleAfterDelay()
        {
            RotateValveBack();
            filterCoffeeParticle.Stop();
        }
        private void RotateHandle()
        {
            
            valveRotationPoint.DORotate(new Vector3(0, 90, 0), 0.5f);
        }
        private void RotateValveBack()
        {
            valveRotationPoint.DORotateQuaternion(_originalRotation, 0.5f);
        }
    }
}
