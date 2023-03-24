using System;
using StateMachine.RocketStateMachine.States.Abstract;
using StateMachine.RocketStateMachine.StatesData;
using UnityEngine;

namespace StateMachine.RocketStateMachine.States
{
    public class RocketMovementState: BaseRocketState
    {
        public static event Action OnRotate; 
        public static event Action OnTrust;
        public static event Action OnRotateExit; 
        public static event Action OnTrustExit;

        private MovementData _movementData;

        public RocketMovementState(RocketStateMachine stateMachine) : 
            base(stateMachine)
        {
            _movementData = Resources.Load<MovementData>("Rocket/MovementData");
        }

        public override void Update()
        {
            base.Update();
            
            if (TrustAxis == 0) OnTrustExit?.Invoke();
            if (RotateAxis == 0) OnRotateExit?.Invoke();
            
            if (TrustAxis != 0 || RotateAxis != 0 ) return;
            StateMachine.ChangeState(StateMachine.IdleState);
        }

        public override void FixedUpdate()
        {
            Trust();
            Rotate();
        }
        
        private void Trust()
        {
            RocketRigidbody.AddRelativeForce(Vector3.up * (_movementData.Force * TrustAxis), 
                ForceMode.Acceleration);
            OnTrust?.Invoke();
        }
        
        private void Rotate()
        {
            var rotateDirection = Vector3.forward * (2 * RotateAxis);
            RocketRigidbody.AddRelativeTorque(rotateDirection * _movementData.RotateSpeed, 
                ForceMode.Acceleration);
            OnRotate?.Invoke();
        }
    }
}