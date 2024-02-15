using ProjectHearthaven.Character;
using TMPro;
using UnityEngine;

namespace ProjectHearthaven.UI
{
    public class WalletAmountText : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _walletAmountText;

        [SerializeField]
        private CharacterWallet _wallet;

        private void Awake()
        {
            _wallet.onWalletChanged += UpdateUI;
        }

        private void Start()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            _walletAmountText.SetText($"<sprite name=Small Coin> {_wallet.Dollars:C0}");
        }
    }
}
