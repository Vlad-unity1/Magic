using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForce : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private ForceMode _forceMode;
    private Rigidbody _rb;
    private float _colldown = 4f;
    private bool _isOnCoolDown = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public IEnumerator ForceAbillity()
    {
        if (_isOnCoolDown) yield break;
        _isOnCoolDown = true;
        _rb.AddForce(transform.forward * _force, ForceMode.Impulse);
        yield return new WaitForSeconds(_colldown);
        _isOnCoolDown = false;
    }
}
