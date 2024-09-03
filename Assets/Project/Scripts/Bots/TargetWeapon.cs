using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWeapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private BulletRepository _bulletRepository;
    [SerializeField] private float _force;
    [SerializeField] private float _attackSpeed;
    private BulletType _currentBulletType;
    private Bullet _currentBullet;
    private Coroutine _routine;
    private int _level = 0;
    private int _lvlMax = 1;

    private Dictionary<int, BulletType> _bulletTypes = new Dictionary<int, BulletType>()
    {
        {0, BulletType.Fire },
        {1, BulletType.Ice },
    };
    

    private void Start()
    {
        CheckCurrentBullet();
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        WaitForSeconds cooldown = new WaitForSeconds(_attackSpeed);
        while (true)
        {
            Cast(_firePoint);
            yield return cooldown;
        }
    }

    private void Cast(Transform firePoint)
    {
        var bulletOriginal = Instantiate(_currentBullet, firePoint.position, firePoint.rotation);
        bulletOriginal.Run(firePoint.transform.forward * _force);
        if (bulletOriginal is BulletEnemy bulletEnemy)
        {
            bulletEnemy.SetWeapon(this);
        }
    }

    public void UpdateBotsBullet()
    {
        _routine = StartCoroutine(CheckBotsLevelRoutine(10));
    }

    private IEnumerator CheckBotsLevelRoutine(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        if (_level < _lvlMax)
        {
            _level++;
            Debug.Log($"Уровень увеличен: {_level}");
            CheckCurrentBullet();
        }
        else
        {
            Debug.Log("Уровень достиг максимума. Не увеличиваем.");
        }
    }

    internal void CheckCurrentBullet()
    {
        BulletType bulletType = _bulletTypes[_level];
        _currentBulletType = bulletType;
        _currentBullet = _bulletRepository.Get(_currentBulletType);
    }
}
