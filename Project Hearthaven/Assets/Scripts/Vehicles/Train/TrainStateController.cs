using DG.Tweening;
using ProjectHearthaven.Train.States;
using UnityEngine;

namespace ProjectHearthaven.Train
{
    public class TrainStateController : MonoBehaviour
    {
        [field: SerializeField]
        public Animator[] Animators { get; private set; }

        [field: SerializeField]
        public DOTweenAnimation ArriveAnimation { get; private set; }

        public TrainStateMachine StateMachine { get; private set; }
        public TrainArrivingState ArrivingState { get; private set; }
        public TrainArrivedState ArrivedState { get; private set; }
        public TrainDepartingState DepartingState { get; private set; }

        private void Awake()
        {
            StateMachine = new();

            ArrivingState = new(this);
            ArrivedState = new(this);
            DepartingState = new(this);
        }

        private void Start()
        {
            StateMachine.Initialise(ArrivingState);
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
