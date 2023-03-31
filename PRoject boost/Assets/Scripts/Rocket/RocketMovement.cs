using Rocket.StateMachine.RocketStateMachine;
using StateMachine.RocketStateMachine;
using UnityEngine;

namespace Rocket
{
    [RequireComponent(typeof(Rigidbody))]
    public class RocketMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Transform _transform;
        private RocketStateMachine _stateMachine;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            
            _stateMachine = new RocketStateMachine(_rigidbody);
            _stateMachine.ChangeCurrentState(_stateMachine.IdleState);
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
