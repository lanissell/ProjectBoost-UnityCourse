using Rocket.StateMachine.RocketStateMachine;
using StateMachine.RocketStateMachine;
using UnityEngine;

namespace Rocket
{
    [RequireComponent(typeof(Rigidbody))]
    public class RocketMovement : MonoBehaviour
    {
        [SerializeField] private float _maxAngularVelocity;
        [SerializeField] private Transform _centerOfMass;
        private Rigidbody _rigidbody;
        private Transform _transform;
        private RocketStateMachine _stateMachine;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.maxAngularVelocity = _maxAngularVelocity;
            _rigidbody.centerOfMass = _centerOfMass.position;
        
            _stateMachine = new RocketStateMachine(_rigidbody);
            _stateMachine.ChangeCurrentState(_stateMachine.TrustIdleState);
            _stateMachine.ChangeAdditionalState(_stateMachine.RotateIdleState);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }
    }
}
