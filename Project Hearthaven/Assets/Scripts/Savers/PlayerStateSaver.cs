using System;
using PixelCrushers;
using ProjectHearthaven.Character;
using ProjectHearthaven.Player;
using UnityEngine;

namespace ProjectHearthaven.Savers
{
    [AddComponentMenu("Savers/Player State Saver")]
    [RequireComponent(typeof(PlayerStateController))]
    public class PlayerStateSaver : Saver
    {
        [Serializable]
        public class Data
        {
            public string playerStateName;
        }

        private Data _data = new();
        private PlayerStateController _stateController;

        public override void Awake()
        {
            base.Awake();

            _stateController = GetComponent<PlayerStateController>();
        }

        public override string RecordData()
        {
            _data.playerStateName = _stateController.StateMachine.CurrentState.ToString();

            return SaveSystem.Serialize(_data);
        }

        public override void ApplyData(string s)
        {
            if (_stateController == null || string.IsNullOrEmpty(s))
            {
                return;
            }

            var data = SaveSystem.Deserialize(s, _data);

            if (data == null)
            {
                return;
            }

            _data = data;
            _stateController.StateMachine.ChangeState(
                _stateController.GetPlayerState(data.playerStateName)
            );
        }
    }
}
