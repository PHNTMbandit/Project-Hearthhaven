using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectHearthaven.Inventory
{
    [Serializable]
    public class InventorySlot
    {
        [ShowInInspector]
        public ItemSO Item { get; private set; }

        [ShowInInspector]
        public int Amount
        {
            get => _amount;
            set =>
                _amount = (int)(
                    value <= 0
                        ? 0
                        : value >= Mathf.Infinity
                            ? Mathf.Infinity
                            : value
                );
        }

        private int _amount;

        public void SetItem(ItemSO item, int amount)
        {
            Item = item;
            Amount = amount;
        }

        public void AddAmount(int amount)
        {
            Amount += amount;
        }

        public void RemoveAmount(int amount)
        {
            Amount -= amount;

            if (Amount <= 0)
            {
                ResetSlot();
            }
        }

        public void ResetSlot()
        {
            Item = null;
            Amount = 0;
        }
    }
}
