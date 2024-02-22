using ProjectHearthaven.Player.States.SuperStates;
using UnityEngine;

namespace ProjectHearthaven.Player.States.SubStates
{
    public class PlayerWalkState : PlayerMoveState
    {
        public PlayerWalkState(PlayerStateController stateController, string stateAnimationName)
            : base(stateController, stateAnimationName) { }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (stateController.InputReader.MoveInput == Vector2.zero)
            {
                stateController.StateMachine.ChangeState(stateController.IdleState);
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.CharacterMove.Move(stateController.InputReader.MoveInput);
        }
    }
}
