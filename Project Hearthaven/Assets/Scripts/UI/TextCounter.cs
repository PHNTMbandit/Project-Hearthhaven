using System;
using System.Collections;
using ProjectHearthaven.Character;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace ProjectHearthaven.UI
{
    [Serializable]
    public enum TextType
    {
        Number,
        Currency
    }

    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextCounter : MonoBehaviour
    {
        [BoxGroup("Settings"), EnumToggleButtons, SerializeField]
        private TextType _textType;

        [BoxGroup("Settings"), SerializeField]
        private string _prefix;

        [BoxGroup("Settings"), SerializeField, Range(0, 10)]
        private float _countDuration = 1;

        [BoxGroup("References"), SerializeField]
        private CharacterBankAccount _bankAccount;

        private Coroutine _C2T;
        private TextMeshProUGUI _text;
        private float _currentValue,
            targetValue;

        void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        void Start()
        {
            _currentValue = _bankAccount.Dollars;
            targetValue = _currentValue;

            SetText();
        }

        public void SetTarget(float target)
        {
            targetValue = target;

            if (_C2T != null)
            {
                StopCoroutine(_C2T);
            }

            _C2T = StartCoroutine(CountTo(targetValue));
        }

        private IEnumerator CountTo(float targetValue)
        {
            var rate = Mathf.Abs(targetValue - _currentValue) / _countDuration;

            while (_currentValue != targetValue)
            {
                _currentValue = Mathf.MoveTowards(
                    _currentValue,
                    targetValue,
                    rate * Time.deltaTime
                );

                SetText();

                yield return null;
            }
        }

        private void SetText()
        {
            switch (_textType)
            {
                case TextType.Number:
                    _text.SetText($"{_prefix} {_currentValue}");
                    break;

                case TextType.Currency:
                    _text.SetText($"{_prefix} {_currentValue:C0}");
                    break;
            }
        }
    }
}
