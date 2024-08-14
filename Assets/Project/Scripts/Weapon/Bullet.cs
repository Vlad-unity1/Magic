using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject BulletObj { get; private set; }
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _force;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _attackSpeed;
    private Rigidbody _rb;

    public void Cast(Transform firePoint)
    {
        var bulletOriginal = Instantiate(_bulletPrefab, firePoint.position, firePoint.rotation);
        BulletObj = bulletOriginal;
        _rb = bulletOriginal.GetComponent<Rigidbody>();
        _rb.AddForce(firePoint.transform.forward * _force, ForceMode.Impulse);

        Destroy(BulletObj, _attackSpeed);
    }
}
