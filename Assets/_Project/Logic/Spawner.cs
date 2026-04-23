using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Transform _targetPosition;

    [SerializeField] private ObjectPool _poolObjects;

    [SerializeField] private float _waitForSeconds;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            if (_poolObjects is null && _targetPosition is null && _enemyPrefab is null)
            {
                yield return null;
            }
            if (_spawnPosition == null && _waitForSeconds == 0)
            {
                yield return null;
            }

            yield return new WaitForSeconds(_waitForSeconds);

            GameObject enemy = _poolObjects.Get(_enemyPrefab, _spawnPosition, _targetPosition);
        }
    }
}
