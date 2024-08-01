using ProjectHearthaven.Controllers;
using TMPro;
using UnityEngine;

namespace ProjectHearthaven.UI
{
    public class DateTimeText : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _timeText,
            _dateText;

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
            _timeText.SetText($"<sprite name=Clock> {_dayNightCycle.InGameClock:h:mm tt}");
            _dateText.SetText(_dayNightCycle.InGameClock.ToString("ddd d MMM"));
        }
    }
}
