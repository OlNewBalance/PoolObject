using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Enemy> _objects = new List<Enemy>();

    private void Create()
    {
        Enemy addedObject = Instantiate(_enemyPrefab, _enemyPrefab.transform.position, _enemyPrefab.transform.rotation);
        addedObject.gameObject.SetActive(false);
        _objects.Add(addedObject);
    }

    public Enemy Get()
    {
        if (_objects.Count == 0)
        {
            Create();
        }

        Enemy result = _objects.Where(o => o != null).First();

        result.gameObject.SetActive(true);
        _objects.Remove(result);
        return result;
    }

    public void Put(Enemy enemyPrefab)
    {
        enemyPrefab.gameObject.SetActive(false);
        _objects.Add(enemyPrefab);
    }
}
