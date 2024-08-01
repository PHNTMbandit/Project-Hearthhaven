namespace ProjectHearthaven.Player.States.SuperStates
{
    public class PlayerTravellingState : PlayerState
    {
        public PlayerTravellingState(
            PlayerStateController stateController,
            string stateAnimationName
        )
            : base(stateController, stateAnimationName) { }
    }
}
