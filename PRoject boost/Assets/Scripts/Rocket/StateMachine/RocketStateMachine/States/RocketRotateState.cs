using System;
using Rocket.StateMachine.RocketStateMachine.States.Abstract;
using StateMachine;
using UnityEngine;

namespace Rocket.StateMachine.RocketStateMachine.States
{
    public class RocketRotateState: RocketMovementState
    {
        public float Direction;
        public static event Action<float> OnRotateEnter;
        public static event Action OnRotateExit;

        private IState _previousState;
        
        public RocketRotateState(RocketStateMachine stateMachine)
            : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            OnRotateEnter?.Invoke(Direction);
            _previousState = StateMachine.PreviousState;
        }

        public override void Exit()
        {
            base.Exit();
            OnRotateExit?.Invoke();
            _previousState.Exit();
        }

        public override void Update()
        {
            base.Update();
            StateMachine.PreviousState.Update();
            if (RotateAxis != 0) return;
            StateMachine.ChangeCurrentState(_previousState);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            _previousState.FixedUpdate();
            Rotate();
        }

        private void Rotate()
        {
            var rotateVector = Vector3.forward * (2 * RotateAxis);
            RocketRigidbody.AddRelativeTorque(rotateVector * MovementData.RotateSpeed, 
                ForceMode.Acceleration);
        }
    }
}