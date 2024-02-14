using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectHearthaven.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Item", fileName = "New Item")]
    public class ItemSO : ScriptableObject
    {
        public string itemName;

        [TextArea]
        public string itemDescription;

        [Range(0, 100), SuffixLabel("kg")]
        public float weight;
    }
}
