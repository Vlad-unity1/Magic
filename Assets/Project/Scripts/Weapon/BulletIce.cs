using System.Collections;
using UnityEngine;

public class BulletIce : Bullet, IAttackStrategy
{
    [SerializeField] private float _iceDamage = 20f;
    [SerializeField] private float _iceTimerLive = 2f;

    public void Attack()
    {
        Debug.Log("Ice");
    }

    protected override void OnEnable()
    {
        SetProperties();
        base.OnEnable();
    }

    protected override void SetProperties()
    {
        _damage = _iceDamage;
        _timerLive = _iceTimerLive;
    }
}