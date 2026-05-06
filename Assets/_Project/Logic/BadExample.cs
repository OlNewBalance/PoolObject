using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPatrool : MonoBehaviour
{
    private Transform _pointsParent;
    private Transform[] _pointsArray;

    private float _speed;
    private float _minDistance = 0.5f;
    private int _pointIndex;

    private void Start() 
    {
        _pointsArray = new Transform[_pointsParent.childCount];

        for (int i = 0; i < _pointsArray.Length; i++)
        {
            _pointsArray[i] = _pointsParent.GetChild(i);
        }
    }

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        Vector3 point = _pointsArray[_pointIndex].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, point, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, point) <= _minDistance)
        {
            ChangePoint();
        }
    }

    private Vector3 ChangePoint()
    {
        _pointIndex++;

        if (_pointIndex == _pointsArray.Length)
        {
            _pointIndex  = 0;
        }
                
        Vector3 point = _pointsArray[_pointIndex].transform.position;
        Vector3 direction = point - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);

        return point; 
    }
}