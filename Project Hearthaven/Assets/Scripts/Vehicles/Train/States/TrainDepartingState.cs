namespace ProjectHearthaven.Vehicles.Train.States
{
    public class TrainDepartingState : TrainState
    {
        public TrainDepartingState(TrainStateController stateController)
            : base(stateController) { }

        public override void OnEnter()
        {
            base.OnEnter();

            for (int i = 0; i < stateController.Doors.Length; i++)
            {
                stateController.Doors[i].Close();
            }

            stateController.DepartingAnimation.DOPlayById("1");
        }
    }
}
