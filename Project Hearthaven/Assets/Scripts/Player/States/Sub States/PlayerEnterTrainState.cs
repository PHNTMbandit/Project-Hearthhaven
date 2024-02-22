using DG.Tweening;
using ProjectHearthaven.Player.States.SuperStates;
using UnityEngine;

namespace ProjectHearthaven.Player.States.SubStates
{
    public class PlayerEnterTrainState : PlayerTravellingState
    {
        public PlayerEnterTrainState(
            PlayerStateController stateController,
            string stateAnimationName
        )
            : base(stateController, stateAnimationName) { }

        public override void OnEnter()
        {
            base.OnEnter();

            stateController.Collider.enabled = false;

            for (int i = 0; i < stateController.Sprites.Length; i++)
            {
                stateController
                    .Sprites[i]
                    .DOFade(0, 1)
                    .OnComplete(
                        delegate
                        {
                            stateController.StateMachine.ChangeState(stateController.OnTrainState);
                        }
                    );
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            stateController.CharacterMove.Move(new Vector2(0, stateController.EnterExitTrainSpeed));
        }
    }
}
