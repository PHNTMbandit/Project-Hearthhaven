using ProjectHearthaven.Character;
using ProjectHearthaven.Player.States.SubStates;
using ProjectHearthaven.Player.States.SuperStates;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectHearthaven.Player
{
    [AddComponentMenu("Player/Player State Controller")]
    [RequireComponent(typeof(CharacterMove))]
    [RequireComponent(typeof(Collider2D))]
    public class PlayerStateController : MonoBehaviour
    {
        [field: BoxGroup("Input"), SerializeField]
        public InputReader InputReader { get; private set; }

        [field: BoxGroup("Settings"), Range(0, 1), SerializeField]
        public float EnterExitTrainSpeed { get; private set; }

        public Collider2D Collider { get; private set; }
        public Animator[] Animators { get; private set; }
        public SpriteRenderer[] Sprites { get; private set; }
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerEnterTrainState EnterTrainState { get; private set; }
        public PlayerExitTrainState ExitTrainState { get; private set; }
        public PlayerOnTrainState OnTrainState { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerWalkState WalkState { get; private set; }
        public CharacterMove CharacterMove { get; private set; }

        private void Awake()
        {
            StateMachine = new();
            Animators = GetComponentsInChildren<Animator>();
            CharacterMove = GetComponent<CharacterMove>();
            Collider = GetComponent<Collider2D>();
            Sprites = GetComponentsInChildren<SpriteRenderer>();

            EnterTrainState = new(this, "moving");
            ExitTrainState = new(this, "moving");
            IdleState = new(this, "idle");
            OnTrainState = new(this, "idle");
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

        public void BoardTrain()
        {
            StateMachine.ChangeState(EnterTrainState);
        }

        public void ExitTrain()
        {
            StateMachine.ChangeState(ExitTrainState);
        }
    }
}
