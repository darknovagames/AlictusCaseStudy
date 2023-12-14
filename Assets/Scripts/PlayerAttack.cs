using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackRadiusTransform;
    [SerializeField] private float _attackCooldown;

    [SerializeField] private GameObject _projectile;

    private float _lastAttackTime = float.MinValue;
    private Enemy _targetEnemy;

    private void Update()
    {
        GetTheClosestEnemyInRadius();
        if (Time.time > Time.time + _attackCooldown && _targetEnemy != null)
        {
            Attack();
        }
    }

    private void GetTheClosestEnemyInRadius()
    {
        
    }

    private void Attack()
    {

    }

}
