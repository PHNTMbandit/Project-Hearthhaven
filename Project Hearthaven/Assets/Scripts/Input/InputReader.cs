using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Input Reader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, GameControls.IPlayerActions
{
    public GameControls GameControls { get; private set; }
    public Vector2 MoveInput { get; private set; }

    public UnityAction onInteract;

    private void OnEnable()
    {
        GameControls ??= new GameControls();

        EnableGameplayInput(true);
    }

    private void OnDisable()
    {
        EnableGameplayInput(false);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onInteract?.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void EnableGameplayInput(bool enable)
    {
        if (enable)
        {
            GameControls.Player.AddCallbacks(this);
            GameControls.Player.Enable();
        }
        else
        {
            GameControls.Player.RemoveCallbacks(this);
            GameControls.Player.Disable();
        }
    }
}
