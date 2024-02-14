using System;
using System.Linq;
using ProjectHearthaven.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectHearthaven.Character
{
    public class CharacterInventory : MonoBehaviour
    {
        [SerializeField, TableList]
        private InventorySlot[] _inventorySlots;

        public void AddItem(ItemSO item, int amount)
        {
            if (HasItem(item, out InventorySlot inventorySlot))
            {
                inventorySlot.AddAmount(amount);
            }
            else
            {
                GetEmptyInventorySlot().SetItem(item, amount);
            }
        }

        public void RemoveItem(ItemSO item, int amount)
        {
            if (HasItem(item, out InventorySlot inventorySlot))
            {
                inventorySlot.RemoveAmount(amount);
            }
        }

        public bool HasItem(ItemSO item, out InventorySlot inventorySlot)
        {
            inventorySlot = Array.Find(_inventorySlots, i => i.Item == item);

            return inventorySlot != null;
        }

        public InventorySlot GetEmptyInventorySlot()
        {
            return _inventorySlots.First(i => i.Item == null);
        }
    }
}
