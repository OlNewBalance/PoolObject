using UnityEngine;

public class Unit : MonoBehaviour
{
    private int _health = 100;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            bullet.PutToPool();
        }
    }

    public void TakeDamage(int damagePoints)
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }

        _health -= damagePoints;
    }
}
