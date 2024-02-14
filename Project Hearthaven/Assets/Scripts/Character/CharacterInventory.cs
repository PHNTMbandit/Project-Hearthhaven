using System.Collections.Generic;
using ProjectHearthaven.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectHearthaven.Character
{
    [AddComponentMenu("Character/Character Inventory")]
    public class CharacterInventory : MonoBehaviour
    {
        public float CurrentCarryingWeight
        {
            get => _currentCarryingWeight;
            set =>
                _currentCarryingWeight = (
                    value <= 0
                        ? 0
                        : value >= _maxCarryingWeight
                            ? _maxCarryingWeight
                            : value
                );
        }

        [BoxGroup("Settings"), Range(0, 20), SuffixLabel("kg"), SerializeField]
        private float _maxCarryingWeight;

        [BoxGroup("Items"), SerializeField, TableList]
        private List<ItemSO> _items;

        private float _currentCarryingWeight;

        public UnityAction onInventoryChanged;

        public void AddItem(ItemSO item, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _items.Add(item);

                CurrentCarryingWeight += item.weight;
            }

            onInventoryChanged?.Invoke();
        }

        public void RemoveItem(ItemSO item, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _items.Remove(item);

                CurrentCarryingWeight -= item.weight;
            }

            onInventoryChanged?.Invoke();
        }

        public bool HasItem(ItemSO item)
        {
            return _items.Find(i => i == item);
        }

        public bool CanAddItem(ItemSO item)
        {
            return (CurrentCarryingWeight + item.weight) <= _maxCarryingWeight;
        }
    }
}
