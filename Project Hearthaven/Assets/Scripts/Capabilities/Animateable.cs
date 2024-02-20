using System;
using UnityEngine;

namespace ProjectHearthaven.Capabilities
{
    [Serializable]
    public class AnimationState
    {
        public string animationName;
    }

    [AddComponentMenu("Capabilities/Animateable")]
    [RequireComponent(typeof(Animator))]
    public class Animateable : MonoBehaviour
    {
        [SerializeField]
        private AnimationState[] _states;

        [SerializeField]
        private AnimationState _defaultState;

        private Animator _animator;
        private AnimationState _currentState;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            SetState(_defaultState.animationName);
        }

        public void SetState(string name)
        {
            if (_currentState != null)
            {
                _animator.SetBool(_currentState.animationName, false);
            }

            _currentState = Array.Find(_states, i => i.animationName == name);
            _animator.SetBool(_currentState.animationName, true);
        }
    }
}
