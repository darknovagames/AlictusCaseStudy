using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _playerMovement.CurrentMoveSpeed);
        _animator.SetBool("IsDead", _player.IsDead);
    }
}
