using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectHearthaven.Character
{
    [AddComponentMenu("Character/Character Bank Account")]
    public class CharacterBankAccount : MonoBehaviour
    {
        [SerializeField, Range(0, 10000), SuffixLabel("dollars")]
        private int _currentBalance;

        public int CurrentBalance
        {
            get => _currentBalance;
            set =>
                _currentBalance = (int)(
                    value <= 0
                        ? 0
                        : value >= Mathf.Infinity
                            ? Mathf.Infinity
                            : value
                );
        }

        public UnityAction onBalanceChanged;
        public UnityAction<int> onDollarsRemoved,
            onDollarsAdded;

        public void AddDollars(int amount)
        {
            CurrentBalance += amount;

            onDollarsAdded?.Invoke(amount);
            onBalanceChanged?.Invoke();
        }

        public void RemoveDollars(int amount)
        {
            CurrentBalance -= amount;

            onDollarsRemoved?.Invoke(amount);
            onBalanceChanged?.Invoke();
        }

        public bool CanTransfer(int amount)
        {
            return CurrentBalance >= amount;
        }

        public bool CanAfford(int amount)
        {
            return (CurrentBalance - amount) >= 0;
        }
    }
}
