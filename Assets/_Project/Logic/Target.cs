using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints = new List<Transform>();
    [SerializeField] private ObjectPool _poolObjects;

    [SerializeField] private float _speed;
    [SerializeField] private float _waitForSeconds;

    private Vector3 _currentPointToDisplacement;
    private Vector3 point1;
    private Vector3 point2;

    private float _distancePointOne;
    private float _distancePointTwo;
    private float _minDistance = 0.5f;

    private void Start()
    {
        point1 = _patrolPoints.Single(p => p.name == "Point1").transform.position;
        point2 = _patrolPoints.Single(p => p.name == "Point2").transform.position;

        _currentPointToDisplacement = point1;
    }

    private void Update()
    {
        _distancePointOne = Vector3.Distance(gameObject.transform.position, point1);
        _distancePointTwo = Vector3.Distance(gameObject.transform.position, point2);

        if (_distancePointOne <= _minDistance)
        {
            _currentPointToDisplacement = point2;
        }

        if (_distancePointTwo <= _minDistance)
        {
            _currentPointToDisplacement = point1;
        }

        gameObject.transform.position = Vector3.MoveTowards(transform.position, _currentPointToDisplacement, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy) != false)
        {
            _poolObjects.Put(enemy);
        }
        
        return; 
    }
}
