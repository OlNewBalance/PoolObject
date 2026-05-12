using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _lookSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _jumpHeight;

    private Vector3 _direction;

    public void Movement(ref Vector3 inputDirection)
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, MoveDirection(inputDirection), _moveSpeed * Time.deltaTime);
    }

    public void Jumping()
    {
        _direction.y = transform.position.y + _jumpHeight;

        gameObject.transform.position = Vector3.MoveTowards(transform.position, _direction, _jumpSpeed * Time.deltaTime);
    }

    private Vector3 MoveDirection(Vector3 moveDirection)
    {
        _direction.z = transform.position.z + moveDirection.z;
        _direction.x = transform.position.x + moveDirection.x;

        Vector3 direction = new Vector3(_direction.x, 0, _direction.z);
        return direction;
    }
}
