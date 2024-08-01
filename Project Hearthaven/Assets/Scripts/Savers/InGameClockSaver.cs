using System;
using PixelCrushers;
using ProjectHearthaven.Controllers;
using UnityEngine;

namespace ProjectHearthaven.Savers
{
    [AddComponentMenu("Savers/InGameClockSaver")]
    [RequireComponent(typeof(InGameClockCycleController))]
    public class InGameClockSaver : Saver
    {
        [Serializable]
        public class Data
        {
            public int year,
                month,
                day,
                hour,
                minute;
        }

        private Data _data = new();
        private InGameClockCycleController _dayNightCycle;

        public override void Awake()
        {
            base.Awake();

            _dayNightCycle = GetComponent<InGameClockCycleController>();
        }

        public override string RecordData()
        {
            _data.year = _dayNightCycle.Clock.Year;
            _data.month = _dayNightCycle.Clock.Month;
            _data.day = _dayNightCycle.Clock.Day;
            _data.hour = _dayNightCycle.Clock.Hour;
            _data.minute = _dayNightCycle.Clock.Minute;

            return SaveSystem.Serialize(_data);
        }

        public override void ApplyData(string s)
        {
            if (_dayNightCycle == null || string.IsNullOrEmpty(s))
            {
                return;
            }

            var data = SaveSystem.Deserialize(s, _data);

            if (data == null)
            {
                return;
            }

            _data = data;
            _dayNightCycle.SetClock(
                new(_data.year, _data.month, _data.day, _data.hour, _data.minute, 0)
            );
        }
    }
}
