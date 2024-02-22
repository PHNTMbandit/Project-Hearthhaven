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

            _bankAccount.onBalanceChanged += UpdateUI;
        }

        private void Start()
        {
            Invoke(nameof(Initialise), 0.1f);
        }

        private void Initialise()
        {
            _textCounter.Initialise(_bankAccount.CurrentBalance);
        }

        private void UpdateUI()
        {
            _textCounter.SetTarget(_bankAccount.CurrentBalance);
        }
    }
}
