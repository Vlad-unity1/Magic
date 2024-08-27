using UnityEngine;

public class TargetAttack : MonoBehaviour
{
    private BulletSpawner _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private void Start()
    {
        _bulletPrefab = GetComponent<BulletSpawner>();
    }

   
}
