using ProjectHearthaven.Player.States.SuperStates;

namespace ProjectHearthaven.Player.States.SubStates
{
    public class PlayerOnTrainState : PlayerTravellingState
    {
        public PlayerOnTrainState(PlayerStateController stateController, string stateAnimationName)
            : base(stateController, stateAnimationName) { }

        public override void OnEnter()
        {
            base.OnEnter();

            for (int i = 0; i < stateController.Sprites.Length; i++)
            {
                stateController.Sprites[i].color = new(1, 1, 1, 0);
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            for (int i = 0; i < stateController.Sprites.Length; i++)
            {
                stateController.Sprites[i].color = new(1, 1, 1, 1);
            }
        }
    }
}
