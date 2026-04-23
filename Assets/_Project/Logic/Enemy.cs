using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;

    private ObjectPool _poolObjects;
    private Vector3 _targetPosition;

    public void Init(ObjectPool poolObjects, Transform targetPosition)
    {
        _targetPosition = targetPosition.transform.position;
        _poolObjects = poolObjects;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
}
