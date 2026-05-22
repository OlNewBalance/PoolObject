using UnityEngine;

public class InputService : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private PlayerInput _inputActions;

    private void Awake()
    {
        _inputActions = new PlayerInput();
        _inputActions.Enable();
    }

    private void Update()
    {
        ReadMovement();
        ReadMouse();
    }

    private void OnEnable()
    {
        _inputActions.Player.Jump.performed += JumpPerformed;
    }

    private void OnDisable()
    {
        _inputActions.Player.Jump.performed -= JumpPerformed;
    }

    private void JumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _playerMovement.Jumping();
    }

    private void ReadMovement()
    {
        Vector3 inputDirection = _inputActions.Player.Move.ReadValue<Vector3>();

        if (inputDirection != Vector3.zero)
        {
            _playerMovement.Movement(ref inputDirection);
        }
    }
}
