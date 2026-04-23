using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _pointOne;
    [SerializeField] private Transform _pointTwo;

    [SerializeField] private ObjectPool _poolObjects;

    [SerializeField] private float _speed;
    [SerializeField] private float _waitForSeconds;

    private Vector3 _currentPointToDisplacement;

    private int _rangeBorderOne = 0;
    private int _rangeBorderTwo = 2;

    private void Start()
    {
        _currentPointToDisplacement = _pointOne.transform.position;
        StartCoroutine(Motion());
    }
    private void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, _currentPointToDisplacement, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out _) == false)
        {
            return;
        }

        _poolObjects.Put(collision.gameObject);
    }

    private IEnumerator Motion()
    {
        while (true)
        {
            int range = Random.Range(_rangeBorderOne, _rangeBorderTwo);

            yield return new WaitForSeconds(_waitForSeconds);

            if (range is 0)
            {
                _currentPointToDisplacement = _pointOne.transform.position;
            }

            if (range is 1)
            {
                _currentPointToDisplacement = _pointTwo.transform.position;
            }
        }
    }
}
