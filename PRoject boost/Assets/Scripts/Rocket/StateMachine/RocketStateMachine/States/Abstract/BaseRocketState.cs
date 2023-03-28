using StateMachine;
using UnityEngine;

namespace Rocket.StateMachine.RocketStateMachine.States.Abstract
{
    public abstract class BaseRocketState: IState
    {
        protected global::Rocket.StateMachine.RocketStateMachine.RocketStateMachine StateMachine;
        protected Rigidbody RocketRigidbody;
        protected float RotateAxis;
        protected float TrustAxis;

        protected BaseRocketState(global::Rocket.StateMachine.RocketStateMachine.RocketStateMachine stateMachine)
        {
            StateMachine = stateMachine;
            RocketRigidbody = StateMachine.RocketRigidbody;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
            SetMovementAxis();
        }

        public virtual void FixedUpdate()
        {
        }

        private void SetMovementAxis()
        {
            RotateAxis = Input.GetAxis("Horizontal");
            TrustAxis = Input.GetAxis("Thrust");
        }
    }
}