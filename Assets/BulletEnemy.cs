using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    [SerializeField] private float _enemyDamage = 10f;
    [SerializeField] private float _enemyTimerLive = 5f;

    protected override void OnEnable()
    {
        SetProperties();
        base.OnEnable();
    }

    protected override void SetProperties()
    {
        _damage = _enemyDamage;
        _timerLive = _enemyTimerLive;
    }
}
