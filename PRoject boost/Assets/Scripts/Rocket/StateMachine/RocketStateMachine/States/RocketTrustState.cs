using System;
using Rocket.StateMachine.RocketStateMachine.States.Abstract;
using UnityEngine;

namespace Rocket.StateMachine.RocketStateMachine.States
{
    public class RocketTrustState: RocketMovementState
    {
        public static event Action OnTrust;
        public static event Action OnTrustExit;

        public RocketTrustState(global::Rocket.StateMachine.RocketStateMachine.RocketStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            OnTrust?.Invoke();
        }

        public override void Exit()
        {
            base.Exit();
            OnTrustExit?.Invoke();
        }

        public override void Update()
        {
            base.Update();
            if (TrustAxis != 0) return;
            StateMachine.ChangeCurrentState(StateMachine.TrustIdleState);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Trust();
        }

        private void Trust()
        {
            RocketRigidbody.AddRelativeForce(Vector3.up * (MovementData.Force * TrustAxis), 
                ForceMode.Acceleration);
        }
    }
}