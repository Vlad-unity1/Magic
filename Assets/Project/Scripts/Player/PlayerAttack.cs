using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrentAttackStrategy: MonoBehaviour
{
    private IAttackStrategy _attackStrategy;
    private Player _playerStats;

    private void Start()
    {
        _playerStats = GetComponent<Player>();
        _attackStrategy = new BulletFire();
    }

    private void Update()
    {
        _attackStrategy.Attack();

        if (_playerStats._expPlayer == 20)
        {
            _playerStats._playerLvl = 1;
            if (_playerStats._playerLvl >= 1)
            {
                ChangeAttackStrategy(new BulletIce());
            }
        }
    }

    public void ChangeAttackStrategy(IAttackStrategy newStrategy)
    {
        _attackStrategy = newStrategy;
    }
}
