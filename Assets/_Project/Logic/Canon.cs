using System.Collections;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Rigidbody _bulletRigidbody;

    [SerializeField] private Vector3 _objectToShoot;

    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _number;
    [SerializeField] private float _timeWaitShooting;

    private void Start() 
    {
        StartCoroutine(Shooting());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Unit>(out Unit unit))
        {
            unit.TakeDamage(_damage);
        }
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeWaitShooting);

            Bullet bullet = _bulletPool.Get();
            bullet.Init(_bulletPool);

            bullet.transform.position = Vector3.MoveTowards(transform.position, _objectToShoot, _speed * Time.deltaTime);
        }
    }
}