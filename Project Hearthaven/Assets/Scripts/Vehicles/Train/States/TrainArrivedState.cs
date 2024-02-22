using System;
using UnityEngine;

namespace ProjectHearthaven.Vehicles.Train.States
{
    public class TrainArrivedState : TrainState
    {
        public TrainArrivedState(TrainStateController stateController)
            : base(stateController) { }

        public override void OnEnter()
        {
            base.OnEnter();

            for (int i = 0; i < stateController.Doors.Length; i++)
            {
                stateController.Doors[i].Open();
            }

            if (
                stateController.Player.StateMachine.CurrentState
                == stateController.Player.OnTrainState
            )
            {
                stateController.Player.transform.position =
                    Array.Find(stateController.Doors, i => i.HasPlayer == true).transform.position
                    + new Vector3(0, 3);
                stateController.Player.StateMachine.ChangeState(
                    stateController.Player.ExitTrainState
                );
                stateController.StateMachine.ChangeState(stateController.DepartingState);
            }
        }
    }
}
