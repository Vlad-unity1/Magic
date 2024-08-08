using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject BulletObj { get; private set; }
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _force;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _attackSpeed;
    private Rigidbody _rb;
    
    public void Cast()
    {
        var bulletOriginal = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        BulletObj = bulletOriginal;
        _rb = bulletOriginal.GetComponent<Rigidbody>();
        _rb.AddForce(_firePoint.transform.forward * _force, ForceMode.Impulse);

        Destroy(BulletObj, _attackSpeed);
    }
}
