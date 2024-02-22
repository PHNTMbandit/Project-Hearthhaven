using DG.Tweening;
using ProjectHearthaven.Player.States.SuperStates;

namespace ProjectHearthaven.Player.States.SubStates
{
    public class PlayerOnTrainState : PlayerTravellingState
    {
        public PlayerOnTrainState(PlayerStateController stateController, string stateAnimationName)
            : base(stateController, stateAnimationName) { }
    }
}
