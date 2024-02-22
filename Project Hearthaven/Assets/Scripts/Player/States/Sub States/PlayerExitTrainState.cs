using DG.Tweening;
using ProjectHearthaven.Player.States.SuperStates;
using UnityEngine;

namespace ProjectHearthaven.Player.States.SubStates
{
    public class PlayerExitTrainState : PlayerTravellingState
    {
        public PlayerExitTrainState(
            PlayerStateController stateController,
            string stateAnimationName
        )
            : base(stateController, stateAnimationName) { }

        public override void OnEnter()
        {
            base.OnEnter();

            for (int i = 0; i < stateController.Sprites.Length; i++)
            {
                stateController
                    .Sprites[i]
                    .DOFade(1, 1)
                    .From()
                    .OnComplete(
                        delegate
                        {
                            stateController.StateMachine.ChangeState(stateController.IdleState);
                        }
                    );
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            stateController.Collider.enabled = true;
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.CharacterMove.Move(new Vector2(0, stateController.EnterExitTrainSpeed));
        }
    }
}
