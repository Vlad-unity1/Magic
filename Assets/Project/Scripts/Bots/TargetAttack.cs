using UnityEngine;

public class TargetAttack : MonoBehaviour
{
    private BulletSpawner bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private void Start()
    {
        bulletPrefab = GetComponent<BulletSpawner>();
    }

    private void FixedUpdate()
    {
        if (bulletPrefab.BulletObj == null)
        {
            bulletPrefab.Cast(_firePoint);
        }
    }
}
