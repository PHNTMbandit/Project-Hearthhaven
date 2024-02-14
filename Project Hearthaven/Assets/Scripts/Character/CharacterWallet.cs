using Sirenix.OdinInspector;
using UnityEngine;

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

        public void AddDollars(int amount)
        {
            _dollars += amount;
        }

        public void RemoveDollars(int amount)
        {
            _dollars -= amount;
        }

        public bool CanTransfer(int amount)
        {
            return Dollars >= amount;
        }
    }
}
