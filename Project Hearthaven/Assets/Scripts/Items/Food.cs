using ProjectHearthaven.Character;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectHearthaven.Items
{
    [CreateAssetMenu(menuName = "Item/Food", fileName = "New Item")]
    public class Food : ItemSO
    {
        [TabGroup("Food"), Range(0, 100), SerializeField]
        private float _fillHungerAmount;

        public override void Use(GameObject target)
        {
            if (target.TryGetComponent(out CharacterHunger character))
            {
                character.CurrentHunger += _fillHungerAmount;
            }
        }
    }
}
