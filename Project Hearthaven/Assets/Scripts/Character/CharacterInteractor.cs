using Micosmo.SensorToolkit;
using ProjectHearthaven.Capabilities;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectHearthaven.Character
{
    [AddComponentMenu("Character/Character Interactor")]
    public class CharacterInteractor : MonoBehaviour
    {
        [BoxGroup("References"), SerializeField]
        private InputReader _inputReader;

        [BoxGroup("References"), SerializeField]
        private RangeSensor2D _sensor;

        public UnityEvent<Interactable> onInteractableDetected;
        public UnityEvent onInteractableLost,
            onInteract;

        private void Awake()
        {
            _sensor.OnDetected.AddListener(OnInteractableDetected);
            _sensor.OnLostDetection.AddListener(OnInteractableLost);
        }

        public void OnInteract()
        {
            if (_sensor.GetNearestComponent<Interactable>() != null)
            {
                _sensor.GetNearestComponent<Interactable>().Interact();
            }
        }

        public void OnInteractableDetected(GameObject gameObject, Sensor sensor)
        {
            if (gameObject != null)
            {
                if (gameObject.TryGetComponent(out Interactable interactable))
                {
                    interactable.OnDetected();

                    onInteractableDetected?.Invoke(interactable);
                }
            }
        }

        public void OnInteractableLost(GameObject gameObject, Sensor sensor)
        {
            if (gameObject != null)
            {
                if (gameObject.TryGetComponent(out Interactable interactable))
                {
                    interactable.OnLost();

                    onInteractableLost?.Invoke();
                }
            }
        }
    }
}
