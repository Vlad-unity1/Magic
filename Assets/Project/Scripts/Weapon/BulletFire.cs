using System.Collections;
using UnityEngine;

public class BulletFire : Bullet
{
    [SerializeField] private float _fireDamage = 10f;
    [SerializeField] private float _fireTimerLive = 5f;

    protected override void OnEnable()
    {
        SetProperties();
        base.OnEnable();
    }

    protected override void SetProperties()
    {
        _damage = _fireDamage;
        _timerLive = _fireTimerLive;
    }
}
