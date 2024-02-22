using System;
using PixelCrushers;
using ProjectHearthaven.Vehicles.Train;
using UnityEngine;

namespace ProjectHearthaven.Savers
{
    [AddComponentMenu("Savers/Train Door Saver")]
    [RequireComponent(typeof(TrainDoor))]
    public class TrainDoorSaver : Saver
    {
        [Serializable]
        public class Data
        {
            public bool hasPlayer;
        }

        private Data _data = new();
        private TrainDoor _trainDoor;

        public override void Awake()
        {
            base.Awake();

            _trainDoor = GetComponent<TrainDoor>();
        }

        public override string RecordData()
        {
            _data.hasPlayer = _trainDoor.HasPlayer;
            print(_data.hasPlayer);

            return SaveSystem.Serialize(_data);
        }

        public override void ApplyData(string s)
        {
            if (_trainDoor == null || string.IsNullOrEmpty(s))
            {
                return;
            }

            var data = SaveSystem.Deserialize(s, _data);

            if (data == null)
            {
                return;
            }

            _data = data;
            _trainDoor.SetHasPlayer(data.hasPlayer);
        }
    }
}
