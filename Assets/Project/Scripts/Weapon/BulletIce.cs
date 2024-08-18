using UnityEngine;

public class BulletIce : MonoBehaviour, IAttackStrategy
{
    [SerializeField] BulletSpawner _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    public void Attack()
    {
        if (_bulletPrefab.BulletObj == null)
        {
            _bulletPrefab.Cast(_firePoint);
        }
    }
}
