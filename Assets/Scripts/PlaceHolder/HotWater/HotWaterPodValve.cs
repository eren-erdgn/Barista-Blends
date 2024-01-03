using DG.Tweening;
using InteractableObjects;
using Interface;
using Player;
using UnityEngine;

namespace PlaceHolder.HotWater
{
    public class HotWaterPodValve : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform valveRotationPoint;
        [SerializeField] private Transform cupHolderTransform;
        [SerializeField] private ParticleSystem hotWaterParticle;
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
            hotWaterParticle.Play();
            Invoke("StopParticleAfterDelay", 1f);
            Invoke("FillCupAfterDelay", 1f);
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
            _cup.FillCup("HotWater");
            Debug.Log("Cup is filled up with HotWater");
        }

        private void StopParticleAfterDelay()
        {
            RotateValveBack();
            Debug.Log("Stopping particle AFTER THREE SECONDS");
            hotWaterParticle.Stop();
        }
        private void RotateHandle()
        {
            
            // Rotate the handle by 90 degrees around the Y axis over 1 second
            valveRotationPoint.DORotate(new Vector3(0, 90, 0), 0.5f);
        }
        private void RotateValveBack()
        {
            valveRotationPoint.DORotateQuaternion(_originalRotation, 0.5f);
        }
    }
}
