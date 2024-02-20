using ProjectHearthaven.Character;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectHearthaven.Capabilities
{
    public class Tradeable : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 1000), SuffixLabel("dollars"), SerializeField]
        private int _dollars;

        public void Trade(GameObject trader)
        {
            if (trader.TryGetComponent(out CharacterWallet wallet))
            {
                wallet.RemoveDollars(_dollars);
            }
        }
    }
}
