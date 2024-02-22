namespace ProjectHearthaven.Vehicles.Train.States
{
    public class TrainWaitingState : TrainState
    {
        public TrainWaitingState(TrainStateController stateController)
            : base(stateController) { }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (
                stateController.Player.StateMachine.CurrentState
                == stateController.Player.OnTrainState
            )
            {
                stateController.StateMachine.Initialise(stateController.ArrivingState);
            }
        }
    }
}
