using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangProjectile : MonoBehaviour, IPlayerProjectile
{
    ITargetable _target;
    [SerializeField] float _speed = 10f;
    [SerializeField] float _rotationSpeed = 30f;

    [SerializeField] private Transform _model;

    public void SetTarget(ITargetable targetable)
    {
        _target = targetable;
    }

    void Start()
    {

    }

    void Update()
    {
        if (_target == null || _target.IsDead) Destroy(gameObject);

        Vector3 targetDirection = _target.Position - transform.position;

        transform.Translate(targetDirection * _speed * Time.deltaTime);

        _model.Rotate(new Vector3(0, _rotationSpeed * Time.deltaTime, 0));
    }
}
