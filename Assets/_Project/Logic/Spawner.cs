using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _poolObjects;

    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Transform _targetPosition;

    [SerializeField] private float _waitForSeconds;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(_waitForSeconds);

            Enemy enemy = _poolObjects.Get();
            enemy.Init(_targetPosition, _spawnPosition);
        }
    }
}
