using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private BulletPool _bulletPool;

    public void Init (BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void PutToPool()
    {
        _bulletPool.Put(this);
    }
}
