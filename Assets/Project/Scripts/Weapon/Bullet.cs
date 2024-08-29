using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected float _damage;
    protected float _timerLive;
    [field: SerializeField] public BulletType Type { get; private set; }

    protected virtual void OnEnable()
    {
        StartCoroutine(DestroyDelayed());
    }

    private IEnumerator DestroyDelayed()
    {
        yield return new WaitForSeconds(_timerLive);
        Destroy(gameObject);
    }

    protected abstract void SetProperties();
}
public enum BulletType
{
    Fire = 0,
    Ice = 1,
}
