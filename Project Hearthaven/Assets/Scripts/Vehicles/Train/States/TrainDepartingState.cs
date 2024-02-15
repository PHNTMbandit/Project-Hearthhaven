namespace ProjectHearthaven.Train.States
{
    public class TrainDepartingState : TrainState
    {
        public TrainDepartingState(TrainStateController stateController)
            : base(stateController) { }

        public override void OnEnter()
        {
            base.OnEnter();

            for (int i = 0; i < stateController.Animators.Length; i++)
            {
                stateController.Animators[i].SetTrigger("close");
            }
        }
    }
}
