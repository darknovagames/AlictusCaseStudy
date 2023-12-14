using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    [SerializeField] private GameObject _skeletonProjectile;

    [SerializeField] private float _attackRange = 12;

    [SerializeField] private float _moveSpeed = 5;

    [SerializeField] private float _rotationSpeed = 120;

    private float _currentSpeed = 0;

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

        Vector3 directionToPlayer = _player.transform.position - transform.position;
        directionToPlayer.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        //Check if the player is in attack range.
        if (Vector3.Distance(_player.transform.position, transform.position) < _attackRange && !_isAttacking)
        {
            //stop the agent and trigger the attack animation
            _currentSpeed = 0;
            _animator.SetTrigger("Attack");
            _isAttacking = true;
        }
        else
        {
            _currentSpeed = _moveSpeed;
        }

        _animator.SetFloat("Speed", _currentSpeed);
    }

    public void Throw()
    {
    }

    public void EndThrowing()
    {
        _isAttacking = false;
        _currentSpeed = _moveSpeed;
    }
}
