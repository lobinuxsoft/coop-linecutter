using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private CharacterMovement leftAvatar;
    [SerializeField] private CharacterMovement rightAvatar;

    public void OnMoveLeftAvatar(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        leftAvatar.MoveDir(new Vector3(input.x, 0, input.y));
    }
    
    public void OnMoveRightAvatar(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        rightAvatar.MoveDir(new Vector3(input.x, 0, input.y));
    }
}
