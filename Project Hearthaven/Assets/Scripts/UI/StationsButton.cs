using ProjectHearthaven.Capabilities;
using ProjectHearthaven.Character;
using ProjectHearthaven.Data;
using ProjectHearthaven.Vehicles.Train;
using TMPro;
using UnityEngine;

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

        public void SetStation(Station station)
        {
            Station = station;
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
            _train.CallTrain(Station);
            _player.RemoveDollars(Station.cost);
            _ticketGate.SetInteractable(false);
            _ticketGateAnimator.SetState("open");
            _stationsPanel.Close();
        }
    }
}
