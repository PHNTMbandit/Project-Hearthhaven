using ProjectHearthaven.Player.States.SuperStates;
using UnityEngine;

namespace ProjectHearthaven.Player.States.SubStates
{
    public class PlayerIdleState : PlayerMoveState
    {
        public PlayerIdleState(PlayerStateController stateController, string stateAnimationName)
            : base(stateController, stateAnimationName) { }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (stateController.InputReader.MoveInput != Vector2.zero)
            {
                stateController.StateMachine.ChangeState(stateController.WalkState);
            }
        }
    }
}
