using DG.Tweening;
using ProjectHearthaven.Vehicles.Train.States;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectHearthaven.Vehicles.Train
{
    public class TrainStateController : MonoBehaviour
    {
        [field: BoxGroup("Animations"), SerializeField]
        public TrainDoor[] Doors { get; private set; }

        [field: BoxGroup("Animations"), SerializeField]
        public DOTweenAnimation ArriveAnimation { get; private set; }

        [field: BoxGroup("Animations"), SerializeField]
        public DOTweenAnimation DepartingAnimation { get; private set; }

        public TrainStateMachine StateMachine { get; private set; }
        public TrainArrivingState ArrivingState { get; private set; }
        public TrainArrivedState ArrivedState { get; private set; }
        public TrainDepartingState DepartingState { get; private set; }
        public TrainWaitingState WaitingState { get; private set; }

        public UnityEvent onTrainArriving,
            onTrainDeparting;

        private void Awake()
        {
            StateMachine = new();

            ArrivingState = new(this);
            ArrivedState = new(this);
            DepartingState = new(this);
            WaitingState = new(this);
        }

        private void Start()
        {
            StateMachine.Initialise(WaitingState);
        }

        private void Update()
        {
            StateMachine.CurrentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.OnFixedUpdate();
        }

        public void CallTrain()
        {
            StateMachine.ChangeState(ArrivingState);

            onTrainArriving?.Invoke();
        }

        public void DepartTrain()
        {
            StateMachine.ChangeState(DepartingState);

            onTrainDeparting?.Invoke();
        }
    }
}
