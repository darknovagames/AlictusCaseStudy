using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;

    [SerializeField] private InputHandler _inputHandler;

    [SerializeField] private float _maxMoveSpeed = 8;

    private float _currentMoveSpeed = 0;

    public float CurrentMoveSpeed { get => _currentMoveSpeed; }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _inputHandler = GetComponent<InputHandler>();
    }

    private void Update()
    {
        Vector3 inputDirection = new Vector3(_inputHandler.Direction.x, 0, _inputHandler.Direction.y);

        inputDirection.Normalize();


        if(inputDirection.magnitude > 0)
        {
            transform.forward = inputDirection;
            _currentMoveSpeed = _maxMoveSpeed;
        }
        else
        {
            _currentMoveSpeed = 0;
        }

        Vector3 moveVector = inputDirection * _currentMoveSpeed;
        _characterController.Move(moveVector * Time.deltaTime);
    }
}
