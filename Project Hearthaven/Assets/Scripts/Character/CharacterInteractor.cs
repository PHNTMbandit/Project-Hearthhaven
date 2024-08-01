using Micosmo.SensorToolkit;
using ProjectHearthaven.Capabilities;
using ProjectHearthaven.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectHearthaven.Character
{
    [AddComponentMenu("Character/Character Interactor")]
    public class CharacterInteractor : MonoBehaviour
    {
        [BoxGroup("References"), SerializeField]
        private InteractorUI _interactorUI;

        [BoxGroup("References"), SerializeField]
        private InputReader _inputReader;

        [BoxGroup("References"), SerializeField]
        private RangeSensor2D _sensor;

        public UnityEvent onInteract;

        private void Awake()
        {
            _sensor.OnDetected.AddListener(OnDetected);
            _sensor.OnLostDetection.AddListener(OnLost);
        }

        private void Update()
        {
            var interactable = _sensor.GetNearestComponent<Interactable>();

            if (interactable != null)
            {
                if (interactable.IsInteractable)
                {
                    _interactorUI.ShowUI(interactable);
                }
                else
                {
                    _interactorUI.HideUI();
                }
            }
            else
            {
                _interactorUI.HideUI();
            }
        }

        public void OnDetected(GameObject gameObject, Sensor sensor)
        {
            if (gameObject.TryGetComponent(out Interactable interactable))
            {
                interactable.OnDetected(gameObject);
            }
        }

        public void OnLost(GameObject gameObject, Sensor sensor)
        {
            if (gameObject.TryGetComponent(out Interactable interactable))
            {
                interactable.OnLost(gameObject);
            }
        }

        public void OnInteract()
        {
            var interactable = _sensor.GetNearestComponent<Interactable>();

            if (interactable != null)
            {
                if (interactable.IsInteractable)
                {
                    interactable.Interact(gameObject);
                }
            }
        }
    }
}
