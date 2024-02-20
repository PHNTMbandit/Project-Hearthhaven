using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectHearthaven.Character
{
    [AddComponentMenu("Character/Character Bank Account")]
    public class CharacterBankAccount : MonoBehaviour
    {
        [SerializeField, Range(0, 10000), SuffixLabel("dollars")]
        private int _dollars;

        public int Dollars
        {
            get => _dollars;
            set =>
                _dollars = (int)(
                    value <= 0
                        ? 0
                        : value >= Mathf.Infinity
                            ? Mathf.Infinity
                            : value
                );
        }

        public UnityAction onBankAccountChanged;
        public UnityAction<int> onDollarsRemoved,
            onDollarsAdded;

        public void AddDollars(int amount)
        {
            Dollars += amount;

            onDollarsAdded?.Invoke(amount);
            onBankAccountChanged?.Invoke();
        }

        public void RemoveDollars(int amount)
        {
            Dollars -= amount;

            onDollarsRemoved?.Invoke(amount);
            onBankAccountChanged?.Invoke();
        }

        public bool CanTransfer(int amount)
        {
            return Dollars >= amount;
        }
    }
}
