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

    //public void Looking(ref Vector2 inputDirection)
    //{
    //    gameObject.transform.rotation = Quaternion.EulerRotation();
    //    gameObject.transform.rotation = Quaternion.LookRotation(LookDirection2(inputDirection));
    //    Quaternion a = Quaternion.LookRotation(LookDirection2(inputDirection));
    //    gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, LookDirection(inputDirection), _lookSpeed * Time.deltaTime);
    //}

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

//    private Quaternion LookDirection(Vector2 lookDirection)
//    {
//        Quaternion direction;
//        Ray ray = _camera.ScreenPointToRay(lookDirection);

//        if (Physics.Raycast(ray, out RaycastHit hit))
//        {
//            Vector2 vector = hit.transform.position;

//            float rotationX = vector.x;
//            float rotationY = vector.y;

//            direction = Quaternion.Euler(rotationX, rotationY, 0);
//            return direction;
//        }

//        return Quaternion.identity;
//    }

//    private Vector3 LookDirection2(Vector2 lookDirection)
//    {
//        Vector3 direction;
//        Ray ray = _camera.ScreenPointToRay(lookDirection);

//        if (Physics.Raycast(ray, out RaycastHit hit))
//        {
//            Vector2 vector = hit.transform.position;

//            float rotationX = vector.x;
//            float rotationY = vector.y;

//            direction = new Vector3(rotationX,rotationY, 0);
//            return direction;
//        }

//        return Vector3.zero;
//    }
}
