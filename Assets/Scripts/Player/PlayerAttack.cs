using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackRadiusTransform;
    [SerializeField] private float _attackCooldown;

    [SerializeField] private LayerMask _layerMask;

    private Player _player;

    [SerializeField] private GameObject _projectile;

    private float _lastAttackTime = -99;
    private ITargetable _target;

    [SerializeField] private Transform _projectileInstantiationPointTransform;

    [SerializeField] private float _projectileSpeed = 10f;

    [SerializeField] private float _projectileRotationSpeed = 30f;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (_player.IsDead) return;

        _target = GetClosestTargetableInRadius();

        if (_lastAttackTime < Time.time - _attackCooldown && _target != null)
        {
            Attack();
            _lastAttackTime = Time.time;
        }
    }

    private ITargetable GetClosestTargetableInRadius()
    {
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, _attackRadiusTransform.localScale.x * 4.3f, _layerMask,QueryTriggerInteraction.Collide);

        List<ITargetable> targetablesInRange = new List<ITargetable>();

        ITargetable closestTargetable = null;

        float closestTargetableDistance = float.MaxValue;

        foreach(var collider in collidersInRange)
        {
            collider.TryGetComponent(out ITargetable targetable);

            if(targetable != null)
            {
                if(Vector3.Distance(targetable.Position, _player.transform.position) < closestTargetableDistance)
                {
                    closestTargetable = targetable;
                    closestTargetableDistance = Vector3.Distance(targetable.Position, _player.transform.position);
                }
            }
        }

        return closestTargetable;
    }

    private void Attack()
    {
        GameObject projectile = Instantiate(_projectile, _projectileInstantiationPointTransform.position, Quaternion.identity);
        projectile.GetComponent<IPlayerProjectile>().SetTarget(_target);
    }


}
