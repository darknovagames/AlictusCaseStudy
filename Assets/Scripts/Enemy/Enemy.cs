using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, ITargetable
{
    private NavMeshAgent _navMeshAgent;

    [SerializeField] private GameObject _skeletonProjectile;

    [SerializeField] private float _attackRange = 4;

    [SerializeField] private float _moveSpeed = 5;

    private Player _player;

    public bool IsDead = false;

    private bool _isAttacking = false;


    private Animator _animator;


    public Vector3 Position => transform.position;

    bool ITargetable.IsDead => IsDead;

    private void Start()
    {
        _player = UnitManager.Instance.Player;
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (IsDead)
        {
            _animator.SetBool("IsDead", true);
            return;
        }

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
        GameObject projectile = Instantiate(_skeletonProjectile,
            transform.position,
            Quaternion.identity);
    }

    public void EndThrowing()
    {
        _isAttacking = false;
        _navMeshAgent.speed = _moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerProjectile")
        {
            IsDead = true;
            GameManager.Instance.IncreaseKillCount();
        }
    }

    public void DeathAnimationComplete()
    {
        Destroy(gameObject);
    }
}