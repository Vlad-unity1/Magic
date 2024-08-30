using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float _damage;
    [SerializeField] protected float _timerLive;
    [SerializeField] private Rigidbody _rb;
    [field: SerializeField] public BulletType Type { get; private set; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    protected virtual void OnEnable()
    {
        StartCoroutine(DestroyDelayed());
    }

    private IEnumerator DestroyDelayed()
    {
        yield return new WaitForSeconds(_timerLive);
        Destroy(gameObject);
    }

    public void Run(Vector3 force)
    {
        _rb.AddForce(force, ForceMode.Impulse);
    }
}
public enum BulletType
{
    Fire = 0,
    Ice = 1,
}
