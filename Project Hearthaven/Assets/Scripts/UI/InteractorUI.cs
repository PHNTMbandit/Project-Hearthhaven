using ProjectHearthaven.Capabilities;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectHearthaven.UI
{
    [RequireComponent(typeof(UIPanel))]
    public class InteractorUI : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        private UIPanel _UIPanel;

        private void Awake()
        {
            _UIPanel = GetComponent<UIPanel>();
        }

        public void ShowUI(Interactable interactable)
        {
            _UIPanel.Open();
            _icon.sprite = interactable.InteractSprite;
        }

        public void HideUI()
        {
            _UIPanel.Close();
        }
    }
}
