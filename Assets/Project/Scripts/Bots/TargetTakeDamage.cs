using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTakeDamage : MonoBehaviour
{
    [SerializeField] private float _health = 10;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log("Current Health: " + _currentHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
