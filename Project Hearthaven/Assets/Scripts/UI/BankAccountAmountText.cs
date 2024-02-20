using ProjectHearthaven.Character;
using TMPro;
using UnityEngine;

namespace ProjectHearthaven.UI
{
    public class BankAccountAmountText : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _amountText;

        [SerializeField]
        private CharacterBankAccount _bankAccount;

        private void Awake()
        {
            _bankAccount.onBankAccountChanged += UpdateUI;
        }

        private void Start()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            _amountText.SetText($"<sprite name=Small Coin> {_bankAccount.Dollars:C0}");
        }
    }
}
