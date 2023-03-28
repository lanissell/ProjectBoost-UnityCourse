using System;
using Rocket.StateMachine.RocketStateMachine.States.Abstract;
using UnityEngine;

namespace Rocket.StateMachine.RocketStateMachine.States
{
    public class RocketRotateState: RocketMovementState
    {
         
        public static event Action OnRotateExit;

        public RocketRotateState(global::Rocket.StateMachine.RocketStateMachine.RocketStateMachine stateMachine)
            : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
        }

        public override void Exit()
        {
            base.Exit();
            OnRotateExit?.Invoke();
        }

        public override void Update()
        {
            base.Update();
            if (RotateAxis != 0) return;
            StateMachine.ChangeAdditionalState(StateMachine.RotateIdleState);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Rotate();
        }

        private void Rotate()
        {
            var rotateDirection = Vector3.forward * (2 * RotateAxis);
            RocketRigidbody.AddRelativeTorque(rotateDirection * MovementData.RotateSpeed, 
                ForceMode.Acceleration);
        }
    }
}