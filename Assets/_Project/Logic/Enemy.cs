using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _targetPosition;

    private void Update()
    {
        Move();
    }

    public void Init(Transform targetPosition,Transform spawnCharacteristics)
    {
        gameObject.transform.position = spawnCharacteristics.position;
        gameObject.transform.rotation = spawnCharacteristics.rotation;

        _targetPosition = targetPosition.transform.position;
    }

    private void Move()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
}
