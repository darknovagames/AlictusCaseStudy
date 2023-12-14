using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private Vector3 _initPos;

    [SerializeField] private float _rotationSpeed = 15;
    [SerializeField] private float _bounceSpeed;

    void Start()
    {
        _initPos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, _initPos.y + Mathf.Sin(Time.time * _bounceSpeed), transform.position.z);
        transform.Rotate(new Vector3(0, _rotationSpeed * Time.deltaTime, 0));
    }
}
