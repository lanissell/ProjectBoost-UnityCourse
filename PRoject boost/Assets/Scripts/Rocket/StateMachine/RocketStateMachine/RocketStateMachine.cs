using Rocket.StateMachine.RocketStateMachine.States;
using StateMachine;
using UnityEngine;

namespace Rocket.StateMachine.RocketStateMachine
{
    public class RocketStateMachine: BaseStateMachine
    {
        public Rigidbody RocketRigidbody { get;}

        public RocketTrustIdleState TrustIdleState { get; }
        public RocketRotateIdleState RotateIdleState { get; }
        public RocketTrustState TrustState { get; }
        public RocketRotateState RocketRotateState { get; }

        public RocketStateMachine(Rigidbody rigidbody)
        {
            RocketRigidbody = rigidbody;
            TrustIdleState = new RocketTrustIdleState(this);
            RotateIdleState = new RocketRotateIdleState(this);
            TrustState = new RocketTrustState(this);
            RocketRotateState = new RocketRotateState(this);
        }
    }
}