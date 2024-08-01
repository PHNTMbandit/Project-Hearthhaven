using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectHearthaven.Capabilities
{
    [AddComponentMenu("Capabilities/Interactable")]
    public class Interactable : MonoBehaviour
    {
        [ShowInInspector]
        public bool IsInteractable { get; private set; } = true;

        [field: PreviewField(Alignment = ObjectFieldAlignment.Left), SerializeField]
        public Sprite InteractSprite { get; private set; }

        public UnityEvent<GameObject> onDetected,
            onInteracted,
            onLost;

        public void OnDetected(GameObject interactor)
        {
            onDetected?.Invoke(interactor);
        }

        public void Interact(GameObject interactor)
        {
            onInteracted?.Invoke(interactor);
        }

        public void OnLost(GameObject interactor)
        {
            onLost?.Invoke(interactor);
        }

        public void SetInteractable(bool interactable)
        {
            IsInteractable = interactable;
        }
    }
}
