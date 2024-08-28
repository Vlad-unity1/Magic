using System.Collections;
using UnityEngine;

public class BulletFire : Bullet, IAttackStrategy
{
    [SerializeField] private float _fireDamage = 10f;
    [SerializeField] private float _fireTimerLive = 5f;

    protected override void OnEnable()
    {
        SetProperties();
        base.OnEnable();
    }
    private void OnTriggerEnter(Collider collision)
    {
        TargetTakeDamage target = collision.GetComponent<TargetTakeDamage>();
        if (target != null)
        {
            target.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
    protected override void SetProperties()
    {
        _damage = _fireDamage;
        _timerLive = _fireTimerLive;
    }

    public void Attack()
    {
        Debug.Log("Fire");
    }
}
