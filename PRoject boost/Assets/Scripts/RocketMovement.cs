using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxAngularVelocity;
    private float _rotateAxis;
    private float _trustAxis;
    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = _maxAngularVelocity;
        _transform = transform;
    }

    private void Update()
    {
        _rotateAxis = Input.GetAxis("Horizontal");
        _trustAxis = Input.GetAxis("Thrust");
    }

    private void FixedUpdate()
    {
        RotateProcess();
        ThrustProcess();
    }

    private void RotateProcess()
    {
        var rotateDirection = _transform.forward * _rotateAxis;
        if (rotateDirection == Vector3.zero) return;
        _rigidbody.AddTorque(rotateDirection * _rotationSpeed, ForceMode.Acceleration);
    }
    
    private void ThrustProcess()
    {
        if (_trustAxis == 0) return;
        _rigidbody.AddForce(_transform.up * _force, ForceMode.Acceleration);
    }

}
