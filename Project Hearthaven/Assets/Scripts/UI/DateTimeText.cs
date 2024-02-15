using TMPro;
using UnityEngine;

namespace ProjectHearthaven.UI
{
    public class DateTimeText : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        [SerializeField]
        private DayNightCycleController _dayNightCycle;

        private void Awake()
        {
            _dayNightCycle.onTimeUpdate += UpdateUI;
        }

        private void Start()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            _text.SetText(_dayNightCycle.CurrentTime.ToString("G"));
        }
    }
}
