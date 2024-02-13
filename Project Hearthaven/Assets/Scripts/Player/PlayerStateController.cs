using ProjectHearthaven.Character;
using ProjectHearthaven.Player.States.SubStates;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectHearthaven.Player
{
    [AddComponentMenu("Player/State Controller")]
    [RequireComponent(typeof(CharacterMove))]
    public class PlayerStateController : MonoBehaviour
    {
        [field: BoxGroup("Input"), SerializeField]
        public InputReader InputReader { get; private set; }

        public Animator[] Animators { get; private set; }
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerWalkState WalkState { get; private set; }
        public CharacterMove CharacterMove { get; private set; }

        private void Awake()
        {
            StateMachine = new();
            Animators = GetComponentsInChildren<Animator>();
            CharacterMove = GetComponent<CharacterMove>();

            IdleState = new(this, "idle");
            WalkState = new(this, "moving");
        }

        private void Start()
        {
            StateMachine.Initialise(IdleState);
        }

        private void Update()
        {
            StateMachine.CurrentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.OnFixedUpdate();
        }
    }
}
