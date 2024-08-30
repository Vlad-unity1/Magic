using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerForce : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private ForceMode _forceMode;
    private Rigidbody _rb;
    private float _colldown = 4f;
    private bool _isOnCoolDown => _routine != null;
    private Coroutine _routine;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    public void ForceAbility()
    {
        _routine = StartCoroutine(ForceAbilityRoutine());
    }

    private IEnumerator ForceAbilityRoutine()
    {
        if (_isOnCoolDown) yield break;
        _rb.AddForce(transform.forward * _force, ForceMode.Impulse);
        yield return new WaitForSeconds(_colldown);
        _routine = null;
    }
}
