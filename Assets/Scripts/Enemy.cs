using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    [SerializeField] private GameObject _skeletonProjectile;

    [SerializeField] private float _attackRange = 4;

    [SerializeField] private float _moveSpeed = 5;

    private Player _player;

    private bool _isAttacking = false;

    private Animator _animator;

    private void Start()
    {
        _player = UnitManager.Instance.Player;  
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) < _attackRange && !_isAttacking)
        {

            _navMeshAgent.speed = 0;
            _animator.SetTrigger("Attack");
            _isAttacking = true;
        }
        else
        {
            _navMeshAgent.SetDestination(_player.transform.position);
        }
    }

    public void ChasePlayer()
    {
        _navMeshAgent.SetDestination(_player.transform.position);
    }

    public void Throw()
    {
    }

    public void EndThrowing()
    {
        _isAttacking = false;
        _navMeshAgent.speed = _moveSpeed;
    }
}
