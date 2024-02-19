using UnityEngine;
using UnityEngine.Events;

namespace ProjectHearthaven.Events
{
    public class TriggerEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onTrigger;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other != null)
            {
                _onTrigger.Invoke();
            }
        }
    }
}
