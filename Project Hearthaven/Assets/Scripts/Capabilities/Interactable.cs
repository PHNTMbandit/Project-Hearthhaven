using UnityEngine;
using UnityEngine.Events;

namespace ProjectHearthaven.Capabilities
{
    [AddComponentMenu("Capabilities/Interactable")]
    public class Interactable : MonoBehaviour
    {
        [field: SerializeField]
        public Sprite InteractSprite { get; private set; }

        public UnityEvent onDetected,
            onInteracted,
            onLost;

        public void OnDetected()
        {
            onDetected?.Invoke();
        }

        public void Interact()
        {
            onInteracted?.Invoke();
        }

        public void OnLost()
        {
            onLost?.Invoke();
        }
    }
}