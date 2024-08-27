using System.Collections;
using UnityEngine;

public class BulletIce : Bullet
{
    [SerializeField] private float _iceDamage = 20f;
    [SerializeField] private float _iceTimerLive = 2f;

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