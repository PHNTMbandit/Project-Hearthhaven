namespace ProjectHearthaven.Vehicles.Train
{
    public class TrainState
    {
        protected TrainStateController stateController;

        public TrainState(TrainStateController stateController)
        {
            this.stateController = stateController;
        }

        public virtual void OnEnter() { }

        public virtual void OnExit() { }

        public virtual void OnUpdate() { }

        public virtual void OnFixedUpdate() { }
    }
}
