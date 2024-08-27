using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _force;
    private Rigidbody _rb;

    public void Cast(Transform firePoint)
    {
        var bulletOriginal = Instantiate(_bulletPrefab, firePoint.position, firePoint.rotation);
        _rb = bulletOriginal.GetComponent<Rigidbody>();
        _rb.AddForce(firePoint.transform.forward * _force, ForceMode.Impulse);
    }
}
