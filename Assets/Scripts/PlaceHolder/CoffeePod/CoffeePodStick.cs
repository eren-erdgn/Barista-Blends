using InteractableObjects;
using Interface;
using Player;
using UnityEngine;
using DG.Tweening;

namespace PlaceHolder.CoffeePod
{
    public class CoffeePodStick : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform handleTransform;
        [SerializeField] private Transform handleRotationPoint;
        private Quaternion _originalRotation;

        private void Start()
        {
            _originalRotation = handleRotationPoint.rotation;
        }
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
            RotateHandle();
            return true;

        }
        private void RotateHandle()
        {
            // Rotate the handle by 90 degrees around the Y axis over 1 second
            handleRotationPoint.DORotate(new Vector3(-70, 0, -90), 1f)
                .OnComplete(() =>
                {
                    // After the rotation is complete, rotate it back to the original rotation over 1 second
                    handleRotationPoint.DORotateQuaternion(_originalRotation, 1f);
                });
        }
    }
}
