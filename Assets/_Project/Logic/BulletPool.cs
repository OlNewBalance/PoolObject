using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _enemyPrefab;
    [SerializeField] private List<Bullet> _objects = new List<Bullet>();

    private void Create()
    {
        Bullet addedObject = Instantiate(_enemyPrefab, _enemyPrefab.transform.position, _enemyPrefab.transform.rotation);
        addedObject.gameObject.SetActive(false);
        _objects.Add(addedObject);
    }

    public Bullet Get()
    {
        if (_objects.Count == 0)
        {
            Create();
        }

        Bullet result = _objects.First();

        result.gameObject.SetActive(true);
        _objects.Remove(result);
        return result;
    }

    public void Put(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _objects.Add(bullet);
    }
}
