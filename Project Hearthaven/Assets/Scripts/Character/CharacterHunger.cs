using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectHearthaven.Character
{
    [AddComponentMenu("Character/Character Hunger")]
    public class CharacterHunger : MonoBehaviour
    {
        public float CurrentHunger
        {
            get => _currentHunger;
            set =>
                _currentHunger =
                    value <= 0
                        ? 0
                        : value >= _maxHunger
                            ? _maxHunger
                            : value;
        }

        public float MaxHunger => _maxHunger;

        [BoxGroup("Health"), Range(0, 1000), LabelWidth(125), SerializeField]
        private float _maxHunger;

        [
            BoxGroup("Hunger"),
            ProgressBar(0, "_maxHunger", ColorGetter = "GetHealthBarColour"),
            LabelWidth(125),
            SerializeField
        ]
        private float _currentHunger;

        private Color GetHealthBarColour(float value)
        {
            return Color.Lerp(Color.red, Color.green, Mathf.Pow(value / _maxHunger, .5f));
        }
    }
}
