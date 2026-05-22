using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Coroutine _coroutine;
    [SerializeField] private Cube _cube;

    private InputSystem_Actions _inputActions;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Enable();
    }

    private void OnEnable()
    {
        _inputActions.CoroutineMap.RButton.performed += RButton;
        _inputActions.CoroutineMap.SpaceButton.performed += SpaceButton;
    }

    private void RButton(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _cube.ResetFading();
    }

    private void SpaceButton(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _cube.OnOffFading();
    }
}
