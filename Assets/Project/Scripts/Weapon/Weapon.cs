using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private BulletRepository _bulletRepository;
    [SerializeField] private float _force;
    [SerializeField] private float _attackSpeed;
    private PlayerLvlUpgrade _currentLvl;
    private BulletType _currentBulletType;
    private Bullet _currentBullet;
    private int _level;
    private Rigidbody _rb;

    private Dictionary<int, BulletType> _bulletTypes = new Dictionary<int, BulletType>()
    {
        {0, BulletType.Fire },
        {1, BulletType.Ice },
    };

    private void Start()
    {
        _currentLvl = GetComponent<PlayerLvlUpgrade>();
        CheckCurrentBullet();
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        WaitForSeconds wait = new WaitForSeconds(_attackSpeed);
        while (true)
        {
            Cast(_firePoint);
            yield return wait;
        }
    }

    public void Cast(Transform firePoint)
    {
        var bulletOriginal = Instantiate(_currentBullet, firePoint.position, firePoint.rotation);
        _rb = bulletOriginal.GetComponent<Rigidbody>();
        _rb.AddForce(firePoint.transform.forward * _force, ForceMode.Impulse);
    }

    internal void CheckCurrentBullet()
    {
        _level = _currentLvl._playerLvl;
        BulletType bulletType = _bulletTypes[_level];
        _currentBulletType = bulletType;

        _currentBullet = _bulletRepository.Get(_currentBulletType);
    }
}
