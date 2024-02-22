namespace ProjectHearthaven.Vehicles.Train.States
{
    public class TrainArrivingState : TrainState
    {
        public TrainArrivingState(TrainStateController stateController)
            : base(stateController) { }

        public override void OnEnter()
        {
            base.OnEnter();

            stateController.MoveToArrivalTarget();
        }
    }
}
