using ProjectHearthaven.Controllers;
using UnityEngine;

namespace ProjectHearthaven.Capabilities
{
    public class ObjectPoolable : MonoBehaviour
    {
        public void Disable()
        {
            transform.SetParent(ObjectPoolController.Instance.transform);
            gameObject.SetActive(false);
            transform.localScale = new(1, 1, 1);
        }
    }
}
