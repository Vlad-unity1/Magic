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
    [SerializeField] private PlayerAnimation _playerAnimation;
    private PlayerLvlUpgrade _currentLvl;
    private BulletType _currentBulletType;
    private Bullet _currentBullet;
    private int _level;

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
        WaitForSeconds cooldown = new WaitForSeconds(_attackSpeed);
        while (true)
        {
            _playerAnimation.OnPlayerAttack();
            yield return new WaitForSeconds(0.25f);
            Cast(_firePoint);
            yield return cooldown;
        }
    }

    private void Cast(Transform firePoint)
    {
        var bulletOriginal = Instantiate(_currentBullet, firePoint.position, firePoint.rotation);
        bulletOriginal.Run(firePoint.transform.forward * _force);
    }
    
    internal void CheckCurrentBullet()
    {
        _level = _currentLvl.PlayerLvl;
        BulletType bulletType = _bulletTypes[_level];
        _currentBulletType = bulletType;
        _currentBullet = _bulletRepository.Get(_currentBulletType);
    }
}
