using ProjectHearthaven.Character;
using UnityEngine;

namespace ProjectHearthaven.UI
{
    [RequireComponent(typeof(TextCounter))]
    public class BankAccountAmountText : MonoBehaviour
    {
        [SerializeField]
        private CharacterBankAccount _bankAccount;

        private TextCounter _textCounter;

        private void Awake()
        {
            _textCounter = GetComponent<TextCounter>();

            _bankAccount.onBankAccountChanged += UpdateUI;
        }

        private void UpdateUI()
        {
            _textCounter.SetTarget(_bankAccount.Dollars);
        }
    }
}
