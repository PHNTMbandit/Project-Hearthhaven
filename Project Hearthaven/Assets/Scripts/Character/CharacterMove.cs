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

        private Animator[] _animators;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _animators = GetComponentsInChildren<Animator>();
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 input)
        {
            for (int i = 0; i < _animators.Length; i++)
            {
                Vector2 movement = new(input.x, input.y);
                _rb.MovePosition(_rb.position + _walkSpeed * Time.fixedDeltaTime * movement);

                _animators[i].SetFloat("move x", input.x);
                _animators[i].SetFloat("move y", input.y);
            }
        }
    }
}
