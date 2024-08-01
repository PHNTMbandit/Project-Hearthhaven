using System.Collections.Generic;
using ProjectHearthaven.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectHearthaven.UI
{
    public class StationsListUI : MonoBehaviour
    {
        [SerializeField]
        private Stations _stationData;

        [SerializeField]
        private StationsButton _templateStationsButton;

        [SerializeField]
        private Transform _transform;

        private readonly List<StationsButton> _buttons = new();

        private void Awake()
        {
            _templateStationsButton.gameObject.SetActive(false);
        }

        public void GenerateList()
        {
            ResetList();

            foreach (Station station in _stationData.stations)
            {
                if (SceneManager.GetActiveScene().name == station.stationName)
                {
                    continue;
                }

                StationsButton button = Instantiate(_templateStationsButton.gameObject, _transform)
                    .GetComponent<StationsButton>();

                button.gameObject.SetActive(true);
                button.SetStation(station);
                button.SetName(station.stationName);
                button.SetCostText(station.cost);

                _buttons.Add(button);
            }
        }

        private void ResetList()
        {
            if (_buttons.Count > 0)
            {
                foreach (StationsButton button in _buttons)
                {
                    Destroy(button.gameObject);
                }

                _buttons.Clear();
            }
        }
    }
}
