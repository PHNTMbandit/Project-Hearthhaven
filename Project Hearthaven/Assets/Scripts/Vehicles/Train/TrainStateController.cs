using DG.Tweening;
using PixelCrushers;
using ProjectHearthaven.Data;
using ProjectHearthaven.Player;
using ProjectHearthaven.Vehicles.Train.States;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectHearthaven.Vehicles.Train
{
    public class TrainStateController : MonoBehaviour
    {
        public Station Destination { get; private set; }

        [BoxGroup("Tweens")]
        [BoxGroup("Tweens/Arriving"), SerializeField]
        private Transform _arrivalTarget;

        [BoxGroup("Tweens/Arriving"), Range(0, 10), SerializeField]
        private float _arrivingDuration,
            _arrivingDelay;

        [BoxGroup("Tweens/Arriving"), EnumPaging, SerializeField]
        private Ease _arrivingEaseType;

        [BoxGroup("Tweens/Departing"), SerializeField]
        private Transform _departingTarget;

        [BoxGroup("Tweens/Departing"), Range(0, 10), SerializeField]
        private float _departingDuration,
            _departingDelay;

        [BoxGroup("Tweens/Departing"), EnumPaging, SerializeField]
        private Ease _departingEaseType;

        [BoxGroup("References"), SerializeField]
        private Transform _resetPoint;

        [field: BoxGroup("References"), SerializeField]
        public PlayerStateController Player { get; private set; }

        [field: BoxGroup("References"), SerializeField]
        public TrainDoor[] Doors { get; private set; }

        public TrainStateMachine StateMachine { get; private set; }
        public TrainArrivingState ArrivingState { get; private set; }
        public TrainArrivedState ArrivedState { get; private set; }
        public TrainDepartingState DepartingState { get; private set; }
        public TrainWaitingState WaitingState { get; private set; }

        public UnityEvent onTrainDeparting;

        private void Awake()
        {
            StateMachine = new();

            ArrivingState = new(this);
            ArrivedState = new(this);
            DepartingState = new(this);
            WaitingState = new(this);

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

        public void CallTrain(Station destination)
        {
            StateMachine.ChangeState(ArrivingState);
            Destination = destination;
        }

        public void DepartTrain()
        {
            StateMachine.ChangeState(DepartingState);

            onTrainDeparting?.Invoke();
        }

        public void ResetTrain()
        {
            transform.DORewind();
            transform.position = _resetPoint.position;
        }

        public void MoveToArrivalTarget()
        {
            transform
                .DOMoveX(_arrivalTarget.position.x, _arrivingDuration)
                .SetDelay(_arrivingDelay)
                .SetEase(_arrivingEaseType)
                .OnComplete(
                    delegate
                    {
                        StateMachine.ChangeState(ArrivedState);
                    }
                );
        }

        public void MoveToDepartingTarget()
        {
            transform
                .DOMoveX(_departingTarget.position.x, _departingDuration)
                .SetDelay(_departingDelay)
                .SetEase(_departingEaseType)
                .OnComplete(
                    delegate
                    {
                        TravelToDestination();
                    }
                );
        }

        public void TravelToDestination()
        {
            if (Destination != null)
            {
                SaveSystem.LoadScene(Destination.scene.name);
            }
            else
            {
                StateMachine.ChangeState(WaitingState);
            }
        }
    }
}
