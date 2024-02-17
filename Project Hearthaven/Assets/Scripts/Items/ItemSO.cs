using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectHearthaven.Items
{
    public abstract class ItemSO : ScriptableObject
    {
        [TabGroup("Details")]
        public string itemName;

        [TabGroup("Details"), TextArea]
        public string itemDescription;

        [TabGroup("Details"), Range(0, 100), SuffixLabel("kg")]
        public float weight;

        public abstract void Use(GameObject target);
    }
}
