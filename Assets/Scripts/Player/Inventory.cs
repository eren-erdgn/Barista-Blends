using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]private bool hasAnythingOnHand = false;

        public bool HasAnythingOnHand
        {
            get => hasAnythingOnHand;
            set => hasAnythingOnHand = value;
        }
    }
}

