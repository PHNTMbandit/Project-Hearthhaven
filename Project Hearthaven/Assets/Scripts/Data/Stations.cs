using System;
using UnityEditor;
using UnityEngine;

namespace ProjectHearthaven.Data
{
    [Serializable]
    public class Station
    {
        public string stationName;
        public SceneAsset scene;
    }

    [CreateAssetMenu(menuName = "Data/Stations", fileName = "Stations")]
    public class Stations : ScriptableObject
    {
        [SerializeField]
        private Station[] _stations;

        public Station GetStation(string name)
        {
            return Array.Find(_stations, i => i.stationName == name);
        }
    }
}
