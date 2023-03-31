using System;
using Rocket.StateMachine.RocketStateMachine.States.Abstract;
using UnityEngine;

namespace Rocket.StateMachine.RocketStateMachine.States
{
    public class RocketTrustState: RocketMovementState
    {
        public static event Action OnTrustEnter;

        public RocketTrustState(RocketStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            OnTrustEnter?.Invoke();
        }

        public override void Exit()
        {
            base.Exit();
            StateMachine.PreviousState = this;
        }
 
        public override void Update()
        {
            base.Update();
            ActivateRotateState();
            if (TrustAxis != 0) return;
            StateMachine.ChangeCurrentState(StateMachine.IdleState);
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