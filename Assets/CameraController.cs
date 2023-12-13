using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothTime = 0.2f;
    private Vector3 _currentSpeed;

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _target.position + _offset, ref _currentSpeed, _smoothTime);
    }
}
