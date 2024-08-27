using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _attackSpeed;

    private void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        WaitForSeconds wait = new WaitForSeconds(_attackSpeed);
        while (true)
        {
            _bulletPrefab.Cast(_firePoint);
            yield return wait;
        }
    }
}
