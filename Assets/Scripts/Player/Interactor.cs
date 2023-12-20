using Interface;
using UnityEngine;

namespace Player
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private float maxDistance = 10f;
        [SerializeField] private LayerMask interactableMask;
        [SerializeField] private Transform hand;
        private Camera _mainCamera;
        private IInteractable _interactable;
        private RaycastHit _hit;

        public Transform Hand
        {
            get => hand;
            set => hand = value;
        }

        private void Start()
        {
        
            _mainCamera = Camera.main;
        }
        private void Update()
        {
            var mainCamTransform = _mainCamera.transform;
            var ray = new Ray(mainCamTransform.position, mainCamTransform.forward);
        
            if (Physics.Raycast(ray, out _hit, maxDistance, interactableMask))
            {
                _interactable = _hit.collider.GetComponent<IInteractable>();
                if (_interactable != null && Input.GetKeyDown(KeyCode.E))
                {
                    _interactable.Interact(this);
                }
                Debug.DrawRay(mainCamTransform.position, mainCamTransform.forward * _hit.distance, Color.green);
            }
            else
            {
                Debug.DrawRay(mainCamTransform.position, mainCamTransform.forward * maxDistance, Color.red);
            }
        
        }
    }
}