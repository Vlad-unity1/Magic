using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private IAttackStrategy _attackStrategy;
    [SerializeField] public Transform _firePoint;
    private Player _playerStats;

    private void Start()
    {
        _attackStrategy = GetComponent<BulletFire>();
        _playerStats = GetComponent<Player>();
    }

    private void Update()
    {
        _attackStrategy.Attack();
        if (_playerStats._expPlayer == 20)
        {
            _playerStats._playerLvl = 1;
            if (_playerStats._playerLvl >= 1)
            {
                ChangeAttackStrategy(GetComponent<BulletIce>());
            }
        }
    }
    public void ChangeAttackStrategy(IAttackStrategy newStrategy)
    {
        _attackStrategy = newStrategy;
    }
}
