using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

namespace ProjectHearthaven.Controllers
{
    public class DayNightCycleController : MonoBehaviour
    {
        public DateTime InGameClock { get; private set; }

        [TabGroup("Settings"), SerializeField, Range(1990, 2100)]
        private int _year;

        [TabGroup("Settings"), SerializeField, Range(1, 12)]
        private int _month;

        [TabGroup("Settings"), SerializeField, Range(1, 31)]
        private int _day;

        [TabGroup("Settings"), SerializeField, Range(0, 23)]
        private int _hour;

        [TabGroup("Settings"), SerializeField, Range(0, 59)]
        private int _minute;

        [TabGroup("Settings"), Space, SerializeField, Range(0, 10), SuffixLabel("seconds")]
        private float _minutePerSeconds;

        [TabGroup("Lighting"), ToggleLeft, SerializeField]
        private bool _isUnderground;

        [TabGroup("Lighting"), HideIf("_isUnderground"), SerializeField]
        private AnimationCurve _cycleCurve;

        [TabGroup("Lighting"), HideIf("_isUnderground"), SerializeField]
        private Light2D _globalLight;

        public UnityAction onTimeUpdate;

        private void Awake()
        {
            SetClock(new(_year, _month, _day, _hour, _minute, 0));

            if (_isUnderground)
            {
                _globalLight.intensity = 1;
            }

            StartCoroutine(UpdateClock());
        }

        private IEnumerator UpdateClock()
        {
            while (true)
            {
                InGameClock = InGameClock.AddMinutes(1);

                if (!_isUnderground)
                {
                    _globalLight.intensity = _cycleCurve.Evaluate(
                        (float)InGameClock.TimeOfDay.TotalMinutes
                    );
                }

                onTimeUpdate?.Invoke();

                yield return new WaitForSeconds(_minutePerSeconds);
            }
        }

        public void SetClock(DateTime clock)
        {
            InGameClock = new DateTime(
                clock.Year,
                clock.Month,
                clock.Day,
                clock.Hour,
                clock.Minute,
                clock.Second
            );
        }

        public TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
        {
            TimeSpan difference = toTime - fromTime;

            if (difference.TotalSeconds < 0)
            {
                difference += TimeSpan.FromHours(24);
            }

            return difference;
        }
    }
}
