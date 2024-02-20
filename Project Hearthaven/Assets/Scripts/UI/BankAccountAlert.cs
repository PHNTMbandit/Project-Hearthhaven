using ProjectHearthaven.Character;
using ProjectHearthaven.Controllers;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace ProjectHearthaven.UI
{
    public class BankAccountAlert : MonoBehaviour
    {
        [BoxGroup("Colour"), ColorPalette, SerializeField]
        private Color _addedTextColour,
            _removedTextColour;

        [BoxGroup("References"), SerializeField]
        private Transform _spawnPosition;

        [BoxGroup("References"), SerializeField]
        private Transform _spawnParent;

        [BoxGroup("References"), SerializeField]
        private CharacterBankAccount _bankAccount;

        private void Awake()
        {
            _bankAccount.onDollarsAdded += ShowAddedAlert;
            _bankAccount.onDollarsRemoved += ShowRemovedAlert;
        }

        private void ShowAddedAlert(int amount)
        {
            TextMeshProUGUI text = ObjectPoolController.Instance.GetPooledObject<TextMeshProUGUI>(
                "Money Change Alert",
                _spawnPosition.transform.localPosition,
                Quaternion.identity,
                _spawnParent,
                false
            );

            text.SetText($"<sprite name=Small Coin> {amount:C0}");
            text.color = _addedTextColour;
        }

        private void ShowRemovedAlert(int amount)
        {
            TextMeshProUGUI text = ObjectPoolController.Instance.GetPooledObject<TextMeshProUGUI>(
                "Money Change Alert",
                _spawnPosition.transform.localPosition,
                Quaternion.identity,
                _spawnParent,
                false
            );

            text.SetText($"<sprite name=Small Coin> {amount:C0}");
            text.color = _removedTextColour;
        }
    }
}
