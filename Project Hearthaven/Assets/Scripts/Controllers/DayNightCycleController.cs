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
        public DateTime CurrentTime { get; private set; }

        [TabGroup("Settings"), SerializeField, Range(1990, 2100)]
        private int _year;

        [TabGroup("Settings"), SerializeField, Range(1, 12)]
        private int _month;

        [TabGroup("Settings"), SerializeField, Range(1, 31)]
        private int _date;

        [TabGroup("Settings"), SerializeField, Range(0, 23)]
        private int _hour;

        [TabGroup("Settings"), SerializeField, Range(0, 59)]
        private int _minute;

        [TabGroup("Settings"), Space, SerializeField, Range(0, 10), SuffixLabel("seconds")]
        private float _minutePerSeconds;

        [TabGroup("Lighting"), SerializeField]
        private AnimationCurve _cycleCurve;

        [TabGroup("Lighting"), SerializeField]
        private Light2D _globalLight;

        public UnityAction onTimeUpdate;

        private void Start()
        {
            CurrentTime = new DateTime(_year, _month, _date, _hour, _minute, 0);

            StartCoroutine(UpdateTime());
        }

        private IEnumerator UpdateTime()
        {
            while (true)
            {
                CurrentTime = CurrentTime.AddMinutes(1);

                _globalLight.intensity = _cycleCurve.Evaluate(
                    (float)CurrentTime.TimeOfDay.TotalMinutes
                );

                onTimeUpdate?.Invoke();

                yield return new WaitForSeconds(_minutePerSeconds);
            }
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
