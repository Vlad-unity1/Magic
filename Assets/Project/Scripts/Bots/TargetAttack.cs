using UnityEngine;

public class TargetAttack : MonoBehaviour
{
    private Bullet bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private void Start()
    {
        bulletPrefab = GetComponent<Bullet>();
    }

    private void FixedUpdate()
    {
        if (bulletPrefab.BulletObj == null)
        {
            bulletPrefab.Cast(_firePoint);
        }
    }
}
