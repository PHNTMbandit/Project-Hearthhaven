namespace ProjectHearthaven.Vehicles.Train.States
{
    public class TrainArrivingState : TrainState
    {
        public TrainArrivingState(TrainStateController stateController)
            : base(stateController) { }

        public override void OnEnter()
        {
            base.OnEnter();

            stateController.DepartingAnimation.DOPlayById("0");
            stateController.ArriveAnimation.onComplete.AddListener(CompleteState);
        }

        public override void OnExit()
        {
            base.OnExit();

            stateController.ArriveAnimation.onComplete.RemoveListener(CompleteState);
        }

        private void CompleteState()
        {
            stateController.StateMachine.ChangeState(stateController.ArrivedState);
        }
    }
}
