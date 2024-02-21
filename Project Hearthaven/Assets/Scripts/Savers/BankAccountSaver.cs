using System;
using PixelCrushers;
using ProjectHearthaven.Character;
using UnityEngine;

namespace ProjectHearthaven.Savers
{
    [AddComponentMenu("Savers/Bank Account Saver")]
    [RequireComponent(typeof(CharacterBankAccount))]
    public class BankAccountSaver : Saver
    {
        [Serializable]
        public class Data
        {
            public int bankAccountBalance;
        }

        private Data _data = new();
        private CharacterBankAccount _bankAccount;

        public override void Awake()
        {
            base.Awake();

            _bankAccount = GetComponent<CharacterBankAccount>();
        }

        public override string RecordData()
        {
            _data.bankAccountBalance = _bankAccount.CurrentBalance;

            return SaveSystem.Serialize(_data);
        }

        public override void ApplyData(string s)
        {
            if (_bankAccount == null || string.IsNullOrEmpty(s))
            {
                return;
            }

            var data = SaveSystem.Deserialize(s, _data);

            if (data == null)
            {
                return;
            }

            _data = data;
            _bankAccount.CurrentBalance = data.bankAccountBalance;
        }
    }
}
