using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodySpeedLimit : MonoBehaviour
{
    [SerializeField] private float _speedLimit;
    [SerializeField] private float _maxAngularVelocity;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = _maxAngularVelocity;
    }

    private void FixedUpdate()
    {
        var velocity = _rigidbody.velocity;
        if (velocity.magnitude < _speedLimit) return;
        _rigidbody.velocity = velocity.normalized * _speedLimit;
    }
}

