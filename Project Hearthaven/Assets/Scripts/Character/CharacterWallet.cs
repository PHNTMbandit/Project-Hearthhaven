using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectHearthaven.Character
{
    [AddComponentMenu("Character/Character Wallet")]
    public class CharacterWallet : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
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

        private int _dollars;

        public UnityAction onWalletChanged;

        public void AddDollars(int amount)
        {
            _dollars += amount;

            onWalletChanged?.Invoke();
        }

        public void RemoveDollars(int amount)
        {
            _dollars -= amount;

            onWalletChanged?.Invoke();
        }

        public bool CanTransfer(int amount)
        {
            return Dollars >= amount;
        }
    }
}
