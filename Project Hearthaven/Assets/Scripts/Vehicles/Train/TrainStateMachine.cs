namespace ProjectHearthaven.Vehicles.Train
{
    public class TrainStateMachine
    {
        public TrainState CurrentState { get; private set; }

        public void Initialise(TrainState startingState)
        {
            CurrentState = startingState;
            startingState.OnEnter();
        }

        public void ChangeState(TrainState newState)
        {
            CurrentState.OnExit();
            CurrentState = newState;
            newState.OnEnter();
        }
    }
}
