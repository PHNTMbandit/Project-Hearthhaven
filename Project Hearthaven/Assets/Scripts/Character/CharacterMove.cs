using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectHearthaven.Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    [AddComponentMenu("Character/Character Move")]
    public class CharacterMove : MonoBehaviour
    {
        [BoxGroup("Settings"), Range(0, 10), SerializeField]
        private float _walkSpeed;

        [BoxGroup("References"), SerializeField]
        private InputReader _inputReader;

        private Animator[] _animators;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _animators = GetComponentsInChildren<Animator>();
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Move()
        {
            for (int i = 0; i < _animators.Length; i++)
            {
                Vector2 movement = new(_inputReader.MoveInput.x, _inputReader.MoveInput.y);
                _rb.MovePosition(_rb.position + _walkSpeed * Time.fixedDeltaTime * movement);

                _animators[i].SetFloat("move x", _inputReader.MoveInput.x);
                _animators[i].SetFloat("move y", _inputReader.MoveInput.y);
            }
        }
    }
}
