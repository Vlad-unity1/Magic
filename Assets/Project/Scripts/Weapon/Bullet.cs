using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected float _damage;
    protected float _timerLive;

    protected virtual void OnEnable()
    {
        StartCoroutine(DestroyDelayed());
    }

    //private void OnTriggerEnter(Collider collision)
    //{
    //    TargetTakeDamage target = collision.GetComponent<TargetTakeDamage>();
    //        target.TakeDamage(_damage);
    //        Destroy(gameObject);
    //}

    private IEnumerator DestroyDelayed()
    {
        yield return new WaitForSeconds(_timerLive);
        Destroy(gameObject);
    }

    protected abstract void SetProperties();
}
