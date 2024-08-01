using ProjectHearthaven.Capabilities;
using ProjectHearthaven.Character;
using ProjectHearthaven.Data;
using ProjectHearthaven.Vehicles.Train;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectHearthaven.UI
{
    public class StationsButton : MonoBehaviour
    {
        public Station Station { get; private set; }

        [SerializeField]
        private TextMeshProUGUI _name,
            _cost;

        [SerializeField]
        private Interactable _ticketGate;

        [SerializeField]
        private Animateable _ticketGateAnimator;

        [SerializeField]
        private TrainStateController _train;

        [SerializeField]
        private UIPanel _stationsPanel;

        [SerializeField]
        private CharacterBankAccount _player;

        [SerializeField]
        private Button _button;

        public void SetStation(Station station)
        {
            Station = station;
            _button.interactable = _player.CanAfford(Station.cost);
        }

        public void SetName(string name)
        {
            _name.SetText(name);
        }

        public void SetCostText(int cost)
        {
            _cost.SetText($"<sprite name=Small Coin> {cost:C}");
        }

        public void OnClick()
        {
            if (_player.CanAfford(Station.cost))
            {
                _train.CallTrain(Station);
                _player.RemoveDollars(Station.cost);
                _ticketGate.SetInteractable(false);
                _ticketGateAnimator.SetState("open");
                _stationsPanel.Close();
            }
        }
    }
}
