using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectHearthaven.Vehicles.Train
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider2D))]
    public class TrainDoor : MonoBehaviour
    {
        [ShowInInspector]
        public bool HasPlayer { get; private set; }

        [SerializeField]
        private TrainStateController _trainController;

        private Animator _animator;
        private Collider2D _collider;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _trainController.DepartTrain();
                HasPlayer = true;
            }
        }

        private void Start()
        {
            _collider.enabled = false;
        }

        public void Open()
        {
            _collider.enabled = true;
            _animator.SetTrigger("open");
        }

        public void Close()
        {
            _collider.enabled = false;
            _animator.SetTrigger("close");
        }

        public void SetHasPlayer(bool hasPlayer)
        {
            HasPlayer = hasPlayer;
        }
    }
}
