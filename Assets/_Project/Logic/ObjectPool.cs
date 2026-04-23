using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects;

    private int _maxEnemies = 2;

    public void Set(GameObject enemyPrefab)
    {
        if (_objects is null)
        {
            _objects = new List<GameObject>();
        }

        if (_objects.Count == _maxEnemies)
        {
            return;
        }

        GameObject addedObject = Instantiate(enemyPrefab);
        addedObject.SetActive(false);
        _objects.Add(addedObject);
    }

    public GameObject Get(GameObject enemyPrefab, Transform spawnPoint, Transform targetPosition)
    {
        if (_objects is null)
        {
            _objects = new List<GameObject>();
        }

        if (_objects.Contains(enemyPrefab) == false)
        {
            Set(enemyPrefab);
        }

        GameObject result = _objects.Where(o => o != null).First();

        Enemy enemy = result.GetComponent<Enemy>();
        enemy.Init(this, targetPosition);

        Rigidbody rb = result.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        result.transform.position = spawnPoint.transform.position;
        result.SetActive(true);
        _objects.Remove(result);
        return result;
    }

    public void Put(GameObject enemyPrefab)
    {
        if (_objects is null)
        {
            _objects = new List<GameObject>();
        }

        if (_objects.Count == _maxEnemies)
        {
            Destroy(enemyPrefab);
            return;
        }

        enemyPrefab.SetActive(false);
        _objects.Add(enemyPrefab);
    }
}
