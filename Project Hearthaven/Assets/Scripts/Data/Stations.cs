using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace ProjectHearthaven.Data
{
    [Serializable]
    public class Station
    {
        public string stationName;
        public SceneAsset scene;

        [Range(0, 100), SuffixLabel("dollars")]
        public int cost;

        [Range(0, 1000), SuffixLabel("minutes")]
        public int travelTime;
    }

    [CreateAssetMenu(menuName = "Data/Stations", fileName = "Stations")]
    public class Stations : ScriptableObject
    {
        public Station[] stations;

        public Station GetStation(string name)
        {
            return Array.Find(stations, i => i.stationName == name);
        }
    }
}
